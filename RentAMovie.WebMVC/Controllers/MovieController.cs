using Microsoft.AspNet.Identity;
using RentAMovie.Models.MovieModels;
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
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

        private MovieService GetMovieService()
        {
            var userId = User.Identity.GetUserId();
            var service = new MovieService(userId);
            return service;
        }
    }
}