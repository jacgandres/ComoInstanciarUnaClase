using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helper;
using MotorReservas.Entidad;
using MotorReservas.Web.ConstumeAttributes;

namespace MotorReservas.Web.Controllers.Administracion
{
    [IfNotLoggedActionAttribute]
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            AdministraionService.AdministracionClient servicio = new AdministraionService.AdministracionClient();

            List<Usuario> usuarios = new List<Usuario>();

            usuarios = servicio.ListarUsuarios();

            return View(usuarios);
        }

        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession(); 
            Session.Remove("Roles");
            return Redirect("~");
        }
    }
}