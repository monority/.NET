using System.Diagnostics;
using System.Threading.Channels;
using Exercice01_Pages.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exercice01_Pages.Controllers
{
    // Contacts => possible grace au app.Mapcontroller default de program.cs
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Details()
        {
            var contact01 = new Contact(1, "Ronan", "Kolan", "ronan.kolan@gmail.com");
            var contact02 = new Contact(2, "Denis", "Kolan", "denis.kolan@gmail.com");
            var contact03 = new Contact(3, "Alice", "Karona", "alice.karano@gmail.com");

            var contacts = new List<Contact>()
            {
            contact01,
            contact02,
            contact03,
            };

            ViewBag.Contacts = contacts;
            ViewData["contact"] = contacts;
            return View(contacts);
        }
    }
}
