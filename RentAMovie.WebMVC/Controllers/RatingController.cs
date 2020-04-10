using Microsoft.AspNet.Identity;
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
    }
}