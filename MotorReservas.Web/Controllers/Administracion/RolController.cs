using System;
using System.Collections.Generic;
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
            AdministracionService.AdministracionClient servicio = new AdministracionService.AdministracionClient();
            List<Rol> roles = servicio.ListarRoles();

            return View(roles);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateRol(Rol pRol)
        {
            if (ModelState.IsValid == true)
            {
                using (AdministracionService.AdministracionClient servicio = new AdministracionService.AdministracionClient())
                {
                    if (servicio.RegistrarRol(pRol) == true)
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
            using (AdministracionService.AdministracionClient cliente = new AdministracionService.AdministracionClient())
            {
                Rol rol = new Rol();
                rol.IdRol = id;
                if (cliente.EliminarRol(rol) == true)
                    return RedirectToAction("Index");
                else
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }
        }

        public ActionResult Detail(int id)
        {
            using (AdministracionService.AdministracionClient cliente = new AdministracionService.AdministracionClient())
            {
                Rol rol = new Rol();
                rol.IdRol = id;

                rol = cliente.ObtenerRolPorId(rol);

                return View(rol);
            }
        }

        public ActionResult GiveModuleToRol(int id)
        {
            using (AdministracionService.AdministracionClient cliente = new AdministracionService.AdministracionClient())
            {
                Rol rol = new Rol();
                rol.IdRol = id;

                List<Modulo> modulos = cliente.ObtenerModulosPorRol(rol);

                ViewBag.IdRol = id;

                return View(modulos);
            }
        }

        public ActionResult DeleteRolToUser(int id, int idRol)
        {
            using (AdministracionService.AdministracionClient cliente = new AdministracionService.AdministracionClient())
            {
                Modulos_Tiene_Rol rolModulo = new Modulos_Tiene_Rol();
                rolModulo.IdRol = idRol;
                rolModulo.IdModulo = id;

                if (cliente.EliminarModuloRolPorId(rolModulo) == true)
                    return RedirectToAction("GiveModuleToRol", new { id = idRol });
                else
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }
        }

        public ActionResult Edit(int id)
        {
            using (AdministracionService.AdministracionClient cliente = new AdministracionService.AdministracionClient())
            {
                Rol rol = new Rol();
                rol.IdRol = id;

                rol = cliente.ObtenerRolPorId(rol);

                return View(rol);
            }
        }

        public ActionResult SaveEditInfo(Rol pRol)
        { 
            if (ModelState.IsValid == true)
            {
                using (AdministracionService.AdministracionClient servicio = new AdministracionService.AdministracionClient())
                {
                    if (servicio.ActualizarRol(pRol) == true)
                        return RedirectToAction("Index");
                    else
                        return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
                }
            }
            else
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [OnlyAjaxRequestAttribute]
        public ActionResult SaveModuleToRol(Modulos_Tiene_Rol pModulo)
        {
            if (ModelState.IsValid == true)
            {
                using (AdministracionService.AdministracionClient cliente = new AdministracionService.AdministracionClient())
                {
                    if (cliente.VerificarRolTieneModulo(pModulo))
                    {
                        if (cliente.RegistrarModuloRol(pModulo) == true)
                        {
                            ResponseModel mResponse = new ResponseModel();
                            mResponse.SetResponse(true);
                            mResponse.message = "El modulo para el rol ha sido correctamente asignado.";
                            return Json(mResponse);
                        }
                        else
                            return Json(new { Response = false, message = "Ocurrio un error en el registro del modulo para el rol" });
                    }
                    else
                        return Json(new { Response = false, message = "El Rol ya tiene asignado ese modulo" });
                }
            }
            else
                return Json(new { Response = false, message = "Ocurrio un error con la validacion del formulario" });
        }

        public ActionResult CreateModuleToRol(int idRol)
        {
            using (AdministracionService.AdministracionClient cliente = new AdministracionService.AdministracionClient())
            {
                Modulos_Tiene_Rol rolModulo = new Modulos_Tiene_Rol();
                rolModulo.IdRol = idRol;
                ViewBag.Modulos = cliente.ObtenerModulos();
                return View(rolModulo);
            }
        }
    }
}