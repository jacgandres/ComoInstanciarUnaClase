﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Helper;

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
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Inicio",
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