using AutoMapper;
using MyCarApp.BE.BussinessEntities;
using MyCarApp.BE.ViewModels;
using MyCarApp.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.DAL.Repository.Classes
{
    public class AddressSupportRepository : IAddressSupportRepository
    {
        private readonly Database.MyCarDBEntities _dbContext;
        public AddressSupportRepository()
        {
            _dbContext = new Database.MyCarDBEntities();
        }

        /// <summary>
        /// Add address of car details
        /// </summary>
        /// <param name="addressVM"></param>
        /// <returns></returns>
        public bool AddAddress(CarDetails addressVM)
        {
            try
            {
                Database.Car car = _dbContext.Cars.Where(x => x.Id == addressVM.CarId).FirstOrDefault();
                if (car == null)
                {
                    return false;
                }
                var id = Guid.NewGuid();
                Database.Address address = new Database.Address()
                {
                    AddressId = id,
                    LocalAddress = addressVM.LocalAddress,
                    PincodeId = addressVM.PincodeId
                };
                _dbContext.Addresses.Add(address);
                _dbContext.SaveChanges();

                car.AddressId = id;
                _dbContext.Cars.AddOrUpdate(car);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Shows cities of a particular state
        /// </summary>
        /// <param name="StateId"></param>
        /// <returns>List of cities</returns>
        public IEnumerable<City> GetCities(Guid StateId)
        {
            IEnumerable<Database.City> entities = _dbContext.Cities.Where(x => x.StateId == StateId).ToList();
            List<City> cities = new List<City>();

            foreach (var item in entities)
            {
                City city = new City();
                city.CityId= item.CityId;
                city.CityName= item.CityName;
                cities.Add(city);
            }
            return cities;
        }

        /// <summary>
        /// Shows countries
        /// </summary>
        /// <returns>List of all countries</returns>
        public IEnumerable<Country> GetCountries()
        {
            IEnumerable<Database.Country> entities = _dbContext.Countries.ToList();
            List<Country> countries = new List<Country>();

            foreach (var item in entities)
            {
                Country country = new Country();
                country.CountryId = item.CountryId;
                country.CountryName = item.CountryName;
                countries.Add(country);
            }
            return countries;
        }

        /// <summary>
        /// Shows pincodes of selected city
        /// </summary>
        /// <param name="CityId"></param>
        /// <returns>List of pincodes</returns>
        public IEnumerable<Pincode> GetPincodes(Guid CityId)
        {
            IEnumerable<Database.Pincode> entities = _dbContext.Pincodes.Where(x => x.CityId == CityId).ToList();
            List<Pincode> pincodes = new List<Pincode>();

            foreach (var item in entities)
            {
                Pincode pincode = new Pincode();
                pincode.PincodeId = item.PincodeId;
                pincode.Pincode1 = item.Pincode1;
                pincodes.Add(pincode);
            }
            return pincodes;
        }

        /// <summary>
        /// Shows all states of selected country
        /// </summary>
        /// <param name="CountryId"></param>
        /// <returns>List of states</returns>
        public IEnumerable<State> GetStates(Guid CountryId)
        {
            IEnumerable<Database.State> entities = _dbContext.States.Where(x => x.CountryId == CountryId).ToList();
            List<State> states = new List<State>();

            foreach (var item in entities)
            {
                State state = new State();
                state.StateId = item.StateId;
                state.StateName= item.StateName;
                states.Add(state);
            }
            return states;
        }

        /// <summary>
        /// Check Pincode Availability
        /// </summary>
        /// <param name="pincode">Pincode</param>
        /// <returns>Available or Not</returns>
        public bool AddressCheckAvail(string pincode)
        {
            int pincodeInt = int.Parse(pincode);
            var check = _dbContext.Pincodes.Where(x => x.Pincode1 == pincodeInt).FirstOrDefault();
            if(check==null)
            {
                return false;
            }
            return true;
        }
    }
}
