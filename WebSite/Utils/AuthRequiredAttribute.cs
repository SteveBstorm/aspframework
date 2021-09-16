using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebSite.Utils
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)] //Définit que l'attribut pourra être utiliser avec Classe et Méthode
    public class AuthRequiredAttribute : AuthorizeAttribute //Attribut de base à surcharger pour gérer les autorisations
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext) //Surcharge de la méthode permettant de définir sur quoi se base l'autorisation à donner
        {
            return SessionTool.user != null;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) // Comportement en cas d'autorisation rejetée
        {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Home", Action = "Login" }));
        }
    }

}