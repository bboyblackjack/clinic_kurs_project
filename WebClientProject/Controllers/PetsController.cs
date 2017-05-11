using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClientProject.Controllers
{
    public class PetsController : Controller
    {
        public ActionResult Pets()
        {
            return View();
        }

        public ActionResult CreatePet()
        {
            return View();
        }

        public ActionResult UpdatePet(int id)
        {
            ViewBag.id = id;
            return View();
        }
	}
}