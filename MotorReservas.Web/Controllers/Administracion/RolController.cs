using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MotorReservas.Entidad;
using MotorReservas.Web.ConstumeAttributes;

namespace MotorReservas.Web.Controllers.Administracion
{
    [IfNotLoggedActionAttribute]
    public class RolController : Controller
    {
        // GET: Rol
        public ActionResult Index()
        {
            AdministraionService.AdministracionClient servicio = new AdministraionService.AdministracionClient();
            List<Rol> roles = servicio.ListarRoles();

            return View(roles);
        }
    }
}