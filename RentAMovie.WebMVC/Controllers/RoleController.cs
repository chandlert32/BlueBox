using Microsoft.AspNet.Identity.EntityFramework;
using RentAMovie.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentAMovie.WebMVC.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext context;

        public RoleController()
        {
            context = new ApplicationDbContext();
        }

        // GET: All Role
        [Authorize]
        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        //create a new role
        [Authorize]
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        //create a new role 
        [HttpPost]
        [Authorize]
        public ActionResult Create(IdentityRole Role)
        {
            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}