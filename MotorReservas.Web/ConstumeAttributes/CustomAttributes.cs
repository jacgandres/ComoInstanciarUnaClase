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
                if (HttpContext.Current.Session["Roles"] == null)
                {
                    AdministraionService.AdministracionClient servicio = new AdministraionService.AdministracionClient();
                    Usuario usr = new Usuario();
                    usr.IdUsuario = SessionHelper.GetUser();
                    HttpContext.Current.Session["Roles"] = servicio.ObtenerModulosRolPorUsuario(usr);
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
                filterContext.HttpContext.Response.Write("Acceso no permitido.");
                filterContext.HttpContext.Response.End();
            }
        }
    }

}