using Microsoft.AspNet.Identity;
using RentAMovie.Models.GameModels;
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
        public ActionResult Create()
        {
            return View();
        }

        // POST: Game/Create
        [HttpPost]
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

        private GameService GetGameService()
        {
            var userId = User.Identity.GetUserId();
            var service = new GameService(userId);
            return service;
        }
    }
}