using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MotorReservas.Web.ConstumeAttributes;

namespace MotorReservas.Web.Controllers
{
    [IfNotLoggedActionAttribute]
    [IsAuthorizated]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["NoAutorizado"] != null && (bool)Session["NoAutorizado"] == true)
            {
                Session.Remove("NoAutorizado");
                ViewBag.NoAutorizado = true;
            }
            else
                ViewBag.NoAutorizado = false;

            return View();
        }

    }
}