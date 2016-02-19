using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MotorReservas.Entidad;

namespace MotorReservas.Web.Controllers.Comun
{
    public class TipoIdentificacionController : Controller
    {
        // GET: TipoIdentificacion
        public ActionResult Index()
        {
            using (ComunService.ComunClient service = new ComunService.ComunClient())
            {
                List<TipoIdentificacion> lstTiposId = service.ObtenerTiposIdentificacion();
                ViewBag.TiposIdentificacion = lstTiposId;
                return PartialView(lstTiposId);
            }
        }
    }
}