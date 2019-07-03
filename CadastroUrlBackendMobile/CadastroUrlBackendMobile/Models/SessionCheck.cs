using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UrlBackendMobile.Models
{
    public class SessionCheck : ActionFilterAttribute, IActionFilter
    {
        private static HttpContext _context { get { return HttpContext.Current; } }

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            var usuariologado = Cookie.Get("usuariologado");

            if (usuariologado == "")
            {
                //filterContext.Result = new RedirectResult("/Home/Login");
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new
                        {
                            controller = "Home",
                            action = "Login"
                        })
               );
            }
        }
    }
}