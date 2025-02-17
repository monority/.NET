using Exercice_Api.Data;
using Exercice_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exercice_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : Controller
{
private readonly ApplicationDbContext _context;
    public ContactController(ApplicationDbContext ContactDb)
    {
        _context = ContactDb;
    }
    [HttpGet]
    public IActionResult Get()
    {
        var contacts = _context.Contacts;
        return Ok(contacts);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var contact = _context.Contacts.FirstOrDefault(c => c.Id == id);

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
    public IActionResult Create(Contact contact){

    var contacts = _context.Contacts.Add(contact);
        return CreatedAtAction(nameof(GetById), new { id = contact.Id }, "Contact Added");

    }
}
