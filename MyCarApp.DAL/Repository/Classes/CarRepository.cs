using AutoMapper;
using MyCarApp.BE.BussinessEntities;
using MyCarApp.BE.ViewModels;
using MyCarApp.DAL.AutoMapperConfig;
using MyCarApp.DAL.Repository.Interfaces;
//using MyCarApp.DAL.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.DAL.Repository.Classes
{
    public class CarRepository : ICarRepository
    {
        private readonly Database.MyCarDBEntities _dbContext;

        public CarRepository()
        {
            _dbContext = new Database.MyCarDBEntities();
        }

        /// <summary>
        /// Adding a car
        /// </summary>
        /// <param name="car"></param>
        /// <returns>Adds car to database</returns>
        public bool Add(Car car)
        {
            try
            {
                if (car != null)
                {
                    Database.Car entity = new Database.Car();

                    var config1 = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Database.CarVarient, CarVarient>();
                    });

                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Database.Car, Car>().ForMember(dest => dest.CarVarients, opt => opt.Ignore());
                    });
                    config.AssertConfigurationIsValid();

                    var mapper = config.CreateMapper();
                    var mapper1 = config1.CreateMapper();

                    entity = mapper.Map<Database.Car>(car);
                    entity.Id = Guid.NewGuid();
                    _dbContext.Cars.Add(entity);
                    _dbContext.SaveChanges();

                    return true;

                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Adding car varient
        /// </summary>
        /// <param name="varient"></param>
        /// <returns>Adds car varient to database</returns>
        public bool AddVarient(CarVarient varient)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Database.CarVarient, CarVarient>();
                });
                var mapper = config.CreateMapper();
                var entity = mapper.Map<Database.CarVarient>(varient);
                entity.Id = Guid.NewGuid();
                _dbContext.CarVarients.Add(entity);
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Delete a car
        /// </summary>
        /// <param name="Carid"></param>
        /// <returns>Deletes a car</returns>
        public bool Delete(Guid Carid)
        {
            try
            {
                Database.Car car = _dbContext.Cars.Where(c => c.Id == Carid).FirstOrDefault();
                if (car != null)
                {
                    car.IsDeleted = true;
                    _dbContext.SaveChanges();

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }

        }

        /// <summary>
        /// Adding car varient
        /// </summary>
        /// <returns>Adds car varient to database</returns>
        public IEnumerable<Car> GetAll()
        {
            try
            {
                IEnumerable<Database.Car> entities = _dbContext.Cars.Include("CarVarients").Where(x => x.IsDeleted == false && x.Status == false).ToList();
                foreach (var entity in entities)
                {
                    foreach (var varient in entity.CarVarients)
                    {
                        entity.CarVarients = entity.CarVarients.Where(x => x.IsDeleted == false && x.Status == false).ToList();
                    }
                }
                List<Car> cars = new List<Car>();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<CarProfiler>();
                });
                config.AssertConfigurationIsValid();

                var mapper = config.CreateMapper();

                foreach (var entity in entities)
                {
                    Car car = new Car();
                    car = mapper.Map<Car>(entity);
                    List<CarVarient> carVarients = new List<CarVarient>();
                    foreach (var item in entity.CarVarients)
                    {
                        CarVarient carVarient = new CarVarient();
                        carVarient.Image = item.Image;
                        carVarient.Id = item.Id;
                        carVarient.Name = item.Name;
                        carVarient.Price = item.Price;
                        carVarient.carId = item.carId;

                        carVarients.Add(carVarient);
                    }
                    car.CarVarients = carVarients;

                    cars.Add(car);
                }
                return cars;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Showing latest cars
        /// </summary>
        /// <returns>List of latest cars</returns>
        public IEnumerable<Car> LatestCars()
        {
            try
            {
                IEnumerable<Database.Car> entities = _dbContext.Cars.Include("CarVarients").Where(x => x.IsDeleted == false && x.Status == false && x.CarCategory.Category!="Rent").OrderByDescending(x => x.CreatedAt).Take(10).ToList();
                foreach (var entity in entities)
                {
                    foreach (var varient in entity.CarVarients)
                    {
                        entity.CarVarients = entity.CarVarients.Where(x => x.IsDeleted == false && x.Status == false).ToList();
                    }
                }
                List<Car> cars = new List<Car>();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Database.Car, Car>()
                    .ForMember(x => x.Address, y => y.Ignore())
                    .ForMember(x => x.CarVarients, y=> y.Ignore())
                    .MaxDepth(1)
                    .PreserveReferences();
                });
                config.AssertConfigurationIsValid();

                var mapper = config.CreateMapper();

                foreach (var entity in entities)
                {
                    Car car = new Car();
                    car = mapper.Map<Car>(entity);
                    List<CarVarient> carVarients = new List<CarVarient>();
                    foreach (var item in entity.CarVarients)
                    {
                        CarVarient carVarient = new CarVarient();
                        carVarient.Image = item.Image;
                        carVarient.Id = item.Id;
                        carVarient.Name = item.Name;
                        carVarient.Price = item.Price;
                        carVarient.carId = item.carId;

                        carVarients.Add(carVarient);
                    }
                    car.CarVarients = carVarients;
                    cars.Add(car);
                }
                return cars;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Filters top cars according to budget
        /// </summary>
        /// <param name="IsValueForMoney"></param>
        /// <returns>List of top cars</returns>
        public IEnumerable<Car> TopCars(bool IsValueForMoney)
        {
            try
            {
                int take = 10;
                Dictionary<Database.Car, decimal> carPrice = new Dictionary<Database.Car, decimal>();
                Dictionary<Database.Car, double> carRating = new Dictionary<Database.Car, double>();
                Dictionary<Database.Car, double> valueForMoney = new Dictionary<Database.Car, double>();
                double avg = 0;
                int sum = 0, count = 0;
                IEnumerable<Database.Car> entities = _dbContext.Cars.Include("CarVarients").Where(x => x.IsDeleted == false && x.Status == false && x.CarCategory.Category != "Rent").ToList();

                foreach (var entity in entities)
                {
                    sum = 0;
                    IEnumerable<Database.Review> reviews = _dbContext.Reviews.Where(x => x.CarId == entity.Id).ToList();
                    foreach (var review in reviews)
                    {
                        sum += review.Rating;
                    }
                    count = reviews.Count() == 0 ? 1 : reviews.Count();
                    avg = sum / count;
                    List<decimal> pricesOfVariants = new List<decimal>();
                    decimal min = 0;
                    foreach (var varient in entity.CarVarients)
                    {
                        entity.CarVarients = entity.CarVarients.Where(x => x.IsDeleted == false && x.Status == false).ToList();
                        pricesOfVariants.Add(varient.Price);
                    }
                    carRating.Add(entity, avg);
                    min = pricesOfVariants.Min();

                    if (IsValueForMoney)
                    {
                        carPrice.Add(entity, min);
                    }
                }

                List<Car> cars = new List<Car>();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Database.Car, Car>()
                    .ForMember(x => x.CarVarients, y => y.Ignore())
                    .ForMember(x => x.Address, y => y.Ignore())
                    .MaxDepth(1)
                    .PreserveReferences();
                });
                config.AssertConfigurationIsValid();

                List<KeyValuePair<Database.Car, decimal>> myListPrice = new List<KeyValuePair<Database.Car, decimal>>();
                myListPrice.Sort(
                    delegate (KeyValuePair<Database.Car, decimal> firstPair,
                    KeyValuePair<Database.Car, decimal> nextPain)
                    {
                        return firstPair.Value.CompareTo(nextPain.Value);
                    }
                 );

                myListPrice.Reverse();
                myListPrice.Take(take).ToList();

                foreach (var item in carRating)
                {
                    foreach (var item2 in carPrice)
                    {
                        if (item.Key.Id == item2.Key.Id)
                        {
                            valueForMoney.Add(item.Key, item.Value);
                        }
                    }
                }

                List<KeyValuePair<Database.Car, double>> myList = new List<KeyValuePair<Database.Car, double>>(IsValueForMoney == true ? valueForMoney : carRating);
                myList.Sort(
                    delegate (KeyValuePair<Database.Car, double> firstPair,
                    KeyValuePair<Database.Car, double> nextPair)
                    {
                        return firstPair.Value.CompareTo(nextPair.Value);
                    }
                );

                myList.Reverse();
                myList = myList.Take(take).ToList();
                var mapper = config.CreateMapper();

                foreach (var item1 in myList)
                {
                    Car car = new Car();
                    car = mapper.Map<Car>(item1.Key);
                    List<CarVarient> carVarients = new List<CarVarient>();
                    foreach (var item in item1.Key.CarVarients)
                    {
                        CarVarient carVarient = new CarVarient();
                        carVarient.Id = item.Id;
                        carVarient.Image = item.Image;
                        carVarient.Name = item.Name;
                        carVarient.Price = item.Price;
                        carVarient.carId = item.carId;

                        carVarients.Add(carVarient);
                    }
                    car.CarVarients = carVarients;
                    cars.Add(car);
                }

                return cars;
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.InnerException.Message);
                return null;
            }
        }

        /// <summary>
        /// Sort cars by their brand name 
        /// </summary>
        /// <param name="brand"></param>
        /// <returns>List of car selected brand</returns>
        public IEnumerable<Car> GetByBrand(string brand)
        {
            try
            {
                IEnumerable<Database.Car> entities = _dbContext.Cars.Include("CarVarients").Where(x => x.IsDeleted == false && x.Status == false && x.Brand.Equals(brand)).ToList();
                foreach (var entity in entities)
                {
                    foreach (var varient in entity.CarVarients)
                    {
                        entity.CarVarients = entity.CarVarients.Where(x => x.IsDeleted == false && x.Status == false).ToList();
                    }
                }
                //IEnumerable<Database.Car> entities = _dbContext.Cars.ToList();
                List<Car> cars = new List<Car>();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Database.Car, Car>()
                    .ForMember(x => x.CarVarients, y => y.Ignore())
                    .ForMember(x => x.Address, y => y.Ignore())
                    .MaxDepth(1)
                    .PreserveReferences();
                });
                config.AssertConfigurationIsValid();

                var mapper = config.CreateMapper();

                foreach (var entity in entities)
                {
                    Car car = new Car();
                    car = mapper.Map<Car>(entity);
                    List<CarVarient> carVarients = new List<CarVarient>();
                    foreach (var item in entity.CarVarients)
                    {
                        CarVarient carVarient = new CarVarient();
                        carVarient.Image = item.Image;
                        carVarient.Id = item.Id;
                        carVarient.Name = item.Name;
                        carVarient.Price = item.Price;
                        carVarient.carId = item.carId;

                        carVarients.Add(carVarient);
                    }
                    car.CarVarients = carVarients;
                    cars.Add(car);
                }
                return cars;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Fetch all the cars by category
        /// </summary>
        /// <param name="category"></param>
        /// <returns>List of cars by category</returns>
        public IEnumerable<Car> ShowCarsByCategory(string category)
        {
            try
            {
                Database.CarCategory carCategory = _dbContext.CarCategories.Where(x => x.Category == category).FirstOrDefault();
                IEnumerable<Database.Car> entities = _dbContext.Cars.Include("CarVarients").Where(x => x.IsDeleted == false && x.Status == false && x.CarVarients.Count>0 && x.CarCategoryId== carCategory.Id).ToList();
                foreach (var entity in entities)
                {
                    foreach (var varient in entity.CarVarients)
                    {
                        entity.CarVarients = entity.CarVarients.Where(x => x.IsDeleted == false && x.Status == false).ToList();
                    }
                }
                List<Car> cars = new List<Car>();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Database.Car, Car>()
                    .ForMember(x => x.CarVarients, y => y.Ignore())
                    .ForMember(x => x.Address, y => y.Ignore())
                    .MaxDepth(1)
                    .PreserveReferences();
                });
                config.AssertConfigurationIsValid();

                var mapper = config.CreateMapper();

                foreach (var entity in entities)
                {
                    Car car = new Car();
                    car = mapper.Map<Car>(entity);
                    List<CarVarient> carVarients = new List<CarVarient>();
                    foreach (var item in entity.CarVarients)
                    {
                        CarVarient carVarient = new CarVarient();
                        carVarient.Id = item.Id;
                        carVarient.Image = item.Image;
                        carVarient.Name = item.Name;
                        carVarient.Price = item.Price;
                        carVarient.carId = item.carId;

                        carVarients.Add(carVarient);
                    }
                    car.CarVarients = carVarients;
                    cars.Add(car);
                }
                return cars;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Fetch all categories
        /// </summary>
        /// <returns>List of category</returns>
        public IEnumerable<CustomDropdown> GetAllCategory()
        {
            IEnumerable<Database.CarCategory> categories = _dbContext.CarCategories.ToList();
            List<CustomDropdown> dropdowns = new List<CustomDropdown>();
            foreach(var category in categories)
            {
                dropdowns.Add(new CustomDropdown
                {
                    Id=category.Id,
                    Name=category.Category
                });
            }
            return dropdowns;
        }

        /// <summary>
        /// Get car details by id
        /// </summary>
        /// <param name="Carid"></param>
        /// <returns>Car details</returns>
        public Car GetCar(Guid Carid)
        {
            try
            {
                Database.Car entity = _dbContext.Cars.Include("CarVarients").Where(x => x.Id == Carid).FirstOrDefault();
                foreach (var varient in entity.CarVarients)
                {
                     entity.CarVarients = entity.CarVarients.Where(x => x.IsDeleted == false && x.Status == false).ToList();
                }
                Car cars = new Car();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Database.Car, Car>()
                    .ForMember(x => x.CarVarients, y => y.Ignore())
                    .ForMember(x => x.Address, y => y.Ignore())
                    .MaxDepth(1)
                    .PreserveReferences();
                });
                config.AssertConfigurationIsValid();
                var mapper = config.CreateMapper();
                Car car = mapper.Map<Car>(entity);
                List<CarVarient> carVarients = new List<CarVarient>();
                foreach (var item in entity.CarVarients)
                {
                    CarVarient carVarient = new CarVarient();
                    carVarient.Image = item.Image;
                    carVarient.Id = item.Id;
                    carVarient.Name = item.Name;
                    carVarient.Price = item.Price;
                    carVarient.carId = item.carId;

                    carVarients.Add(carVarient);
                }
                car.CarVarients = carVarients;
                return car;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Update car
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public bool Update(Car car)
        {
            try
            {
                Database.Car entityCar = _dbContext.Cars.Where(c => c.Id == car.Id).FirstOrDefault();
                car.CreaatedBy = entityCar.CreaatedBy;
                car.CreatedAt = entityCar.CreatedAt;
                if (entityCar != null)
                {
                    Database.Car entity = new Database.Car();
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Database.Car, Car>()
                        .ForMember(dest => dest.CarVarients, opt => opt.Ignore());
                    });
                    config.AssertConfigurationIsValid();
                    var mapper = config.CreateMapper();
                    entity = mapper.Map<Database.Car>(car);
                    
                    _dbContext.Cars.AddOrUpdate(entity);
                    _dbContext.SaveChanges();

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Show cars for purchase according to the filtered budget
        /// </summary>
        /// <param name="custom"></param>
        /// <returns>Car list</returns>
        public IEnumerable<Car> ShowCarsBySearchPurchase(CustomPurchaseSearch custom)
        {
            try
            {
                decimal startLimit = 0;
                decimal EndLimit = 0;
                if (custom.Budget == "3-5lac")
                {
                    startLimit = 300000;
                    EndLimit = 500000;
                }
                else if (custom.Budget == "5-10lac")
                {
                    startLimit = 500000;
                    EndLimit = 1000000;
                }
                else if (custom.Budget == "10-15lac")
                {
                    startLimit = 1000000;
                    EndLimit = 1500000;
                }
                else if (custom.Budget == "15-30lac")
                {
                    startLimit = 1500000;
                    EndLimit = 3000000;
                }
                else if (custom.Budget == "above 30 lacs")
                {
                    startLimit = 3000000;
                    EndLimit = 10000000;
                }
                Database.CarCategory carCategory = _dbContext.CarCategories.Where(x => x.Category == custom.Category).FirstOrDefault();
                IEnumerable<Database.Car> entities = _dbContext.Cars.Include("CarVarients").Where(x => x.IsDeleted == false && x.Status == false && x.CarVarients.Count > 0 && x.CarCategoryId == carCategory.Id).ToList();
                if (!custom.Location.Equals("null"))
                    entities = entities.Where(x => x.Address.Pincode.City.CityName == custom.Location);
                else
                    entities = entities.Where(x => x.Brand == custom.Brand);
                foreach (var entity in entities)
                {
                    foreach (var varient in entity.CarVarients)
                    {
                        entity.CarVarients = entity.CarVarients.Where(x => x.IsDeleted == false && x.Status == false && x.Price >= startLimit && x.Price <= EndLimit).ToList();
                    }
                }
                //IEnumerable<Database.Car> entities = _dbContext.Cars.ToList();
                List<Car> cars = new List<Car>();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Database.Car, Car>()
                    .ForMember(x => x.CarVarients, y => y.Ignore())
                    .ForMember(x => x.Address, y => y.Ignore())
                    .MaxDepth(1)
                    .PreserveReferences();
                });
                config.AssertConfigurationIsValid();

                var mapper = config.CreateMapper();

                foreach (var entity in entities)
                {
                    bool flag = false;
                    Car car = new Car();
                    car = mapper.Map<Car>(entity);
                    List<CarVarient> carVarients = new List<CarVarient>();
                    foreach (var item in entity.CarVarients)
                    {
                        if(item.Price>=startLimit && item.Price < EndLimit)
                        {
                            CarVarient carVarient = new CarVarient();
                            carVarient.Image = item.Image;
                            carVarient.Id = item.Id;
                            carVarient.Name = item.Name;
                            carVarient.Price = item.Price;
                            carVarient.carId = item.carId;
                            carVarients.Add(carVarient);
                            flag = true;
                        }
                    }
                    if (flag)
                    {
                        car.CarVarients = carVarients;
                        cars.Add(car);
                    }
                }
                return cars;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Filter car for rent by city
        /// </summary>
        /// <param name="city"></param>
        /// <returns>Car list for rent by city</returns>
        public IEnumerable<Car> ShowRentCarbyCity(string city)
        {
            try
            {
                var category = "Rent";
                Database.CarCategory carCategory = _dbContext.CarCategories.Where(x => x.Category == category).FirstOrDefault();
                IEnumerable<Database.Car> entities = _dbContext.Cars
                    .Include("CarVarients")
                    .Where(x => x.IsDeleted == false && x.Status == false && x.CarVarients.Count > 0 && x.CarCategoryId == carCategory.Id && x.Address.Pincode.City.CityName == city)
                    .ToList();
                foreach (var entity in entities)
                {
                    foreach (var varient in entity.CarVarients)
                    {
                        entity.CarVarients = entity.CarVarients.Where(x => x.IsDeleted == false && x.Status == false).ToList();
                    }
                }
                List<Car> cars = new List<Car>();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Database.Car, Car>()
                    .ForMember(x => x.CarVarients, y => y.Ignore())
                    .ForMember(x => x.Address, y => y.Ignore())
                    .MaxDepth(1)
                    .PreserveReferences();
                });
                config.AssertConfigurationIsValid();

                var mapper = config.CreateMapper();

                foreach (var entity in entities)
                {
                    Car car = new Car();
                    car = mapper.Map<Car>(entity);
                    List<CarVarient> carVarients = new List<CarVarient>();
                    foreach (var item in entity.CarVarients)
                    {
                        CarVarient carVarient = new CarVarient();
                        carVarient.Id = item.Id;
                        carVarient.Name = item.Name;
                        carVarient.Price = item.Price;
                        carVarient.Image = item.Image;
                        carVarient.carId = item.carId;

                        carVarients.Add(carVarient);
                    }
                    car.CarVarients = carVarients;
                    cars.Add(car);
                }
                return cars;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Get all rent history by userid
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Shows rent history of user</returns>
        public IEnumerable<RentPdfVM> GetAllRentHistory(Guid id)
        {
            List<RentPdfVM> store = new List<RentPdfVM>();

            List<Database.CarRent> fetch = _dbContext.CarRents.Include("CarVarient")
                .Include("User")
                .Where(x => x.UserId == id).ToList();

            var status = string.Empty;

            foreach (var item in fetch)
            {
                if (item.Status == false && item.IsDeleted == false)
                {
                    status = "Nothing";
                }
                else if (item.Status == true && item.IsDeleted == false)
                {
                    status = "Pending";
                }
                else if (item.Status == true && item.IsDeleted == true)
                {
                    status = "Reject";
                }
                else
                {
                    status = "Approve";
                }
                Database.Address UserAddress = _dbContext.Addresses.Where(x => x.AddressId == item.PickupPoint).FirstOrDefault();
                RentPdfVM tmp = new RentPdfVM()
                {
                    CarName = item.CarVarient.Car.Name,
                    CarVarientName = item.CarVarient.Name,
                    CarRentId = item.CarRentId,
                    StartDate = item.BookingDate,
                    EndDate = item.ReturningDate,
                    UserName = item.User.Name,
                    Image = item.CarVarient.Image,

                    UserAddress = UserAddress.LocalAddress
                    + ", \n"
                    + UserAddress.Pincode.City.CityName
                    + ", "
                    + UserAddress.Pincode.City.State.StateName
                    + ",\n"
                    + UserAddress.Pincode.City.State.Country.CountryName
                    + " -"
                    + UserAddress.Pincode.Pincode1,
                    Price = item.Amount,
                    status = status
                };
                store.Add(tmp);
            }

            return store;
        }


        /// <summary>
        /// Get all purchase history by userid
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Shows purchase history of user</returns>
        public IEnumerable<PdfVM> GetAllPurchaseHistory(Guid id)
        {
            List<PdfVM> store = new List<PdfVM>();

            List<Database.CarPurchas> fetch = _dbContext.CarPurchases.Include("CarVarient")
                .Include("User")
                .Where(x => x.UserId == id).ToList();
            var status = string.Empty;
            foreach (var item in fetch)
            {
                if (item.Status == false && item.IsDeleted == false)
                {
                    status = "Nothing";
                }
                else if (item.Status == true && item.IsDeleted == false)
                {
                    status = "Pending";
                }
                else if (item.Status == true && item.IsDeleted == true)
                {
                    status = "Reject";
                }
                else
                {
                    status = "Approve";
                }
                Database.Address UserAddress = _dbContext.Addresses.Where(x => x.AddressId == item.AddressId).FirstOrDefault();
                PdfVM tmp = new PdfVM()
                {

                    CarName = item.CarVarient.Car.Name,
                    CarVarientName = item.CarVarient.Name,
                    CarPurchaseId = item.CarPurchaseId,
                    Date = DateTime.Parse(item.CreatedAt.ToString()),
                    UserName = item.User.Name,
                    Image = item.CarVarient.Image,
                    DealerName = item.Dealer.Name,
                    DealerContact = item.Dealer.ContactNo,
                    DealerAddress = item.Dealer.Address.LocalAddress
                    + ", \n"
                    + item.Dealer.Address.Pincode.City.CityName
                    + ", "
                    + item.Dealer.Address.Pincode.City.State.StateName
                    + ",\n"
                    + item.Dealer.Address.Pincode.City.State.Country.CountryName
                    + " -"
                    + item.Dealer.Address.Pincode.Pincode1,
                    UserAddress = UserAddress.LocalAddress
                    + ", \n"
                    + UserAddress.Pincode.City.CityName
                    + ", "
                    + UserAddress.Pincode.City.State.StateName
                    + ",\n"
                    + UserAddress.Pincode.City.State.Country.CountryName
                    + " -"
                    + UserAddress.Pincode.Pincode1,
                    Price = item.Amount,
                    status =status

                };
                store.Add(tmp);
            }

            return store;
        }

        
        public bool AddReview(RatingVM rating)
        {
            try
            {
                Database.Review review = new Database.Review();
                review.Title = rating.Title;
                review.Discription = rating.Discription;
                review.CreatedAt = rating.CreatedAt;
                review.CreatedBy = rating.CreatedBy;
                review.ReviewId = Guid.NewGuid();
                review.CarId = rating.CarId;
                review.Rating = rating.Rating;
                review.ModifiedBy = rating.UserId;
                review.ModifiedAt = "12-12-2020";
                _dbContext.Reviews.Add(review);
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
