using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helper;
using MotorReserva.Entidad;
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
            using (AdministracionService.AdministracionClient servicio = new AdministracionService.AdministracionClient())
            {
                List<Usuario> usuarios = new List<Usuario>();

                usuarios = servicio.ListarUsuarios();

                return View(usuarios);
            }
        }

        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession();
            Session.Remove("Roles");
            return Redirect("~");
        }

        public ActionResult Details(int id)
        {
            using (AdministracionService.AdministracionClient servicio = new AdministracionService.AdministracionClient())
            {
                Usuario user = new Usuario();
                user.IdUsuario = id;
                user = servicio.ObtenerUsuarioPorId(user);
                ViewBag.Empresa = (from empr in servicio.ObtenerEmpresas()
                                   where empr.IdEmpresa == user.IdEmpresa
                                   select empr).FirstOrDefault();
                return View(user);
            }
        }

        public ActionResult Create()
        {
            using (AdministracionService.AdministracionClient servicio = new AdministracionService.AdministracionClient())
            {
                ViewBag.Empresas = servicio.ObtenerEmpresas();
                return View();
            }
        }

        [HttpPost]
        [OnlyAjaxRequestAttribute]
        public JsonResult CreateUser(Usuario pUser, HttpPostedFileBase file = null)
        {
            pUser.FechaRegistro = DateTime.Now;
            pUser.FechaUltimaSesion = DateTime.Now;
            if (ModelState.IsValid == true)
            {
                using (AdministracionService.AdministracionClient servicio = new AdministracionService.AdministracionClient())
                {
                    ResponseModel mResponse = new ResponseModel();

                    if (file != null)
                        ProcesarImagenes(pUser, file, mResponse);

                    if (servicio.RegistrarUsuario(pUser) == true)
                    {
                        mResponse.SetResponse(true);
                        mResponse.href = "usuario/index";

                        return Json(mResponse);
                    }
                    else
                        return Json(new { Response = false, message = "Ocurrio un error con el registro de Usuario, intente nuevamente" });
                }
            }
            else
                return Json(new { Response = false, message = "Ocurrio un error con la validacion del formulario" });
        }

        public ActionResult Delete(int id)
        {
            using (AdministracionService.AdministracionClient servicio = new AdministracionService.AdministracionClient())
            {
                Usuario user = new Usuario();
                user.IdUsuario = id;
                if (servicio.EliminarUsuario(user) == true)
                    return RedirectToAction("Index");
                else
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
        }

        public ActionResult Edit(int id)
        {
            using (AdministracionService.AdministracionClient cliente = new AdministracionService.AdministracionClient())
            {
                Usuario user = new Usuario();
                user.IdUsuario = id;
                user = cliente.ObtenerUsuarioPorId(user);
                ViewBag.Empresas = cliente.ObtenerEmpresas();

                user.Clave = "";
                return View(user);
            }
        }

        [HttpPost]
        [OnlyAjaxRequestAttribute]
        public JsonResult UpdateUser(Usuario pUser, HttpPostedFileBase file = null)
        {
            if (string.IsNullOrEmpty(pUser.Clave) == true)
                ModelState.Remove("Clave");
            else
                pUser.Clave = Helper.HashHelper.MD5(pUser.Clave);

            if (ModelState.IsValid == true)
            {
                using (AdministracionService.AdministracionClient servicio = new AdministracionService.AdministracionClient())
                {
                    ResponseModel mResponse = new ResponseModel();

                    if (file != null)
                        ProcesarImagenes(pUser, file, mResponse);


                    if (servicio.ActualizarUsuario(pUser) == true)
                    {
                        mResponse.SetResponse(true);
                        mResponse.href = "usuario/index";

                        return Json(mResponse);
                    }
                    else
                        return Json(new { Response = false, message = "Ocurrio un error con el registro de Usuario, intente nuevamente" });
                }
            }
            else
                return Json(new { Response = false, message = "Ocurrio un error con la validacion del formulario" });
        }

        private static void ProcesarImagenes(Usuario pUser, HttpPostedFileBase file, ResponseModel mResponse)
        {
            var rpta = ImageHelper.TryParse(file, 500);

            if (rpta != "")
            {
                mResponse.SetResponse(false, rpta);
                throw new Exception(rpta);
            }

            ImageHelper imghelper = new ImageHelper();
            string nombre = ViewHelper.getNameForFiles(pUser) + System.IO.Path.GetExtension(file.FileName);
            string ruta = System.Web.HttpContext.Current.Server.MapPath("~/Uploads/" + nombre);

            file.SaveAs(ruta);

            imghelper.Path = System.Web.HttpContext.Current.Server.MapPath("~/Uploads/");
            imghelper.Img = nombre;
            imghelper.Scales = new int[] { 500, 300, 100 };
            imghelper.resizes();

            List<string> imagenes = imghelper.getNewImages();

            pUser.UrlImagen1 = "~/Uploads/" + imagenes[0];
            pUser.UrlImagen2 = "~/Uploads/" + imagenes[1];
            pUser.UrlImagen3 = "~/Uploads/" + imagenes[2];
        }

        public ActionResult UsuarioRoles(int id)
        {
            using (AdministracionService.AdministracionClient cliente = new AdministracionService.AdministracionClient())
            {
                Usuario user = new Usuario();
                user.IdUsuario = id;
                List<Rol> roles = cliente.ObtenerRolesPorUsuario(user);
                ViewBag.IdUsuario = id;
                return View(roles);
            }
        }

        public ActionResult CreateRolToUser(int idUsuario)
        {
            using (AdministracionService.AdministracionClient cliente = new AdministracionService.AdministracionClient())
            {
                ViewBag.Roles = cliente.ListarRoles();
                Usuario_Tiene_Rol rolUsuario = new Usuario_Tiene_Rol();

                rolUsuario.IdUsuario = idUsuario;
                rolUsuario.Activo = true;
                rolUsuario.FechaRegistro = DateTime.Now;
                rolUsuario.IdRol = 0;
                return View(rolUsuario);
            }
        }

        [HttpPost]
        [OnlyAjaxRequestAttribute]
        public JsonResult SaveRolToUser(Usuario_Tiene_Rol pUsuario)
        {
            if (ModelState.IsValid == true)
            {
                using (AdministracionService.AdministracionClient cliente = new AdministracionService.AdministracionClient())
                {
                    if (cliente.VerificarUsuarioTieneRol(pUsuario) == true)
                    {
                        if (cliente.IngresarRolUsuario(pUsuario) == true)
                        {
                            ResponseModel mResponse = new ResponseModel();
                            mResponse.SetResponse(true);
                            mResponse.message = "El rol para el Usuario ha sido correctamente asignado.";
                            return Json(mResponse);
                        }
                        else
                            return Json(new { Response = false, message = "Ocurrio un error con la validacion del formulario" });
                    }
                    else
                        return Json(new { Response = false, message = "El usuario ya tiene asignado ese rol" });
                }
            }
            else
                return Json(new { Response = false, message = "Ocurrio un error con la validacion del formulario" });
        }

        public ActionResult DeleteRolToUser(int id, int idUsuario)
        {
            using (AdministracionService.AdministracionClient servicio = new AdministracionService.AdministracionClient())
            {
                Usuario_Tiene_Rol usuarioRol = new Usuario_Tiene_Rol();
                usuarioRol.IdRol = id;
                usuarioRol.IdUsuario = idUsuario;

                if (servicio.EliminarRolUsuario(usuarioRol) == true)
                {
                    return RedirectToAction("UsuarioRoles", new { id = idUsuario });
                }
                else
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}