using Microsoft.AspNetCore.Mvc;

namespace Demo01.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class HelloController : Controller
{
[HttpGet]
    public IActionResult HelloWorld()
    {
        return Ok("Hello World!");
    }
}
