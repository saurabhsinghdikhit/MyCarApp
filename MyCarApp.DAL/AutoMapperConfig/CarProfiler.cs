using AutoMapper;
using MyCarApp.BE.BussinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.DAL.AutoMapperConfig
{
    public class CarProfiler : Profile
    {
        public CarProfiler()
        {
            CreateMap<Database.Car, Car>()
                .ForMember(x => x.Address, y => y.Ignore())
                .ForMember(x => x.CarVarients, y => y.Ignore())
                .MaxDepth(1)
                .PreserveReferences();
        }
    }
}
