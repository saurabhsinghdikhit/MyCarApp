using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyCarApp.BE.BussinessEntities;
using MyCarApp.DAL.Repository.Interfaces;

namespace MyCarApp.DAL.Repository.Classes
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DAL.Database.MyCarDBEntities _dbContext;

        public AddressRepository()
        {
            _dbContext = new Database.MyCarDBEntities();
        }

        /// <summary>
        /// Add address in the address table
        /// </summary>
        /// <param name="address"></param>
        /// <returns>Adds address</returns>
        public Database.Address Add(Address address)
        {
            var pincode = _dbContext.Pincodes.Where(x => x.Pincode1 == address.Pincode.Pincode1).FirstOrDefault();
            var country = _dbContext.Countries.Where(x => x.CountryName == address.Pincode.City.State.Country.CountryName).FirstOrDefault();
            var state = _dbContext.States.Where(x => x.StateName == address.Pincode.City.State.StateName).FirstOrDefault();
            var city = _dbContext.Cities.Where(x => x.CityName == address.Pincode.City.CityName).FirstOrDefault();


            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Database.Address, Address>();
            });
            var mapper = config.CreateMapper();
            var add = mapper.Map<Database.Address>(address);


            if (country == null)
            {
                var config3 = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Database.Country, Country>();
                });
                var mapper3 = config3.CreateMapper();
                var record3 = mapper3.Map<Database.Country>(address.Pincode.City.State.Country);
                record3.CountryId = Guid.NewGuid();


                add.Pincode.City.State.Country = record3;
                add.Pincode.City.State.Country.CountryId = record3.CountryId;

                //_dbcontext.countries.add(record3);
                //_dbcontext.savechanges();
            }
            else
            {
                add.Pincode.City.State.Country.CountryId = country.CountryId;
                add.Pincode.City.State.Country = null;
            }

            if (state == null)
            {
                var config1 = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Database.State, State>();
                });
                var mapper1 = config1.CreateMapper();
                var record1 = mapper1.Map<Database.State>(address.Pincode.City.State);
                record1.StateId = Guid.NewGuid();
                record1.CountryId = add.Pincode.City.State.Country.CountryId;

                add.Pincode.City.State = record1;
                add.Pincode.City.State.StateId= record1.StateId;

                //_dbContext.States.Add(record1);
                //_dbContext.SaveChanges();
            
            }
            else
            {
                add.Pincode.City.State.StateId = state.StateId;
                add.Pincode.City.State = null;
            }

            if (city == null)
            {
                var config2 = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Database.City, City>();
                });
                var mapper2 = config2.CreateMapper();
                var record2 = mapper2.Map<Database.City>(address.Pincode.City);
                record2.CityId = Guid.NewGuid();
                record2.StateId= add.Pincode.City.State.StateId;

                add.Pincode.City = record2;
                add.Pincode.City.CityId = record2.CityId;

                //_dbContext.Cities.Add(record2);
                //_dbContext.SaveChanges();
            }
            else
            {
                add.Pincode.City.CityId = city.CityId;
                add.Pincode.City = null;
            }


            if (pincode==null)
            {
                var config4 = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Database.Pincode, Pincode>();
                });
                var mapper4 = config4.CreateMapper();
                var record4 = mapper4.Map<Database.Pincode>(address.Pincode);
                record4.PincodeId = Guid.NewGuid();
                record4.CityId = add.Pincode.City.CityId;

                add.Pincode = record4;
                add.PincodeId = record4.PincodeId;

                //_dbContext.Pincodes.Add(record4);
                //_dbContext.SaveChanges();
            }
            else
            {
                add.PincodeId = pincode.PincodeId;
                add.Pincode = null;
            }


            //var config = new mapperconfiguration(cfg =>
            //{
            //    cfg.createmap<database.address, address>();
            //});
            //var mapper = config.createmapper();
            //var record = mapper.map<database.address>(address);
            //record.AddressId = Guid.NewGuid();
            //record.StateId = stateId;
            //record.CountryId = countryId;
            //record.CityId = cityId;
            //record.PincodeId = pincodeId;
            add.AddressId = Guid.NewGuid();
            //_dbContext.Addresses.Add(add);
            //_dbContext.SaveChanges();
            return add;

        }
    }
}
