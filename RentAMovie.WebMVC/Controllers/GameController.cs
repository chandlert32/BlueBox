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
    public class GameController : Controller
    {
        // GET: Game
        public async Task<ActionResult> Index()
        {
            var service = GetGameService();
            return View(await service.GetAllGamesAsync());
        }

        private GameService GetGameService()
        {
            var userId = User.Identity.GetUserId();
            var service = new GameService(userId);
            return service;
        }
    }
}