using MyCarApp.BAL.Interfaces;
using MyCarApp.BE.BussinessEntities;
using MyCarApp.BE.ViewModels;
using MyCarApp.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.BAL.Classes
{
    public class AddressSupportManager : IAddressSupportManager
    {
        private readonly IAddressSupportRepository _addressSupportRepository;

        public AddressSupportManager(IAddressSupportRepository addressSupportRepository)
        {
            _addressSupportRepository = addressSupportRepository;
        }

        public bool AddAddress(CarDetails addressVM)
        {
            return _addressSupportRepository.AddAddress(addressVM);
        }

        public bool AddressCheckAvail(string pincode)
        {
            return _addressSupportRepository.AddressCheckAvail(pincode);
        }

        public IEnumerable<City> GetCities(Guid StateId)
        {
            return _addressSupportRepository.GetCities(StateId);
        }

        public IEnumerable<Country> GetCountries()
        {
            return _addressSupportRepository.GetCountries();
        }

        public IEnumerable<Pincode> GetPincodes(Guid CityId)
        {
            return _addressSupportRepository.GetPincodes(CityId);
        }

        public IEnumerable<State> GetStates(Guid CountryId)
        {
            return _addressSupportRepository.GetStates(CountryId);
        }


   
    }
}
