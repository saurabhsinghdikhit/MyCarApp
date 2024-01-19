using AutoMapper;
using MyCarApp.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.DAL
{
    public class automapperConfig
    {
        public static MapperConfiguration CarToDbCarconfig = new MapperConfiguration(cfg => cfg.CreateMap<Car, Database.Car>());
        public static MapperConfiguration DbCarToCarconfig = new MapperConfiguration(cfg => cfg.CreateMap<Database.Car, Car>());
    }
}
