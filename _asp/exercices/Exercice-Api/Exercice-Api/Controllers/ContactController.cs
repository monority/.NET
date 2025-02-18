using Exercice_Api.Data;
using Exercice_Api.Models;
using Exercice_Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Exercice_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : Controller
{
    private readonly IContactService _service;
    private readonly ApplicationDbContext _context;
    public ContactController(IContactService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var contacts = _service.GetAll();
        return Ok(contacts);
    }


    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var contact = _service.GetById(id);

        if (contact == null)
            return NotFound(new
            {
                Message = "Contact not found!"
            });
        return Ok(new
        {
            Message = "Contact found !",
            Contact = contact
        });
    }
    [HttpPost]
    [ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(void), StatusCodes.Status429TooManyRequests)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]

    public IActionResult Create(Contact contact)
    {
        if (ModelState.IsValid)
        {
            _service.Add(contact);
            return Ok(new
            {
                Message = "Contact created successfully!",
                Contact = contact
            });
        }
        return BadRequest(ModelState);
    }

    [HttpGet("name/{LastName}")]
    [ProducesResponseType(typeof (Contact), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public IActionResult GetByName(string lastName)
    {
        var contact = _service.GetByName(lastName);

        if (contact == null)
            return NotFound(new
            {
                Message = "Contact not found!"
            });
        return Ok(new
        {
            Message = "Contact found !",
            Contact = contact
        });
    }

    //[HttpGet]

    //public IActionResult FilterContacts(string paremeter)
    //{

    //}


    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public IActionResult Update(Contact contact)
    {
        if (ModelState.IsValid)
        {
            _service.Update(contact);
            return Ok("Contact Updated");
        }
        else{
        return BadRequest(ModelState);
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        var findContact = _service.GetById(id);
        if (findContact == null)
        {
            return NotFound(new
            {
                Message = "Contact not found!"
            });
        }
        _service.Delete(findContact);
        return Ok(new
        {
            Message = "Contact deleted successfully!"
        });
    }


}

