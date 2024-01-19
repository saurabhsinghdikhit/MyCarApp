using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCarApp.BE.BussinessEntities;

namespace MyCarApp.DAL.Repository.Interfaces
{
    public interface IAddressRepository
    {
        Database.Address Add(Address address);
    }
}
