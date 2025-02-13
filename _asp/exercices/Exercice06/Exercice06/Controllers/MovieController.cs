using Exercice06.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo01.Controllers
{
    public class MovieController : Controller
    {
        private readonly IRepository<Movie> _repo;
        public MovieController(IRepository<Movie> repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var movies = _repo.GetAll();
            return View("List", movies);
        }

        public IActionResult Create()
        {
            ViewBag.FormMode = "Create";
            return View("Form");
        }

        [HttpPost]
        public IActionResult Create([Bind("Title", "Duration", "Director", "Status")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (_repo.Create(movie) != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("db-status", "Cannot save in the database!");
                    ViewBag.FormMode = "Create";
                    return View("Form", movie);
                }
            }
            else
            {
                ViewBag.FormMode = "Create";
                return View("Form", movie);
            }
        }

        public IActionResult Edit(int id)
        {
            var movieFound = _repo.GetById(id);
            if (movieFound == null) return View("Error", new ErrorViewModel() { RequestId = "404" });
            ViewBag.FormMode = "Edit";
            return View("Form", movieFound);
        }

        [HttpPost]
        public IActionResult ChangeStatus(int id)
        {
            var movieFound = _repo.GetById(id);
            if (movieFound == null) return View("Error", new ErrorViewModel() { RequestId = "404" });
            movieFound.Status = (Status)(((int)movieFound.Status + 1) % Enum.GetValues(typeof(Status)).Length);
            _repo.Update(movieFound);
            var movies = _repo.GetAll();
            ViewBag.FormMode = "List";
            return View("List", movies);
        }

        public IActionResult Details(int id)
        {
            var movieFound = _repo.GetById(id);
            if (movieFound == null) return View("Error", new ErrorViewModel() { RequestId = "404" });
            ViewBag.FormMode = "Details";

            var movies = new HashSet<Movie> { movieFound };
            return View("List", movies);
        }

 
        public IActionResult Delete(int id)
        {
            var movieFound = _repo.GetById(id);
            if (movieFound == null) return View("Error", new ErrorViewModel() { RequestId = "404" });
            ViewBag.FormMode = "Delete";

            if (_repo.Delete(movieFound))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("db-status", "Cannot delete from the database!");
                return View("Error", new ErrorViewModel() { RequestId = "500" });
            }
        }


        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (_repo.Update(movie) != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("db-status", "Cannot save in the database!");
                    ViewBag.FormMode = "Edit";
                    return View("Form", movie);
                }
            }
            else
            {
                ViewBag.FormMode = "Edit";
                return View("Form", movie);
            }
        }
    }
}
