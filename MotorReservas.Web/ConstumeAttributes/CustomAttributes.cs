using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Helper;
using MotorReservas.Entidad;

namespace MotorReservas.Web.ConstumeAttributes
{
    public class IfNotLoggedActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (!SessionHelper.ExistUserInSession())
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Login",
                    action = "Index"
                }));
            }
        }
    }
    public class IfLoggedActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (SessionHelper.ExistUserInSession())
            {
                if (HttpContext.Current.Session["modulos"] == null)
                {
                    AdministracionService.AdministracionClient servicio = new AdministracionService.AdministracionClient();
                    Usuario usr = new Usuario();
                    usr.IdUsuario = SessionHelper.GetUser();
                    HttpContext.Current.Session["modulos"] = servicio.ObtenerModulosRolPorUsuario(usr);
                }
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "home",
                    action = "Index"
                }));
            }
        }
    }
    public class OnlyAjaxRequestAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAjaxRequest())
            {
                SessionHelper.DestroyUserSession();
                filterContext.HttpContext.Response.Write("Acceso no permitido.");
                filterContext.HttpContext.Response.End();
            }
        }
    }

    public class IsAuthorizated : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (ValidacionModulos(filterContext) == false)
            {
                HttpContext.Current.Session["NoAutorizado"] = true;
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "home",
                    action = "Index"
                }));
            }
        }

        private bool ValidacionModulos(ActionExecutingContext pFilterContext)
        {
            List<Modulo> modulos = (List<Modulo>)HttpContext.Current.Session["modulos"];
            if (modulos == null)
                return false;
            else if (modulos.Count < 1)
                return false;
            else
            {
                foreach (Modulo mod in modulos)
                {
                    if (mod.Controlador.Contains("*"))
                        return true;
                    else
                    {
                        if (mod.Controlador.ToUpper().Trim().Contains(((pFilterContext.ActionDescriptor).ControllerDescriptor).ControllerName.ToUpper().Trim()))
                            return true;
                    }
                }

                return false;
            }
        }
    }
}