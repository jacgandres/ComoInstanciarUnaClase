using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MotorReservas.Web.Controllers.Comun
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(int statusCode, Exception exception)
        {
            switch (statusCode)
            {
                case 500:
                    ViewBag.Tipo = "Error 500 Acción Inesperada";
                    ViewBag.Detalle = "<b>Ooops !!</b>, Lo sentimos mucho, ha ocurrido un error en nuestra sistema, estamos trabajando para solucionarlo." +
                        "<br/><div> Error: " + exception.Message + "</div>" +
                        "<br/><div> StackTrace: " + exception.StackTrace + "</div>" +
                        "<br/><div> Source: " + exception.Source + "</div>" +
                        "<br/><div> TargetSite: " + exception.TargetSite.ToString() + "</div>";
                    break;
                case 404:
                    ViewBag.Tipo = "Error 404 Página no encontrada";
                    ViewBag.Detalle = "<br/><div> Error: Lo sentimos esta página no se encuentra en nuestro servidor.</div>";
                    break;
                default:
                    ViewBag.Tipo = "Error inesperado";
                    ViewBag.Detalle = "<br/><div> Error: " + exception.Message + "</div>" +
                        "<br/><div> StackTrace: " + exception.StackTrace + "</div>" +
                        "<br/><div> Source: " + exception.Source + "</div>" +
                        "<br/><div> TargetSite: " + exception.TargetSite.ToString() + "</div>";
                    break;
            }

            return View();
        }
    }
}