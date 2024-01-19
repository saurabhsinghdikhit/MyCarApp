using MyCarApp.DAL.Repository.Classes;
using MyCarApp.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;
namespace MyCarApp.BAL.HelperClass
{
    public class UnityHelperClass : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IAdminRepository, AdminRepository>();
            Container.RegisterType<ICarRepository, CarRepository>();
            Container.RegisterType<IUserRepository, UserRepository>();
            Container.RegisterType<ISupportRepository,SupportRepository>();
            Container.RegisterType<IAddressSupportRepository,AddressSupportRepository>();
            Container.RegisterType<ITransactionRepository, TransactionRepository>();
            Container.RegisterType<IChartRepository, ChartRepository>();
        }
    }
}
