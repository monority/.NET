using Exercice4.Data;
using Exercice4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exercice4.Controllers
{
    public class GraDinoController : Controller
    {
        private readonly FakeDb _db;

        public GraDinoController(FakeDb db)
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
            return View(_db.GraDinos);
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

            var newId = _db.GraDinos.Max(c => c.Id) + 1;
            var rand = new Random();

            var randomHeight = rand.Next(25, 150);
            var randomWeight = rand.Next(40, 70);
            var gradino = new GraDino() { Id= newId, NickName = RandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 12), height = randomHeight, weight = randomWeight, specy = RandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 12) };

            //gradino.Id = newId;
            //gradino.weight = randomWeight;
            //gradino.height = randomHeight;
            //gradino.specy = RandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 12);
            //gradino.NickName = RandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 12);
            _db.GraDinos.Add(gradino);
            return RedirectToAction("List");
        }
    }
}
