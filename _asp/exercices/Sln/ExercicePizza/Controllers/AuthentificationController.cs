using System;
using ExercicePizza.DTOs.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ExercicePizza.Helpers;
using ContactWithDtos.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Swashbuckle.AspNetCore.Annotations;
using ExercicePizza.DTOs;
using ExercicePizza.Models;
using Microsoft.AspNetCore.Authorization;

namespace ExercicePizza.Data;


[Route("authentication")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    private readonly AppSettings _appSettings;
    private readonly Encryptor _encryptor;

    public AuthenticationController(ApplicationDbContext dbContext,
                                    IOptions<AppSettings> optionsAppSettings)
    {
        _dbContext = dbContext;
        _appSettings = optionsAppSettings.Value;
        _encryptor = new Encryptor(/*_appSettings.SecretKey!*/);
    }

    [HttpPost("register")]
    [SwaggerOperation(Summary = "Add a new user.")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<RegisterResponseDTO>> Register([FromBody] RegisterRequestDTO registerDto)
    {
        if (registerDto.IsAdmin && User.FindFirstValue(ClaimTypes.Role) != Helpers.Constants.RoleAdmin)
            return Unauthorized(new RegisterResponseDTO
            { IsSuccessful = false, ErrorMessage = "You can't create an administrator as a user." });

        if (await _dbContext.Users.AnyAsync(u => u.Email == registerDto.Email))
            return BadRequest(new RegisterResponseDTO
            { IsSuccessful = false, ErrorMessage = "Email already exist !" });

        var user = new User
        {
            Email = registerDto.Email,
            Password = _encryptor.EncryptPassword(registerDto.Password!),
            IsAdmin = registerDto.IsAdmin,
        };

        await _dbContext.AddAsync(user);

        if (await _dbContext.SaveChangesAsync() == 0)
            return BadRequest(new RegisterResponseDTO { IsSuccessful = false, ErrorMessage = "Probleme creation User" });

        return Ok(new RegisterResponseDTO { IsSuccessful = true, User = user });
    }

    [HttpGet]

    [ProducesResponseType(typeof(IEnumerable<UserDTO>), StatusCodes.Status200OK)]
    [AllowAnonymous] // permet de donner l'accès à l'endpoint aux personnes sans JWT => remplace l'annotion [Authorize] du controller
    public async Task<IActionResult> Get(
            [FromQuery] string? name,
            [FromQuery] string? email,
            [FromQuery] Guid? id
    )
    {
        var query = _dbContext.Users.AsQueryable();

        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(u => u.Name.Contains(name));
        }

        if (!string.IsNullOrEmpty(email))
        {
            query = query.Where(u => u.Email == email);
        }

        if (id.HasValue)
        {
            query = query.Where(u => u.Id == id.Value);
        }

        var users = await query.ToListAsync();
        return Ok(users);
    }


    [HttpPost("login")]
    [SwaggerOperation(Summary = "Connect and get JWT.")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<LoginResponseDTO>> Login([FromBody] LoginRequestDTO loginDto)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);

        if (user == null)
            return BadRequest(new LoginResponseDTO { IsSuccessful = false, ErrorMessage = "Invalid Authentication !" });

        var (verified, needsUpgrade) = _encryptor.Check(user.Password!, loginDto.Password!);

        if (!verified)
            return BadRequest(new LoginResponseDTO { IsSuccessful = false, ErrorMessage = "Invalid Authentication !" });

        if (needsUpgrade)
        {
            user.Password = _encryptor.EncryptPassword(loginDto.Password!);
            await _dbContext.SaveChangesAsync(); // ajouter try catch
        }

        #region JWT

        string role = user.IsAdmin ? Helpers.Constants.RoleAdmin : Helpers.Constants.RoleUser;

        var claims = new List<Claim>
    {
        new (ClaimTypes.Role, role),
        new (Helpers.Constants.ClaimUserId, user.Id!.ToString()!),
    };

        var securityKey = _appSettings.SecretKey;

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(securityKey)),
            SecurityAlgorithms.HmacSha256);

        var jwt = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddDays(_appSettings.TokenExpirationDays),
            signingCredentials: signingCredentials
        );

        string token = new JwtSecurityTokenHandler().WriteToken(jwt);

        #endregion

        return Ok(new LoginResponseDTO
        {
            IsSuccessful = true,
            Token = token,
            User = user
        });
    }
}