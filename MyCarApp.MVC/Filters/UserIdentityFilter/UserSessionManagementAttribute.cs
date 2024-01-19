using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyCarApp.MVC.Filters.UserIdentityFilter
{
    public class UserSessionManagementAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.Contents["token"] == null)
            {
                RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
                redirectTargetDictionary.Add("action", "LoginPage");
                redirectTargetDictionary.Add("controller", "User");
                redirectTargetDictionary.Add("area", "");
                filterContext.Result = new RedirectToRouteResult(redirectTargetDictionary);
            }
            base.OnActionExecuting(filterContext);
        }
    }
}