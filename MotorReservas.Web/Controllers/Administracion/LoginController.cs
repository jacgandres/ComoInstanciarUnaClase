using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MotorReserva.Entidad;
using MotorReservas.Entidad;
using MotorReservas.Web.ConstumeAttributes;

namespace MotorReservas.Web.Controllers.Administracion
{
    [IfLoggedActionAttribute]
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
            Usuario pUsuario = new Usuario();
            Usuario modelo = null;
            if (ModelState.IsValid)
            {
                Clave = Helper.HashHelper.MD5(Clave);
                pUsuario.Clave = Clave;
                pUsuario.Correo = Correo;
                modelo = servicio.IniciarSesionUsuario(pUsuario);
                if (modelo == null)
                    return Json(new { response = false, message = "El Correo o Clave tienen algun dato invalido." });
                else
                {
                    Helper.SessionHelper.AddUserToSession(modelo.IdUsuario.ToString());

                    ResponseModel mResponse = new ResponseModel();
                    mResponse.SetResponse(true);
                    mResponse.href = "home";

                    return Json(mResponse);
                }
            }
            else
            {
                return Json(new { response = false, message = "Ocurrio un error con la validación del Formulario." });
            }
        }
    }
}