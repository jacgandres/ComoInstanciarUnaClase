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

        public ActionResult Details(int id)
        {
            using (AdministraionService.AdministracionClient servicio = new AdministraionService.AdministracionClient())
            {
                Usuario user = new Usuario();
                user.IdUsuario = id;
                user = servicio.ObtenerUsuarioPorId(user);

                return View(user);
            }
        }

        public ActionResult Create()
        {
            using (AdministraionService.AdministracionClient servicio = new AdministraionService.AdministracionClient())
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
            pUser.FechaUltimoRegistro = DateTime.Now;
            if (ModelState.IsValid == true)
            {
                using (AdministraionService.AdministracionClient servicio = new AdministraionService.AdministracionClient())
                {
                    ResponseModel mResponse = new ResponseModel();

                    if (file != null)
                    {
                        var rpta = ImageHelper.TryParse(file, 500);

                        if (rpta != "")
                        {
                            mResponse.SetResponse(false, rpta);
                            throw new Exception(rpta);
                        }

                        ImageHelper imghelper = new ImageHelper();
                        string nombre = ViewHelper.getNameForFiles() + System.IO.Path.GetExtension(file.FileName);
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
    
    
    }
}