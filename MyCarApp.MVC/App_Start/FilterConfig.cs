using MyCarApp.MVC.Filters.UserIdentityFilter;
using System.Web;
using System.Web.Mvc;

namespace MyCarApp.MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
