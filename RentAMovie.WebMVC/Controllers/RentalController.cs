using Microsoft.AspNet.Identity;
using RentAMovie.Models.RentalModels;
using RentAMovie.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RentAMovie.WebMVC.Controllers
{
    public class RentalController : Controller
    {
        
        // GET: Rental
        [ActionName("Index")]
        public async Task<ActionResult> Index()
        {
            var service = GetRentalService();
            return View(await service.GetAllRentalsAsync());
        }


        // GET: Rental/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rental/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RentalCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = GetRentalService();
                if (await service.CreateRentalAsync(model))
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }
        
        // GET: Rental/detail/id
        public async Task<ActionResult> Details(int id)
        {
            var svc = GetRentalService();
            var model = await svc.GetRentalByIdAsync(id);

            return View(model);
        }

        // GET: Delete
        [ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var svc = GetRentalService();
            var model = await svc.GetRentalByIdAsync(id);

            return View(model);
        }

        // POST: Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = GetRentalService();

            service.DeleteRental(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }
        
        private RentalService GetRentalService()
        {
            var userId = User.Identity.GetUserId();
            var service = new RentalService(userId);
            return service;
        }
    }
}