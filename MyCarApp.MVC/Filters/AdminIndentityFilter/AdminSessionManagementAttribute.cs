using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyCarApp.MVC.Filters.AdminIndentityFilter
{
    public class AdminSessionManagementAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.Contents["token"] == null)
            {
                RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
                redirectTargetDictionary.Add("action", "Login");
                redirectTargetDictionary.Add("controller", "Admin");
                redirectTargetDictionary.Add("area", "AdminScreen");
                filterContext.Result = new RedirectToRouteResult(redirectTargetDictionary);
            }
            base.OnActionExecuting(filterContext);
        }
    }
}