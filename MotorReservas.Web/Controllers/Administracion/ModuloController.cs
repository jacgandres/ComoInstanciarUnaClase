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
    [IsAuthorizated]
    public class ModuloController : Controller
    {
        // GET: Modulo
        public ActionResult Index()
        {
            using (AdministracionService.AdministracionClient servicio = new AdministracionService.AdministracionClient())
            {
                List<Modulo> modulos = servicio.ObtenerModulos();
                return View(modulos);
            }
        }

        // GET: Modulo/Details/5
        public ActionResult Details(int id)
        {
            using (AdministracionService.AdministracionClient servicio = new AdministracionService.AdministracionClient())
            {
                Modulo mod = new Modulo();
                mod.IdModulo = id;
                mod = servicio.ObtenerModuloPorId(mod);
                return View(mod);
            }
        }

        // GET: Modulo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Modulo/Create
        [HttpPost]
        [OnlyAjaxRequestAttribute]
        public JsonResult Create(Modulo pModulo)
        {
            pModulo.FechaRegistro = DateTime.Now;
            pModulo.Activo = true;
            if (ModelState.IsValid)
            {
                using (AdministracionService.AdministracionClient servicio = new AdministracionService.AdministracionClient())
                {
                    if (servicio.RegistrarModulo(pModulo) == true)
                    {
                        ResponseModel mResponse = new ResponseModel();
                        mResponse.SetResponse(true);
                        mResponse.href = "modulo/index";
                        return Json(mResponse);
                    }
                    else
                        return Json(new { Response = false, message = "Ocurrio un error en el registro del modulo para el rol" });
                }
            }
            else
                return Json(new { Response = false, message = "Ocurrio un error con la validacion del formulario" }); 
        }

        // GET: Modulo/Edit/5
        public ActionResult Edit(int id)
        {
            using (AdministracionService.AdministracionClient servicio = new AdministracionService.AdministracionClient())
            {
                Modulo mod = new Modulo();
                mod.IdModulo = id;
                mod = servicio.ObtenerModuloPorId(mod);
                return View(mod);
            }
        }
         
        public ActionResult SalvarInformacionEdicionModulo(Modulo pModulo)
        {
            if (ModelState.IsValid == true)
            {
                using (AdministracionService.AdministracionClient servicio = new AdministracionService.AdministracionClient())
                {
                    if (servicio.ActualizarModulo(pModulo) == true)
                        return RedirectToAction("Index");
                    else
                        return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
                }
            }
            else
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

        public ActionResult Delete(int id)
        {
            using (AdministracionService.AdministracionClient servicio = new AdministracionService.AdministracionClient())
            {
                Modulo mod = new Modulo();
                mod.IdModulo = id;
                if (servicio.EliminarModulo(mod) == true)
                    return RedirectToAction("Index");
                else
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}
