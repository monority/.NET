using Exercice4.Data;
using Exercice4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exercice4.Controllers
{
    public class GraDinoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public GraDinoController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            ViewBag.GraDinos = _db.GraDinos;
            ViewData["gradinos"] = _db.GraDinos;
            return View(_db.GraDinos.ToHashSet());
        }
        public IActionResult Details(long id)
        {
            var graDinoFound = _db.GraDinos.FirstOrDefault(c => c.Id == id);

            if (graDinoFound != null)
            {
                return View(graDinoFound);
            }
            else
            {
                return View("Error");
            }
        }
        public static string RandomString(string chars, int length)
        {
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public IActionResult CreateRandom()
        {
            var rand = new Random();
            var randomHeight = rand.Next(25, 150);
            var randomWeight = rand.Next(40, 70);
            var gradino = new GraDino()
            {
                NickName = RandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 12),
                height = randomHeight,
                weight = randomWeight,
                specy = RandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 12)
            };
            _db.GraDinos.Add(gradino);
            _db.SaveChanges();
            return RedirectToAction("List");
        }

    }
}
