using BlnckProyect.Models.ErrorHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace BlnckProyect.Infrastructure.Filters
{
    //protect post, only have to be authenticated
    //[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ProtectPostAttribute : FilterAttribute, IAuthorizationFilter
    {
        private string UseAFT;
        public ProtectPostAttribute(string useAFT = "Yes")
        {
            UseAFT = useAFT;
        }
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            var httpContext = filterContext.HttpContext;

            if (UseAFT.Equals("yes", StringComparison.InvariantCultureIgnoreCase))
                try
                {
                    var cookie = httpContext.Request.Cookies[AntiForgeryConfig.CookieName];
                    AntiForgery.Validate(cookie != null ? cookie.Value : null, httpContext.Request.Headers["__RequestVerificationToken"]);
                }
                catch (Exception)
                {
                    filterContext.Result = new JsonResult
                    {
                        Data = new { error =  new { code = "405", message = "El sitio ha rechazado tu petición" } }
                    };
                }

            if (filterContext.Result == null)
            {
                //var controller = filterContext.RouteData.Values["controller"].ToString();
                //controller.GetSessionName()
                if (filterContext.HttpContext.Session["nameSession"] == null)
                {
                    filterContext.Result = new JsonResult
                    {
                        Data = new { codError = "401", mensaje = "Tu session ha expirado" }
                    };
                }
            }
        }
    }


    //protect get, only have to be authenticated
    public class ProtectGetAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //var controller = filterContext.RouteData.Values["controller"].ToString();
            //controller.GetSessionName()
            if (filterContext.HttpContext.Session["sessionName"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    { "controller", "ErrorHandler" },
                    { "action", "Notificacion" },
                    { "id", "401" }
                });
            }
        }
    }

    //protect controller
    public class AuthenticationAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["NameSession"])))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                //Redirecting the user to the Login View of Account Controller  
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                     { "controller", "Account" },
                     { "action", "Login" }
                });
            }
        }
    }

    //potect http method by role
    public class AllowedRolesAttribute : AuthorizeAttribute
    {
        public string UseAFT { get; set; } = "YES";
        private readonly string[] allowedroles;
        string httpVerb = HttpContext.Current.Request.HttpMethod.ToUpper();
        public AllowedRolesAttribute(params string[] roles)
        {
            this.allowedroles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var userId = Convert.ToString(httpContext.Session["SessionName"]);
            //convert to class
            if(allowedroles != null && allowedroles.Length > 0)
                return Array.Exists(allowedroles, x => x == "SessionClass.role");
            return true;
        }
        
        public override void  OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            var httpContext = filterContext.HttpContext;

            if (UseAFT.ToUpper() == "YES" && httpVerb == "POST")
                try
                {
                    var cookie = httpContext.Request.Cookies[AntiForgeryConfig.CookieName];
                    AntiForgery.Validate(cookie != null ? cookie.Value : null, httpContext.Request.Headers["__RequestVerificationToken"]);
                }
                catch (Exception)
                {
                    filterContext.Result = new JsonResult
                    {
                        Data = new { error = new { code = "405", message = "El sitio ha rechazado tu petición" } }
                    };
                }
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if(httpVerb == "GET")
            filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                    { "controller", "Home" },
                    { "action", "UnAuthorized" }
               });
            else
                filterContext.Result = new JsonResult
                {
                    Data = new {   error = new { code = "401", message = "No tienes los permisos necesarios" } }
                };
        }
    }

    //var param = filterContext.HttpContext.Request.Params["aplicacion"]; param = param.ToLower();
    //var token = filterContext.HttpContext.Request.Params["token"];
}