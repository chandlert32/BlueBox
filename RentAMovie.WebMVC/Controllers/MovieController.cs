using Microsoft.AspNet.Identity;
using RentAMovie.Models.MovieModels;
using RentAMovie.Models.RatingModels.Movie;
using RentAMovie.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RentAMovie.WebMVC.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        [ActionName("Index")]
        public async Task<ActionResult> Index()
        {
            var service = GetMovieService();
            return View(await service.GetAllMoviesAsync());
        }

        // GET: Movie/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MovieCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = GetMovieService();
                if (await service.CreateMovieAsyc(model))
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }

        // GET: Movie/detail/id
        public async Task<ActionResult> Details(int id)
        {
            var svc = GetMovieService();
            var model = await svc.GetMovieByIdAsync(id);

            return View(model);
        }

        // GET: Movie/edit
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(int id)
        {
            var service = GetMovieService();
            var detail = await service.GetMovieByIdAsync(id);
            var model =
                new MovieEdit
                {
                    MovieId = detail.MovieId,
                    MovieTitle = detail.MovieTitle,
                    Genre = detail.Genre,
                    MovieDescription = detail.MovieDescription
                };
            return View(model);
        }

        // POST: Movie/edit
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MovieEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MovieId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = GetMovieService();

            if (service.UpdateMovie(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }


        // GET: Movie/Rate/id
        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<ActionResult> Rate(int id)
        {
            var service = GetMovieService();
            ViewBag.Detail = await service.GetMovieByIdAsync(id);

            var model = new MovieRatingCreate { MovieId = id };
            return View(model);
        }

        // POST: Game/Rate/id
        [HttpPost]
        [Authorize(Roles = "User")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Rate(MovieRatingCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = new RatingService(User.Identity.GetUserId());
                if (await service.CreateMovieRatingAsync(model))
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }

        // GET: Delete
        [Authorize(Roles = "Admin")]
        [ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var svc = GetMovieService();
            var model = await svc.GetMovieByIdAsync(id);

            return View(model);
        }

        // POST: Delete
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = GetMovieService();

            service.DeleteMovie(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }

        private MovieService GetMovieService()
        {
            var userId = User.Identity.GetUserId();
            var service = new MovieService(userId);
            return service;
        }
    }
}