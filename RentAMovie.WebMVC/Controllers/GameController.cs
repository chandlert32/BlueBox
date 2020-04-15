using Microsoft.AspNet.Identity;
using RentAMovie.Models.GameModels;
using RentAMovie.Models.RatingModels.Game;
using RentAMovie.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RentAMovie.WebMVC.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        [ActionName("Index")]
        public async Task<ActionResult> Index()
        {
            var service = GetGameService();
            return View(await service.GetAllGamesAsync());
        }

        // GET: Game/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Game/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(GameCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = GetGameService();
                if (await service.CreateGameAsyc(model))
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }

        // GET: Game/detail/id
        public async Task<ActionResult> Details(int id)
        {
            var svc = GetGameService();
            var model = await svc.GetGameByIdAsync(id);

            return View(model);
        }

        // GET: Game/edit
        [Authorize]
        public async Task<ActionResult> Edit(int id)
        {
            var service = GetGameService();
            var detail = await service.GetGameByIdAsync(id);
            var model =
                new GameEdit
                {
                    GameId = detail.GameId,
                    GameTitle = detail.GameTitle,
                    Console = detail.Console,
                    Genre = detail.Genre,
                    Player = detail.Player,
                    Online = detail.Online,
                    GameDescription = detail.GameDescription
                };
            return View(model);
        }

        // POST: Game/edit
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GameEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.GameId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = GetGameService();

            if (service.UpdateGame(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }


        // GET: Game/Rate/id
        [HttpGet]
        public async Task<ActionResult> Rate(int id)
        {
            var service = GetGameService();
            ViewBag.Detail = await service.GetGameByIdAsync(id);

            var model = new GameRatingCreate { GameId = id };
            return View(model);
        }

        // POST: Game/Rate/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Rate(GameRatingCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = new RatingService(User.Identity.GetUserId());
                if (await service.CreateGameRatingAsync(model))
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }

        // GET: Delete
        [Authorize]
        [ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var svc = GetGameService();
            var model = await svc.GetGameByIdAsync(id);

            return View(model);
        }

        // POST: Delete
        [HttpPost]
        [Authorize]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = GetGameService();

            service.DeleteGame(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }
        
        private GameService GetGameService()
        {
            var userId = User.Identity.GetUserId();
            var service = new GameService(userId);
            return service;
        }
    }
}