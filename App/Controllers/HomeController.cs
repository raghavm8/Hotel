using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Room()
        {
            return RedirectToAction("Index","Room");
        }

        public ActionResult Reservation()
        {
            return RedirectToAction("Index", "Reservation");
        }

        public ActionResult Guest()
        {
            return RedirectToAction("Index", "Guest");
        }
    }
}