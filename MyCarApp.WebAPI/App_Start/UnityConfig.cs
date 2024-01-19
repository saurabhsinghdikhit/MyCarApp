using MyCarApp.BAL.Classes;
using MyCarApp.BAL.HelperClass;
using MyCarApp.BAL.Interfaces;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace MyCarApp.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            
            container.RegisterType<IAdminManager, AdminManager>();
            container.RegisterType<ICarManager, CarManager>();
            container.RegisterType<IUserManager, UserManager>();
            container.RegisterType<ISupportManager, SupportManager>();
            container.RegisterType<IAddressSupportManager, AddressSupportManager>();
            container.RegisterType<IChartManager, ChartManager>();
            container.RegisterType<ITransactionManager, TransactionManager>();
            container.AddNewExtension<UnityHelperClass>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}