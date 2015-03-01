using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MotorReservas.Entidad;
using MotorReservas.Web.ConstumeAttributes;

namespace MotorReservas.Web.Controllers.Administracion
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [OnlyAjaxRequestAttribute]
        public JsonResult Acceder(string Correo, string Clave)
        {
            AdministraionService.AdministracionClient servicio = new AdministraionService.AdministracionClient();
            Usuario modelo = null;
            if (ModelState.IsValid)
            {
                Clave = Helper.HashHelper.MD5(Clave);
                if (modelo == null)
                    return Json(new { response = false, message = "El Correo o Clave tienen algun dato invalido." });
                else
                {

                }
            }
            else
            {
                return Json(new { response = false, message = "Ocurrio un error con la validación del Formulario." });
            }
        }
    }
}