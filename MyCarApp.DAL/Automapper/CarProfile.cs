using AutoMapper;
using MyCarApp.BE.BussinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.DAL.Automapper
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Database.Car, Car>();
        }
    }
}
