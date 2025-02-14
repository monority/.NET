using Exercice06.Entities;
using Exercice06.Models;
using Exercice06.Services;
using Microsoft.AspNetCore.Mvc;

namespace Exercice06.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        public IActionResult Index()
        {
            var movies = _movieService.GetAll();
            return View("List", movies);
        }

        public IActionResult Create(MovieCreateViewModel movieViewModel)
        {
            if (ModelState.IsValid)
            {
                if (_movieService.Create(movieViewModel) != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("db-status", "Cannot save in the database!");
                    ViewBag.FormMode = "Create";
                    return View("Form", movieViewModel);
                }
            }
            else
            {
                ViewBag.FormMode = "Create";
                return View("Form", movieViewModel);
            }
        }
        [HttpPost]
        //public IActionResult Create(MovieCreateViewModel movieViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (_movieService.Create(movieViewModel) != null)
        //        {
        //            return RedirectToAction(nameof(Index));
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("db-status", "Cannot save in the database!");
        //            ViewBag.FormMode = "Create";
        //            return View("Form", movieViewModel);
        //        }
        //    }
        //    else
        //    {
        //        ViewBag.FormMode = "Create";
        //        return View("Form", movieViewModel);
        //    }
        //}

        public IActionResult Edit(int id)
        {
            var movieFound = _movieService.GetById(id);
            if (movieFound == null) return View("Error", new ErrorViewModel() { RequestId = "404" });
            ViewBag.FormMode = "Edit";
            return View("Form", movieFound);
        }

        [HttpPost]
        public IActionResult ChangeStatus(int id)
        {
            var movieFound = _movieService.GetById(id);
            if (movieFound == null) return View("Error", new ErrorViewModel() { RequestId = "404" });
            movieFound.Status = (Status)(((int)movieFound.Status + 1) % Enum.GetValues(typeof(Status)).Length);
            _movieService.Update(movieFound);
            var movies = _movieService.GetAll();
            ViewBag.FormMode = "List";
            return View("List", movies);
        }

        public IActionResult Details(int id)
        {
            var movieFound = _movieService.GetById(id);
            if (movieFound == null) return View("Error", new ErrorViewModel() { RequestId = "404" });
            ViewBag.FormMode = "Details";

            var movies = new HashSet<MovieViewModel> { movieFound };
            return View("List", movies);
        }


        public IActionResult Delete(long id)
        {
            var movieFound = _movieService.GetById(id);
            if (movieFound == null) return View("Error", new ErrorViewModel() { RequestId = "404" });
            ViewBag.FormMode = "Delete";

            if (_movieService.Delete(movieFound) == null)
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
        public IActionResult Edit(MovieViewModel movie)
        {
            if (ModelState.IsValid)
            {
                if (_movieService.Update(movie) != null)
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
