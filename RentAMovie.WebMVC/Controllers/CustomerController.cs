using Microsoft.AspNet.Identity;
using RentAMovie.Models.CustomerModels;
using RentAMovie.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RentAMovie.WebMVC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        [Authorize(Roles ="Admin")]
        [ActionName("Index")]
        public async Task<ActionResult> Index()
        {
            var service = GetCustomerService();
            return View(await service.GetAllCustomersAsync());
        }

        // GET: Customer/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CustomerCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = GetCustomerService();
                if (await service.CreateCustomerAsyc(model))
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }

        // GET: Customer/detail/id
        [Authorize]
        public async Task<ActionResult> Details(int id)
        {
            var svc = GetCustomerService();
            var model = await svc.GetCustomerByIdAsync(id);

            return View(model);
        }

        // GET: Customer/edit
        [Authorize]
        public async Task<ActionResult> Edit(int id)
        {
            var service = GetCustomerService();
            var detail = await service.GetCustomerByIdAsync(id);
            var model =
                new CustomerEdit
                {
                    CustomerId = detail.CustomerId,
                    FullName = detail.FullName,
                    Age = detail.Age,
                    Phone = detail.Phone,
                    Email = detail.Email,

                };
            return View(model);
        }

        // POST: Customer/edit
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CustomerId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = GetCustomerService();

            if (service.UpdateCustomer(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }

        // GET: Delete
        [Authorize]
        [ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var svc = GetCustomerService();
            var model = await svc.GetCustomerByIdAsync(id);

            return View(model);
        }

        // POST: Delete
        [HttpPost]
        [Authorize]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = GetCustomerService();

            service.DeleteCustomer(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }

        private CustomerService GetCustomerService()
        {
            var userId = User.Identity.GetUserId();
            var service = new CustomerService(userId);
            return service;
        }
    }
}