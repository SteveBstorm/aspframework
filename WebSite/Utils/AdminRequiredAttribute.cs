using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebSite.Utils
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)] // nous permet de définir que notre attribut pourra affecter des classes et des méthodes
    public class AdminRequiredAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext) //nous vérifions si le UserSession est différent de null
        {
            return SessionTool.user != null && SessionTool.user.isAdmin;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) //Redirige vers une autre action si non-autorisé
        {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "./../Home", Action = "Index" }));
        }
    }
}