using System.Web.Mvc;

namespace MyCarApp.MVC.Areas.AdminScreen
{
    public class AdminScreenAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminScreen";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminScreen_default",
                "AdminScreen/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}