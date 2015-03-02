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
            if (ModelState.IsValid)
            {
                Clave = Helper.HashHelper.MD5(Clave);
                pUsuario.Clave = Clave;
                pUsuario.Correo = Correo;
                List<object> wbResult = servicio.IniciarSesionUsuario(pUsuario);
                if (wbResult.Count < 1)
                    return Json(new { response = false, message = "El Correo o Clave tienen algun dato invalido." });
                else
                { 
                    Helper.SessionHelper.AddUserToSession(((Usuario)wbResult[0]).IdUsuario.ToString());

                    ResponseModel mResponse = new ResponseModel();
                    mResponse.SetResponse(true);
                    mResponse.href = "home";

                    Session["Roles"] = wbResult[1];

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