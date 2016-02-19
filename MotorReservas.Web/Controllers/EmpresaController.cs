using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Helper;
using MotorReservas.Entidad;
using MotorReservas.Web.ConstumeAttributes;

namespace MotorReservas.Web.Controllers
{
    [IfNotLoggedActionAttribute]
    public class EmpresaController : Controller
    {
        // GET: Empresa
        public ActionResult Index()
        {
            using (AdministracionService.AdministracionClient servicio = new AdministracionService.AdministracionClient())
            {
                List<Empresa> empresas = new List<Empresa>();
                empresas = servicio.ObtenerEmpresas();
                List<Ciudad> ciudades = new List<Ciudad>();
                using (ComunService.ComunClient comServ = new ComunService.ComunClient())
                { 
                    ciudades.AddRange(comServ.ObtenerCiudadPorEmpresas(empresas));
                }
                ViewBag.Ciudades = ciudades;
                return View(empresas);
            }
        }

        // GET: Empresa/Details/5
        public ActionResult Details(int id)
        {
            using (AdministracionService.AdministracionClient servicio = new AdministracionService.AdministracionClient())
            {
                Empresa empresa = new Empresa();
                empresa.IdEmpresa = id;
                empresa = servicio.ObtenerEmpresaPorId(empresa);
                using(ComunService.ComunClient comService = new ComunService.ComunClient())
                {
                    ViewBag.TipoDocumento = comService.ObtenerTiposIdentificacion().Find(ti => ti.IdTipoIdentificacion == empresa.IdTipoIdentificacion).Nombre;
                    ViewBag.Ciudad = comService.ObtenerCiudadPorIdCiudad(new Ciudad(empresa.IdCiudad)).Nombre;
                }
                return View(empresa);
            }
        }

        // GET: Empresa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empresa/Create
        [HttpPost]
        [OnlyAjaxRequestAttribute]
        public JsonResult Create(Empresa pEmpresa, HttpPostedFileBase file = null)
        {
            pEmpresa.FechaRegistro = DateTime.Now;
            pEmpresa.Activo = true;
            if(ModelState.IsValid)
            {
                using (AdministracionService.AdministracionClient servicio = new AdministracionService.AdministracionClient())
                {
                    ResponseModel mResponse = new ResponseModel();

                    if (file != null)
                        ProcesarImagenes(pEmpresa, file, mResponse);
                    else
                    {
                        pEmpresa.UrlImagen1 = string.IsNullOrEmpty(pEmpresa.UrlImagen1) ? "~/Uploads/no-photo.jpg" : pEmpresa.UrlImagen1;
                        pEmpresa.UrlImagen2 = string.IsNullOrEmpty(pEmpresa.UrlImagen2) ? "~/Uploads/no-photo.jpg" : pEmpresa.UrlImagen2;
                        pEmpresa.UrlImagen3 = string.IsNullOrEmpty(pEmpresa.UrlImagen3) ? "~/Uploads/no-photo.jpg" : pEmpresa.UrlImagen3;
                    }

                    if (servicio.RegistrarEmpresa(pEmpresa) == true)
                    {
                        mResponse.SetResponse(true);
                        mResponse.href = "empresa/index";

                        return Json(mResponse);
                    }
                    else
                        return Json(new { Response = false, message = "Ocurrio un error con el registro de Empresa, intente nuevamente" });
                }
            }
            else
                return Json(new { Response = false, message = "Ocurrio un error con la validacion del formulario" }); 
        }

        private static void ProcesarImagenes(Empresa pEmpresa, HttpPostedFileBase file, ResponseModel mResponse)
        {
            var rpta = ImageHelper.TryParse(file, 500);

            if (rpta != "")
            {
                mResponse.SetResponse(false, rpta);
                throw new Exception(rpta);
            }

            ImageHelper imghelper = new ImageHelper();
            string nombre = ViewHelper.getNameForFiles(pEmpresa) + System.IO.Path.GetExtension(file.FileName);
            string ruta = System.Web.HttpContext.Current.Server.MapPath("~/Uploads/" + nombre);

            file.SaveAs(ruta);

            imghelper.Path = System.Web.HttpContext.Current.Server.MapPath("~/Uploads/");
            imghelper.Img = nombre;
            imghelper.Scales = new int[] { 500, 300, 100 };
            imghelper.resizes();

            List<string> imagenes = imghelper.getNewImages();

            pEmpresa.UrlImagen1 = "~/Uploads/" + imagenes[0];
            pEmpresa.UrlImagen2 = "~/Uploads/" + imagenes[1];
            pEmpresa.UrlImagen3 = "~/Uploads/" + imagenes[2];
        }
         
        // GET: Empresa/Edit/5
        public ActionResult Edit(int id)
        {
            using (AdministracionService.AdministracionClient servicio = new AdministracionService.AdministracionClient())
            {
                Empresa empresa = new Empresa();
                empresa.IdEmpresa = id;
                empresa = servicio.ObtenerEmpresaPorId(empresa);
                using (ComunService.ComunClient comService = new ComunService.ComunClient())
                { 
                    ViewBag.Ciudad = comService.ObtenerCiudadPorIdCiudad(new Ciudad(empresa.IdCiudad)).Nombre;
                }
                return View(empresa);
            }
        }

        // POST: Empresa/Edit/5
        [HttpPost]
        [OnlyAjaxRequestAttribute]
        public ActionResult Edit(Empresa pEmpresa, HttpPostedFileBase file = null)
        {  
            if (ModelState.IsValid)
            {
                using (AdministracionService.AdministracionClient servicio = new AdministracionService.AdministracionClient())
                {
                    ResponseModel mResponse = new ResponseModel();

                    if (file != null)
                        ProcesarImagenes(pEmpresa, file, mResponse);
                    else
                    {
                        pEmpresa.UrlImagen1 = string.IsNullOrEmpty(pEmpresa.UrlImagen1) ? "~/Uploads/no-photo.jpg" : pEmpresa.UrlImagen1;
                        pEmpresa.UrlImagen2 = string.IsNullOrEmpty(pEmpresa.UrlImagen2) ? "~/Uploads/no-photo.jpg" : pEmpresa.UrlImagen2;
                        pEmpresa.UrlImagen3 = string.IsNullOrEmpty(pEmpresa.UrlImagen3) ? "~/Uploads/no-photo.jpg" : pEmpresa.UrlImagen3;
                    }

                    if (servicio.ActualizarEmpresa(pEmpresa) == true)
                    {
                        mResponse.SetResponse(true);
                        mResponse.href = "empresa/index";

                        return Json(mResponse);
                    }
                    else
                        return Json(new { Response = false, message = "Ocurrio un error con el registro de Empresa, intente nuevamente" });
                }
            }
            else
                return Json(new { Response = false, message = "Ocurrio un error con la validacion del formulario" }); 
        }
          
        public ActionResult Delete(int id)
        {
            using(AdministracionService.AdministracionClient servicio = new AdministracionService.AdministracionClient())
            {
                Empresa emp = new Empresa();
                emp.IdEmpresa = id;
                if (servicio.EliminarEmpresa(emp) == true)
                    return RedirectToAction("Index");
                else
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}
