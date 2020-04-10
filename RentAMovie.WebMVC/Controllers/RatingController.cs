using Microsoft.AspNet.Identity;
using RentAMovie.Models.RatingModels.Game;
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
    public class RatingController : Controller
    {
        // GET: GameRating
        [ActionName("GameRatingIndex")]
        public async Task<ActionResult> GameRatingIndex()
        {
            var service = GetRatingsService();
            return View(await service.GetAllGameRatingsAsync());
        }

        // GET: GameRating/detail/id
        public async Task<ActionResult> GameRatingDetails(int id)
        {
            var svc = GetRatingsService();
            var model = await svc.GetGameRatingByIdAsync(id);

            return View(model);
        }

        // GET: GameRating/edit
        public async Task<ActionResult> GameRatingEdit(int id)
        {
            var service = GetRatingsService();
            var detail = await service.GetGameRatingByIdAsync(id);
            var model =
                new GameRatingEdit
                {
                    RatingId = detail.RatingId,
                    GameId = detail.GameId,
                    Score = detail.Score,
                    Description = detail.Description
                };
            return View(model);
        }

        // POST: GameRating/edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GameRatingEdit(int id, GameRatingEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RatingId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = GetRatingsService();

            if (service.UpdateGameRating(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("GameRatingIndex");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }








        // GET: MovieRating
        [ActionName("MovieRatingIndex")]
        public async Task<ActionResult> MovieRatingIndex()
        {
            var service = GetRatingsService();
            return View(await service.GetAllMovieRatingsAsync());
        }

        private RatingService GetRatingsService()
        {
            var userId = User.Identity.GetUserId();
            var service = new RatingService(userId);
            return service;
        }

        // GET: MovieRating/detail/id
        public async Task<ActionResult> MovieRatingDetails(int id)
        {
            var svc = GetRatingsService();
            var model = await svc.GetMovieRatingByIdAsync(id);

            return View(model);
        }

        // GET: MovieRating/edit
        public async Task<ActionResult> MovieRatingEdit(int id)
        {
            var service = GetRatingsService();
            var detail = await service.GetMovieRatingByIdAsync(id);
            var model =
                new MovieRatingEdit
                {
                    RatingId = detail.RatingId,
                    MovieId = detail.MovieId,
                    Score = detail.Score,
                    Description = detail.Description
                };
            return View(model);
        }

        // POST: MovieRating/edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MovieRatingEdit(int id, MovieRatingEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RatingId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = GetRatingsService();

            if (service.UpdateMovieRating(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("MovieRatingIndex");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }
    }
}