using MyCarApp.BE.BussinessEntities;
using MyCarApp.BE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.DAL.Repository.Interfaces
{
    public interface IAddressSupportRepository
    {
        IEnumerable<Country> GetCountries();
        IEnumerable<State> GetStates(Guid CountryId);
        IEnumerable<City> GetCities(Guid StateId);
        IEnumerable<Pincode> GetPincodes(Guid CityId);
        bool AddAddress(CarDetails addressVM);
        bool AddressCheckAvail(string pincode);

    }
}
