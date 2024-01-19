using AutoMapper;
using MyCarApp.BE.BussinessEntities;
using MyCarApp.BE.ViewModels;
using MyCarApp.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MyCarApp.DAL.Repository.Classes
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly Database.MyCarDBEntities _dbContext;
        public TransactionRepository()
        {
            _dbContext = new Database.MyCarDBEntities();
        }

        /// <summary>
        /// Adds car purchase entry in database
        /// </summary>
        /// <param name="TransactionId"></param>
        /// <param name="carPurchase"></param>
        /// <returns></returns>
        public Guid CarPurchase(string local, int pincode, string TransactionId, CarPurchase carPurchase)
        {
            try
            {

                var _pincode = _dbContext.Pincodes.Where(x => x.Pincode1 == pincode).FirstOrDefault();
                var AddressId = Guid.NewGuid();
                Database.Address address = new Database.Address()
                {
                    AddressId = AddressId,
                    LocalAddress = local,
                    PincodeId = _pincode.PincodeId
                };
                _dbContext.Addresses.Add(address);
                _dbContext.SaveChanges();

                
                Guid InVoiceId = Guid.NewGuid();
                Database.Invoice invoice = new Database.Invoice()
                {
                    InvoiceId = InVoiceId,
                    TranscationId = TransactionId,
                };

                _dbContext.Invoices.Add(invoice);
                _dbContext.SaveChanges();

                Database.CarPurchas carPurchasDB = new Database.CarPurchas();

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CarPurchase, Database.CarPurchas>();
                });

                var mapper = config.CreateMapper();


                


                carPurchasDB = mapper.Map<Database.CarPurchas>(carPurchase);
                carPurchasDB.UserId = carPurchase.UserId;
                carPurchasDB.User = _dbContext.Users.Where(x => x.UserId == carPurchase.UserId).FirstOrDefault();
                carPurchasDB.CarVarient = _dbContext.CarVarients.Where(x => x.Id == carPurchase.CarVarientId).FirstOrDefault();
                carPurchasDB.InvoiceId = InVoiceId;
                carPurchasDB.CarPurchaseId = Guid.NewGuid();
                carPurchasDB.DealerId = new Guid("6cc752cb-295f-4c9e-bd5c-c72b98853baa");
                carPurchasDB.PaymentMethodId = new Guid("fad5eda1-5ddf-4b99-9ba7-80ebf658b10f");
                carPurchasDB.CurrencyId = new Guid("f210d047-9a6e-4e32-8430-ae7abce4bea1");
                carPurchasDB.CreatedAt = DateTime.Now;
                carPurchasDB.ModifiedAt = DateTime.Now;
                carPurchasDB.AddressId = AddressId;
                _dbContext.CarPurchases.Add(carPurchasDB);
                _dbContext.SaveChanges();

                MailMessage mail = new MailMessage();
                mail.To.Add(carPurchasDB.User.Email);
                mail.From = new MailAddress("17it097@charusat.edu.in");
                mail.Subject = "Welcome to MyCarApp!";
                //string Body = "<h3>Hey " + user.Name + "!</h3><br><h4> Welcome to MyCarApp.<br> Your account is now set up and ready to use.Let's get started!</h4>";
                string FilePath = "D:\\Major Project\\MyCarApp.Solution\\MyCarApp.Solution\\MyCarApp.DAL\\EmailFormates\\CarPurchase.html";
                StreamReader str = new StreamReader(FilePath);
                string Body = str.ReadToEnd();
                str.Close();
                Body = Body.Replace("{{ user }}", carPurchasDB.User.Name.Trim());
                Body = Body.Replace("{{ varient }}", carPurchasDB.CarVarient.Name.Trim());
                Body = Body.Replace("{{ price }}", carPurchasDB.CarVarient.Price.ToString());
                Body = Body.Replace("{{ date }}", DateTime.Now.ToString());
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "in-v3.mailjet.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("3a83b0df7fefd394b27eba461e3b0612", "743845caa86d2ae7c29646826d524275");
                smtp.EnableSsl = true;
                smtp.Send(mail);

                return carPurchasDB.CarPurchaseId;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new Guid();
            }
        }

        /// <summary>
        /// Adds car rent entry in database
        /// </summary>
        /// <param name="TransactionId"></param>
        /// <param name="carRent"></param>
        /// <returns></returns>
        public Guid CarRent(string local, int pincode, string TransactionId, CarRent carRent)
        {
            try
            {
                var _pincode = _dbContext.Pincodes.Where(x => x.Pincode1 ==pincode).FirstOrDefault();
                var AddressId = Guid.NewGuid();
                Database.Address address = new Database.Address()
                {
                    AddressId = AddressId,
                    LocalAddress = local,
                    PincodeId = _pincode.PincodeId
                };
                _dbContext.Addresses.Add(address);
                _dbContext.SaveChanges();

                Guid InVoiceId = Guid.NewGuid();
                Database.Invoice invoice = new Database.Invoice()
                {
                    InvoiceId = InVoiceId,
                    TranscationId = TransactionId,
                };

                _dbContext.Invoices.Add(invoice);
                _dbContext.SaveChanges();

                Database.CarRent carRentDB = new Database.CarRent();

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CarRent, Database.CarRent>();
                });

                var mapper = config.CreateMapper();

                carRentDB = mapper.Map<Database.CarRent>(carRent);
                carRentDB.InvoiceId = InVoiceId;
                carRentDB.CarRentId = Guid.NewGuid();
                carRentDB.BookingDate = DateTime.Parse(carRentDB.BookingDate.ToString());
                carRentDB.ReturningDate = DateTime.Parse(carRentDB.ReturningDate.ToString());
                carRentDB.CreatedAt = DateTime.Now;
                carRentDB.ModifiedAt = DateTime.Now;
                carRentDB.DropPoint = AddressId;
                carRentDB.PickupPoint = AddressId;
                _dbContext.CarRents.Add(carRentDB);
                _dbContext.SaveChanges();

                return carRentDB.CarRentId;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new Guid();
            }
        }

        /// <summary>
        /// Get purchase history by varient id
        /// </summary>
        /// <param name="CarVarientId"></param>
        /// <returns></returns>
        public CarVarient ConfirmPurchase(Guid CarVarientId)
        {
            try
            {
                Database.CarVarient carVarient = _dbContext.CarVarients.Include("Car").Where(x => x.Id == CarVarientId).FirstOrDefault();
                if (carVarient != null)
                {

                    Database.Car car = carVarient.Car;
                    var config = new MapperConfiguration(cfg => 
                    {
                        cfg.CreateMap<Database.CarVarient, CarVarient>()
                        .ForMember(x => x.Car, y => y.Ignore())
                        .ForMember(x => x.CarPurchases, y => y.Ignore())
                        .MaxDepth(1)
                        .PreserveReferences();
                    });
                    var mapper = config.CreateMapper();

                    CarVarient entity = mapper.Map<CarVarient>(carVarient);
                    entity.Car = new Car();
                    entity.Car.Address = new Address();
                    entity.Car.Address.Pincode = new Pincode();
                    entity.Car.Address.Pincode.City = new City();
                    entity.Car.Address.Pincode.City.State = new State();
                    entity.Car.Address.Pincode.City.State.Country = new Country();
                    entity.carId = car.Id;
                    entity.Car.Name = car.Name;
                    entity.Car.Address.LocalAddress = car.Address.LocalAddress;
                    entity.Car.Address.Pincode.Pincode1 = car.Address.Pincode.Pincode1;
                    entity.Car.Address.Pincode.City.CityName = car.Address.Pincode.City.CityName;
                    entity.Car.Address.Pincode.City.State.StateName = car.Address.Pincode.City.State.StateName;
                    entity.Car.Address.Pincode.City.State.Country.CountryName = car.Address.Pincode.City.State.Country.CountryName;

                    return entity;
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// fetch purchase detail by purchase id
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <returns></returns>
        public PdfVM GeneratePDF(Guid purchaseId)
        {
            PdfVM pdfVM = new PdfVM();
            Database.CarPurchas carPurchas = _dbContext.CarPurchases
                .Include("CarVarient")
                .Include("User")
                .Include("Dealer")
                .Where(x => x.CarPurchaseId == purchaseId)
                .FirstOrDefault();
            var status = string.Empty;
            if (carPurchas != null)
            {
                if (carPurchas.Status == false && carPurchas.IsDeleted == false)
                {
                    status = "Nothing";
                }
                else if (carPurchas.Status == true && carPurchas.IsDeleted == false)
                {
                    status = "Pending";
                }
                else if (carPurchas.Status == true && carPurchas.IsDeleted == true)
                {
                    status = "Reject";
                }
                else
                {
                    status = "Approve";
                }
                pdfVM.CarName = carPurchas.CarVarient.Car.Name;
                pdfVM.status = status;
                pdfVM.CarPurchaseId = carPurchas.CarPurchaseId;
                pdfVM.CarVarientName = carPurchas.CarVarient.Name;
                pdfVM.Date = DateTime.Parse(carPurchas.CreatedAt.ToString());
                pdfVM.Price = carPurchas.CarVarient.Price;
                pdfVM.DealerName = carPurchas.Dealer.Name;
                pdfVM.DealerContact = carPurchas.Dealer.ContactNo;
                Database.Address Dealeraddress = carPurchas.Dealer.Address;
                pdfVM.DealerAddress = Dealeraddress.LocalAddress
                    + ", \n"
                    + Dealeraddress.Pincode.City.CityName
                    + ", "
                    + Dealeraddress.Pincode.City.State.StateName
                    + ",\n"
                    + Dealeraddress.Pincode.City.State.Country.CountryName
                    + " -"
                    + Dealeraddress.Pincode.Pincode1;
                pdfVM.UserName = carPurchas.User.Name;
                Database.Address UserAddress = _dbContext.Addresses.Where(x => x.AddressId == carPurchas.AddressId).FirstOrDefault();
                pdfVM.UserAddress = UserAddress.LocalAddress
                    + ", \n"
                    + UserAddress.Pincode.City.CityName
                    + ", "
                    + UserAddress.Pincode.City.State.StateName
                    + ",\n"
                    + UserAddress.Pincode.City.State.Country.CountryName
                    + " -"
                    + UserAddress.Pincode.Pincode1;
                return pdfVM;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// fetch rent details by rent id
        /// </summary>
        /// <param name="RentId"></param>
        /// <returns></returns>
        public RentPdfVM GenerateRentPDF(Guid RentId)
        {
       
           RentPdfVM pdfVM = new RentPdfVM();
            Database.CarRent carRent = _dbContext.CarRents
                .Include("CarVarient")
                .Include("User")
                .Where(x => x.CarRentId == RentId)
                .FirstOrDefault();

            var status = string.Empty;
            if (carRent != null)
            {
                if (carRent.Status == false && carRent.IsDeleted == false)
                {
                    status = "Nothing";
                }
                else if (carRent.Status == true && carRent.IsDeleted == false)
                {
                    status = "Pending";
                }
                else if (carRent.Status == true && carRent.IsDeleted == true)
                {
                    status = "Reject";
                }
                else
                {
                    status = "Approve";
                }
                pdfVM.status = status;
                pdfVM.CarName = carRent.CarVarient.Car.Name;
                pdfVM.CarVarientName = carRent.CarVarient.Name;
                pdfVM.CarRentId = carRent.CarRentId;
                pdfVM.StartDate = carRent.BookingDate;
                pdfVM.EndDate = carRent.ReturningDate;
                pdfVM.Price = carRent.Amount;
                pdfVM.UserName = carRent.User.Name;
                Database.Address UserAddress = _dbContext.Addresses.Where(x => x.AddressId == carRent.PickupPoint).FirstOrDefault();
                pdfVM.UserAddress = UserAddress.LocalAddress
                    + ", \n"
                    + UserAddress.Pincode.City.CityName
                    + ", "
                    + UserAddress.Pincode.City.State.StateName
                    + ",\n"
                    + UserAddress.Pincode.City.State.Country.CountryName
                    + " -"
                    + UserAddress.Pincode.Pincode1;
                return pdfVM;
            }
            else
            {
                return null;
            }
        }
    }
}
