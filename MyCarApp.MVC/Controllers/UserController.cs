using MyCarApp.BE.BussinessEntities;
using MyCarApp.BE.ViewModels;
using MyCarApp.Common.Enums;
using MyCarApp.Common.WebClient;
using MyCarApp.MVC.Filters.UserIdentityFilter;
using Newtonsoft.Json;
using PagedList;
using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyCarApp.MVC.Controllers
{
    public class UserController : Controller
    {
        private static string _invoicePurchaseId;
        private static string _invoiceRentId;

        /// <summary>
        /// Get method for searching cars
        /// </summary>
        /// <param name="category"></param>
        /// <param name="budget"></param>
        /// <param name="brand"></param>
        /// <param name="varient"></param>
        /// <param name="location"></param>
        /// <param name="sortOrder"></param>
        /// <param name="currentFilter"></param>
        /// <param name="searchString"></param>
        /// <param name="custom"></param>
        /// <param name="page"></param>
        /// <returns>Car list </returns>
        [HttpGet]
        public ActionResult SearchCars(string category, string budget, string brand, string varient, string location, string sortOrder, string currentFilter, string searchString, string custom, int? page)
        {
            IEnumerable<Car> cars = null;
            if (brand != "")
            {
                cars = IndexPageSearch(CategoryEnum.New.ToString(), budget, brand, "", "");
            }
            else if (location != "")
            {
                cars = IndexPageSearch(CategoryEnum.Used.ToString(), budget, "", "", location);
            }
            return View(cars.ToList().ToPagedList(1, 8));
        }

        /// <summary>
        /// Post method for searching rent cars by city
        /// </summary>
        /// <param name="rentCarCity"></param>
        /// <returns>Shows cars available for rent in a particular city</returns>
       
        [HttpPost]
        public ActionResult SearchRentCars(string rentCarCity)
        {
            try
            {
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("Car/ShowRentCarByCity/?city=" + rentCarCity).Result;
                if (response.IsSuccessStatusCode)
                {
                    return View(response.Content.ReadAsAsync<IEnumerable<Car>>().Result.ToList().ToPagedList(1, 8));
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {

                return View();
            }
        }

        /// <summary>
        /// Post method for search cars
        /// </summary>
        /// <param name="collection"></param>
        [HttpPost]
        public void SearchCars(FormCollection collection)
        {
            /*IEnumerable<Car> cars=null;
            if (collection["ByBrand"] != null)
            {
                string byBudget = collection["ByBudget"].ToString();
                string ByBrand = collection["ByBrand"].ToString();
                cars = IndexPageSearch(CategoryEnum.New.ToString(), byBudget, ByBrand,"", "");
            }
            else if(collection["ByLocation"] != null)
            {
                string byBudget = collection["ByBudget"].ToString();
                string ByLocation = collection["ByLocation"].ToString();
                cars = IndexPageSearch(CategoryEnum.New.ToString(), byBudget, "","",ByLocation);
            }*/
            string queryString = $"?category={collection["category"]}&budget={collection["ByBudget"]}&location={collection["ByLocation"]}&brand={collection["ByBrand"]}&varient={""}";
            Response.Redirect("/User/SearchCars" + queryString);
        }

        /// <summary>
        /// Sorting Cars by brand
        /// </summary>
        /// <param name="brand"></param>
        /// <returns>Sorted view of cars by brand</returns>
        [HttpGet,HandleError,Route("User/CarsByBrand/{brand}")]
        public ActionResult CarsByBrand(string brand)
        {
            try
            {
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("Car/GetByBrand/" + brand).Result;
                if (response.IsSuccessStatusCode)
                {
                    return View(response.Content.ReadAsAsync<IEnumerable<Car>>().Result);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {

                return View();
            }
        }
        [HttpGet, HandleError]
        public ActionResult RequestRentRefund(Guid carRentId)
        {
            try
            {
                UpdateStatus updateStatus = new UpdateStatus()
                {
                    id = carRentId,
                    IsRent = true
                };
                var record = WebHttpClient.webAPIClient.PostAsJsonAsync<UpdateStatus>("user/StatusPending", updateStatus);
                record.Wait();
                var saveRecord = record.Result;
                if (saveRecord.IsSuccessStatusCode)
                {
                    TempData["message"] = "Your refund request submitted successfully";
                    return RedirectToAction("Index");
                }

                else
                    return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }
        }
        [HttpGet, HandleError]
        public ActionResult RequestPurchaseRefund(Guid purchaseId)
        {
            try
            {
                UpdateStatus updateStatus = new UpdateStatus()
                {
                    id = purchaseId,
                    IsRent = false
                };
                var record = WebHttpClient.webAPIClient.PostAsJsonAsync<UpdateStatus>("user/StatusPending", updateStatus);
                record.Wait();
                var saveRecord = record.Result;
                if (saveRecord.IsSuccessStatusCode)
                {
                    TempData["message"] = "Your refund request submitted successfully";
                    return RedirectToAction("Index");
                }

                else
                    return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }
        }
        /// <summary>
        /// Get method for Search on index page
        /// </summary>
        /// <param name="category"></param>
        /// <param name="budget"></param>
        /// <param name="brand"></param>
        /// <param name="varient"></param>
        /// <param name="location"></param>
        /// <returns>Shows desirable available cars to users</returns>
        private IEnumerable<Car> IndexPageSearch(string category, string budget, string brand,string varient, string location)
        {
            try
            {
                string queryString = $"?category={category}&budget={budget}&location={location}&brand={brand}&varient={varient}";
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("Car/ShowCustomPurchaseSearch" + queryString).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<Car>>().Result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>
        /// Post method of landing page
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LandingPage(FormCollection collection)
        {
            IEnumerable<Car> cars = null;
            if (collection["BuyCar"] != null)
            {
                if (collection["newCarByBudgetBudget"] != null)
                {
                    string newCarByBudgetBudget = collection["newCarByBudgetBudget"].ToString();
                    string newCarByBudgetVehicle = collection["newCarByBudgetVehicle"].ToString();
                    cars = IndexPageSearch(CategoryEnum.New.ToString(), newCarByBudgetBudget, newCarByBudgetVehicle,"", "");
                }
                else if (collection["newCarByModelBrand"] != null)
                {
                    string newCarByModelBrand = collection["newCarByModelBrand"].ToString();
                    string newCarByModelModelName = collection["newCarByModelModelName"].ToString();
                    cars = IndexPageSearch(CategoryEnum.New.ToString(),"", newCarByModelBrand, newCarByModelModelName, "");
                }
                else if (collection["OldCarByLocation"] != null)
                {
                    string oldCarByLocation = collection["oldCarByLocation"].ToString();
                    cars = IndexPageSearch(CategoryEnum.Used.ToString(), "", "","", oldCarByLocation);
                }
                else if (collection["oldCarSearchByBudgetBudget"] != null)
                {
                    string oldCarSearchByBudgetBudget = collection["oldCarSearchByBudgetBudget"].ToString();
                    string oldCarSearchByBudgetLocation = collection["oldCarSearchByBudgetLocation"].ToString();
                    cars = IndexPageSearch(CategoryEnum.Used.ToString(), oldCarSearchByBudgetBudget,"","",oldCarSearchByBudgetLocation);
                }
                else if (collection["oldCarSearchByModelModelName"] != null)
                {
                    string oldCarSearchByModelModelName = collection["oldCarSearchByModelModelName"].ToString();
                    string oldCarSearchByModelLocation = collection["oldCarSearchByModelLocation"].ToString();
                    cars = IndexPageSearch(CategoryEnum.Used.ToString(), "", oldCarSearchByModelModelName,"", oldCarSearchByModelLocation);
                }
            }
            else if (collection["RentCar"] != null)
            {
                if (collection["rentCity"] != null)
                {
                    string rentCity = collection["rentCity"].ToString();
                    string rentstartDate = collection["rentstartDate"].ToString();
                    string rentendDate = collection["rentendDate"].ToString();
                    string airportPickup = collection["airportPickup"].ToString();
                }
                else if (collection["subscribeCity"] != null)
                {
                    string subscribeCity = collection["subscribeCity"].ToString();
                    string subscribestartDate = collection["subscribestartDate"].ToString();
                    string subscribeendDate = collection["subscribeendDate"].ToString();
                }
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Index page of website
        /// </summary>
        /// <returns>Index View</returns>
        public ActionResult Index()
        {
            ViewBag.Top10Cars = GetTopCars();
            ViewBag.LatestCars = GetLatestCars();
            var loadMessage = TempData["message"];
            if (loadMessage != null)
            {
                ViewBag.Message = loadMessage.ToString();
            }
            return View();
        }

        /// <summary>
        /// Sorting in new cars
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="currentFilter"></param>
        /// <param name="searchString"></param>
        /// <param name="custom"></param>
        /// <param name="page"></param>
        /// <returns>Sorted New Cars list</returns>
        public ActionResult NewCars(string sortOrder, string currentFilter, string searchString, string custom, int? page)
        {
            string category=CategoryEnum.New.ToString();
            var cars = getCars(category);
            ViewBag.CurrentSort = sortOrder;
            ViewBag.BrandNameSortParm = String.IsNullOrEmpty(sortOrder) ? "brand_desc" : "";
            ViewBag.NameSortParm = sortOrder == "Name" ? "Name_desc" : "Name";
            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;
            // custom search
            if (!String.IsNullOrEmpty(searchString))
                cars = cars.Where(c => c.Brand.ToUpper().Contains(searchString.ToUpper()) || c.Name.ToUpper().Contains(searchString.ToUpper()));
            cars = Sort(cars, sortOrder);
            return View(cars.ToList().ToPagedList(page ?? 1, 8));
        }
        public ActionResult Reports()
        {
            try
            {
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("Charts/cars").Result;
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Cars = response.Content.ReadAsAsync<Dictionary<string,IEnumerable<TotalCarsVM>>>().Result;
                    return View();
                }
                else
                {
                    return View();
                }

            }
            catch (Exception)
            {
                return View();
            }
        }

        /// <summary>
        /// Sorting used cars
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="currentFilter"></param>
        /// <param name="searchString"></param>
        /// <param name="custom"></param>
        /// <param name="page"></param>
        /// <returns>Sorted Used Cars list</returns>
        public ActionResult UsedCars(string sortOrder, string currentFilter, string searchString, string custom, int? page)
        {
            string category = CategoryEnum.Used.ToString();
            var cars = getCars(category);
            ViewBag.CurrentSort = sortOrder;
            ViewBag.BrandNameSortParm = String.IsNullOrEmpty(sortOrder) ? "brand_desc" : "";
            ViewBag.NameSortParm = sortOrder == "Name" ? "Name_desc" : "Name";
            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;
            // custom search
            if (!String.IsNullOrEmpty(searchString))
                cars = cars.Where(c => c.Brand.ToUpper().Contains(searchString.ToUpper()) || c.Name.ToUpper().Contains(searchString.ToUpper()));
            cars = UsedCarSort(cars, sortOrder);
            return View("OldCars",cars.ToList().ToPagedList(page ?? 1, 8));
        }

        /// <summary>
        /// Sorting cars for rent
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="currentFilter"></param>
        /// <param name="searchString"></param>
        /// <param name="custom"></param>
        /// <param name="page"></param>
        /// <returns>Sorted rent cars list</returns>
        public ActionResult RentCars(string sortOrder, string currentFilter, string searchString, string custom, int? page)
        {
            string category = CategoryEnum.Rent.ToString();
            var cars = getCars(category);
            ViewBag.CurrentSort = sortOrder;
            ViewBag.BrandNameSortParm = String.IsNullOrEmpty(sortOrder) ? "brand_desc" : "";
            ViewBag.NameSortParm = sortOrder == "Name" ? "Name_desc" : "Name";
            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;
            // custom search
            if (!String.IsNullOrEmpty(searchString))
                cars = cars.Where(c => c.Brand.Contains(searchString) || c.Name.Contains(searchString));
            cars = Sort(cars, sortOrder);
            return View(cars.ToList().ToPagedList(page ?? 1, 8));
        }

        /// <summary>
        /// Get top cars method
        /// </summary>
        /// <returns>Shows top cars</returns>
        private IEnumerable<Car> GetTopCars()
        {
            try
            {
                
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("Car/TopCars/true").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<Car>>().Result;
                    
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Get latest cars
        /// </summary>
        /// <returns>Shows latest cars</returns>
        private IEnumerable<Car> GetLatestCars()
        {
            try
            {
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("Car/LatestCars").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<Car>>().Result;
                   
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Subscribe cars
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="currentFilter"></param>
        /// <param name="searchString"></param>
        /// <param name="custom"></param>
        /// <param name="page"></param>
        /// <returns>Shows available cars for subscription according to the filter applied</returns>
        public ActionResult SubscribeCars(string sortOrder, string currentFilter, string searchString, string custom, int? page)
        {
            string category = CategoryEnum.Subscribe.ToString();
            var cars = getCars(category);
            ViewBag.CurrentSort = sortOrder;
            ViewBag.BrandNameSortParm = String.IsNullOrEmpty(sortOrder) ? "brand_desc" : "";
            ViewBag.NameSortParm = sortOrder == "Name" ? "Name_desc" : "Name";
            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;
            ViewBag.CurrentFilter = searchString;
            // custom search
            if (!String.IsNullOrEmpty(searchString))
                cars = cars.Where(c => c.Brand.Contains(searchString) || c.Name.Contains(searchString));
            cars = Sort(cars, sortOrder);
            return View(cars.ToList().ToPagedList(page ?? 1, 8));
        }

        /// <summary>
        /// Sorting cars by brand name
        /// </summary>
        /// <param name="cars"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        private IEnumerable<Car> Sort(IEnumerable<Car> cars, string sortOrder)
        {
            switch (sortOrder)
            {
                case "brand_desc":
                    cars = cars.OrderByDescending(p => p.Brand);
                    break;
                case "Name":
                    cars = cars.OrderBy(p=>p.Name);
                    break;
                case "Name_desc":
                    cars = cars.OrderByDescending(p => p.Name);
                    break;
                default:  // Product Name ascending 
                    cars = cars.OrderBy(p => p.Brand);
                    break;
            }
            return cars;
        }
        private IEnumerable<Car> UsedCarSort(IEnumerable<Car> cars, string sortOrder)
        {
            switch (sortOrder)
            {
                case "brand_desc":
                    cars = cars.OrderByDescending(p => p.Brand);
                    break;
                case "Name":
                    cars = cars.OrderBy(p => p.Kilometers);
                    break;
                case "Name_desc":
                    cars = cars.OrderByDescending(p => p.Kilometers);
                    break;
                default:  // Product Name ascending 
                    cars = cars.OrderBy(p => p.Brand);
                    break;
            }
            return cars;
        }

        /// <summary>
        /// Get car details by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Car details</returns>
        public ActionResult CarDetails(Guid? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = GetCar(Id);
            return View(car);
        }

        /// <summary>
        /// Post method for rent car by city
        /// </summary>
        /// <param name="varientId"></param>
        /// <param name="price"></param>
        /// <param name="carId"></param>
        /// <returns>returs cars available for rent</returns>
        [HttpPost, HandleError,UserSessionManagement]
        public ActionResult RentCarByCity(string varientId, string price, string carId)
        {
            ViewBag.VarientId = new Guid(varientId);
            var car = GetCar(new Guid(carId));
            ViewBag.Amount = Convert.ToDouble(price);
            var stripePublishKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            ViewBag.StripePublishKey = stripePublishKey;
            return View(car);
        }
        /// <summary>
        /// Method for purchase car
        /// </summary>
        /// <param name="varientId"></param>
        /// <param name="price"></param>
        /// <param name="carId"></param>
        /// <returns>returns cars for purchase</returns>
        [HttpPost,HandleError,UserSessionManagement]
        public ActionResult PurchaseCar(string varientId, string price,string carId)
        {
            ViewBag.VarientId = new Guid(varientId);
            var car=GetCar(new Guid(carId));
            ViewBag.Amount = Convert.ToDouble(price);
            var stripePublishKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            ViewBag.StripePublishKey = stripePublishKey;
            return View(car);
        }
        /// <summary>
        /// Method for showing price charged with details of car varient for car purchase
        /// </summary>
        /// <param name="stripeToken"></param>
        /// <param name="stripeEmail"></param>
        /// <param name="price"></param>
        /// <param name="varientId"></param>
        /// <returns>Redirect to invoice page for purchase</returns>
        [Obsolete, UserSessionManagement]
        public ActionResult Charge(string stripeToken, string stripeEmail,long price,string varientId, string pincode, string localaddress)
        {
            StripeConfiguration.SetApiKey(ConfigurationManager.AppSettings["stripePublishableKey"]);
            StripeConfiguration.ApiKey = ConfigurationManager.AppSettings["stripeSecretKey"];
            CarPurchaseModel carPurchaseModel = new CarPurchaseModel
            {
                PincodeData=int.Parse( pincode),
                LocalAddress=localaddress,
                TransactionId = stripeToken,
                CarPurchase = new CarPurchase
                {
                    //UserId = new Guid(Session["userId"].ToString()),
                    CarVarientId = new Guid(varientId),
                    PaymentMethodId = new Guid("f017dc5f-b445-4fc1-b513-31197f649323"),
                    CurrencyId = new Guid("9bb11842-865f-4295-b8bd-f8f4210c2ab2"),
                    IsFullPayment=true,
                    Amount=price
                }
            };
            var myCharge = new Stripe.ChargeCreateOptions();
            if (price >= 1000000)
                myCharge.Amount = price;
            else
                myCharge.Amount = price * 100;
            
            myCharge.Currency = "INR";
            myCharge.ReceiptEmail = stripeEmail;
            myCharge.Description = "car purchase of "+varientId;
            myCharge.Source = stripeToken;
            myCharge.Capture = true;
            var chargeService = new Stripe.ChargeService();
            try
            {
                
                Charge stripeCharge = chargeService.Create(myCharge);
                Debug.WriteLine(stripeCharge.Id);
                carPurchaseModel.TransactionId = stripeCharge.Id;
                Guid purchaseId = GetPuchaseEntry(carPurchaseModel);
                return RedirectToAction("Invoice", "User", new { purchaseId = purchaseId.ToString() });
            }
            catch(StripeException e)
            {
                Debug.WriteLine(e);
                TempData["message"] = "Network related error occured";
                return RedirectToAction("Index");
            }
        }
        /// <summary>
        /// Method for showing price charged with details of car varient for car rent
        /// </summary>
        /// <param name="stripeToken"></param>
        /// <param name="stripeEmail"></param>
        /// <param name="price"></param>
        /// <param name="varientId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns>Redirect to invoice page for rent</returns>
        [Obsolete, UserSessionManagement]
        public ActionResult RentCharge(string stripeToken, string stripeEmail, long price, string varientId,string startTime,string endTime, string pincode, string localaddress)
        {
            StripeConfiguration.SetApiKey(ConfigurationManager.AppSettings["stripePublishableKey"]);
            StripeConfiguration.ApiKey = ConfigurationManager.AppSettings["stripeSecretKey"];
            var BookingDate = DateTime.Parse(startTime);
            var ReturningDate = DateTime.Parse(endTime);

            CarRentModel carRentModel = new CarRentModel
            {
                LocalAddress = localaddress,
                PincodeData = int.Parse(pincode),
                TransactionId = stripeToken,
                carRent = new CarRent
                {
                    CarVarientId = new Guid(varientId),
                    PaymentMethodId = new Guid("fad5eda1-5ddf-4b99-9ba7-80ebf658b10f"),
                    CurrencyId = new Guid("f210d047-9a6e-4e32-8430-ae7abce4bea1"),
                    IsPaymentDone=true,
                    PickupPoint=new Guid("eb53730d-ba07-41b1-9787-be724cb40160"),
                    DropPoint=new Guid("eb53730d-ba07-41b1-9787-be724cb40160"),
                    BookingDate=DateTime.Parse(startTime),
                    ReturningDate=DateTime.Parse(endTime),
                    Amount = Convert.ToDecimal((ReturningDate - BookingDate).TotalDays) * price
                }
            };
            
            var myCharge = new Stripe.ChargeCreateOptions();
            myCharge.Amount = Convert.ToInt64(carRentModel.carRent.Amount)*100;
            myCharge.Currency = "INR";
            myCharge.ReceiptEmail = stripeEmail;
            myCharge.Description = "car rent of " + varientId;
            myCharge.Source = stripeToken;
            myCharge.Capture = true;
            var chargeService = new Stripe.ChargeService();
            try
            {
                Guid carRentId = DoRentEntry(carRentModel);
                Charge stripeCharge = chargeService.Create(myCharge);
                Debug.WriteLine(stripeCharge.Id);
                carRentModel.TransactionId = stripeCharge.Id;
                return RedirectToAction("RentInvoice", "User", new { carRentId = carRentId.ToString() });
            }catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                TempData["message"] = "Network related error occured";
                return RedirectToAction("Index");
            }
            
        }
        /// <summary>
        /// Get method for getting car details for rent invoice
        /// </summary>
        /// <param name="carRentId"></param>
        /// <returns>Requests for invoice</returns>
        [HttpGet, UserSessionManagement]
        public ActionResult RentInvoice(string carRentId)
        {
            try
            {
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"] == null ? "" : Session["token"].ToString());
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("Transaction/GenerateRentPDF/" + new Guid(carRentId)).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = response.Content.ReadAsAsync<RentPdfVM>().Result;
                    return View(res);
                }
                else
                {
                    TempData["message"] = "Network related error occured";
                    return RedirectToAction("Index");
                }

            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Generating rent invoice
        /// </summary>
        /// <returns>Display rent invoice</returns>
        public ActionResult GenerateRentInvoice()
        {
            Guid rentId = new Guid(_invoiceRentId);
            try
            {
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"] == null ? "" : Session["token"].ToString());
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("Transaction/GenerateRentPDF/" + rentId).Result;
                if (response.IsSuccessStatusCode)
                {
                    return View(response.Content.ReadAsAsync<RentPdfVM>().Result);
                }
                else
                {
                    return View();
                }

            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Downloading rent invoice as pdf
        /// </summary>
        /// <param name="carRentId"></param>
        /// <returns></returns>
        public ActionResult DownloadRentInvoice(string carRentId)
        {
            _invoiceRentId = carRentId;
            return new Rotativa.ActionAsPdf("GenerateRentInvoice");
        }
        /// <summary>
        /// Get method for getting car details for purchase invoice
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <returns>Requests for invoice</returns>
        [HttpGet, UserSessionManagement]
        public ActionResult Invoice(string purchaseId)
        {
            try
            {
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"] == null ? "" : Session["token"].ToString());
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("Transaction/GeneratePurchasePDF/" + new Guid(purchaseId)).Result;
                if (response.IsSuccessStatusCode)
                {
                    return View(response.Content.ReadAsAsync<PdfVM>().Result);
                }
                else if(response.StatusCode== HttpStatusCode.InternalServerError)
                {
                    TempData["message"] = "Network related error occured";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }

            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Generating purchase invoice
        /// </summary>
        /// <returns>Display purchase invoice</returns>
        public ActionResult GenerateInvoice()
        {
            Guid purchaseId = new Guid(_invoicePurchaseId);
            try
            {

                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("Transaction/GeneratePurchasePDF/" + purchaseId).Result;
                if (response.IsSuccessStatusCode)
                {
                    return View(response.Content.ReadAsAsync<PdfVM>().Result);
                }
                else
                {
                    return View();
                }

            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Downloading invoice for purchase as pdf
        /// </summary>
        /// <param name="purchaseId"></param>
        /// <returns></returns>
        public ActionResult DownloadInvoice(string purchaseId)
        {
            _invoicePurchaseId=purchaseId;
            return new Rotativa.ActionAsPdf("GenerateInvoice");
        }

        /// <summary>
        /// enters purchase entry data into database
        /// </summary>
        /// <param name="carPurchaseModel"></param>
        /// <returns></returns>
        private Guid GetPuchaseEntry(CarPurchaseModel carPurchaseModel)
        {
            try
            {
                var record = WebHttpClient.webAPIClient.PostAsJsonAsync<CarPurchaseModel>("Transaction/Purchase", carPurchaseModel);
                record.Wait();
                if (record.Result.IsSuccessStatusCode)
                {
                    string purchaseId = record.Result.Content.ReadAsAsync<string>().Result;
                    return new Guid(purchaseId);
                }
                else
                {
                    return new Guid();
                }

            }
            catch (Exception)
            {
                return new Guid();
            }
        }

        /// <summary>
        ///  enters rent entry data into database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private Guid DoRentEntry(CarRentModel model)
        {
            try
            {
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"] == null ? "" : Session["token"].ToString());
                var record = WebHttpClient.webAPIClient.PostAsJsonAsync<CarRentModel>("Transaction/CarRent", model);
                record.Wait();
                if (record.Result.IsSuccessStatusCode)
                {
                    string rentId = record.Result.Content.ReadAsAsync<string>().Result;
                    return new Guid(rentId);
                }
                else
                {
                    return new Guid();
                }

            }
            catch (Exception)
            {
                return new Guid();
            }
        }

        /// <summary>
        /// Get car by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View of get cars by id</returns>
        private Car GetCar(Guid? id)
        {
            try
            {
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("Car/GetCar/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<Car>().Result;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// shows cars by category
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Get cars by category</returns>
        [HttpGet]
        private IEnumerable<Car> getCars(string category)
        {
            try
            {
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("Car/ShowCarsByCategory/" + category).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<Car>>().Result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>
        /// Serach on landing page
        /// </summary>
        /// <returns></returns>
        public ActionResult LandingSearch()
        {
            return View();
        }

        /// <summary>
        /// FAQs (Frequently asked questions) and their answers
        /// </summary>
        /// <returns>View of FAQ</returns>
        public ActionResult FAQ()
        {
      
            try
            {
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("FAQ/GetAll").Result;
                if (response.IsSuccessStatusCode)
                {
                    return View(response.Content.ReadAsAsync<IEnumerable<FAQ>>().Result);
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// About us page of website
        /// </summary>
        /// <returns>View of about us page</returns>
        public ActionResult AboutUs()
        {
            return View();
        }

        /// <summary>
        /// Get method of Contact us page
        /// </summary>
        /// <returns>View of contact us page</returns>
        public ActionResult ContactUs()
        {
            return View();
        }
        /// <summary>
        /// Post method of contact us page
        /// </summary>
        /// <param name="contactUs"></param>
        /// <returns>Posts data of contact us to database</returns>
        [HttpPost]
        public ActionResult ContactUs(ContactUs contactUs)
        {

            try
            {
                var record = WebHttpClient.webAPIClient.PostAsJsonAsync<ContactUs>("Support/Create", contactUs);
                record.Wait();
                var saveRecord = record.Result;
                if (saveRecord.IsSuccessStatusCode)
                {
                    TempData["message"] = "Your query submitted successfully";
                    return RedirectToAction("Index");
                } 
                else
                    return RedirectToAction("ContactUs");
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Get method of feedback page
        /// </summary>
        /// <returns>View of feedback page</returns>
        public ActionResult Feedback()
        {
            return View();
        }

        /// <summary>
        ///  Post method of feedback page
        /// </summary>
        /// <param name="feedback"></param>
        /// <returns>Posts data of feedback to database</returns>
        [HttpPost]
        public ActionResult Feedback(Feedback feedback)
        {
            try
            {
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"] == null ? "" : Session["token"].ToString());
                var record = WebHttpClient.webAPIClient.PostAsJsonAsync<Feedback>("Support/CreateFeedback", feedback);
                record.Wait();
                var saveRecord = record.Result;
                if (saveRecord.IsSuccessStatusCode)
                {
                    TempData["message"] = "Your feedback submitted successfully";
                    return RedirectToAction("Index");
                }
                    
                else
                    return RedirectToAction("Feedback");
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Method to compare cars
        /// </summary>
        /// <returns></returns>
        public ActionResult CompareCars()
        {
            return View();
        }

        /// <summary>
        /// Method for top 10 cars
        /// </summary>
        /// <returns>View of Top 10 cars</returns>
        public ActionResult Top10Cars()
        {
            try
            {
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("Car/TopCars/true").Result;
                if (response.IsSuccessStatusCode)
                {
                    return View(response.Content.ReadAsAsync<IEnumerable<Car>>().Result);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {

                return View();
            }
        }
        /// <summary>
        /// logout
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }
        [UserSessionManagement]
        public ActionResult UserPurchaseHistory()
        {
            try
            {
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("Car/GetAllPurchaseHistory").Result;
                if (response.IsSuccessStatusCode)
                {
                    return View(response.Content.ReadAsAsync<IEnumerable<PdfVM>>().Result);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {

                return View();
            }
        }
        [UserSessionManagement]
        public ActionResult UserRentHistory()
        {
            try
            {
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"] == null ? "" : Session["token"].ToString());
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("Car/GetAllRentHistory").Result;
                if (response.IsSuccessStatusCode)
                {
                    return View(response.Content.ReadAsAsync<IEnumerable<RentPdfVM>>().Result);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {

                return View();
            }
        }
        /// <summary>
        /// Post Method for login
        /// checks credentials
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <param name="url"></param>
        /// <returns>Matches user credentials from databse</returns>
        [HttpPost]
        public ActionResult Login(string Email,string Password,string url)
        {
            if (ModelState.IsValid)
            {
                if(DoLogin(new UserLoginVM { Email = Email, Password = Password }))
                {
                    return Json(new { Message = "success", JsonRequestBehavior.AllowGet });
                }
                else
                {
                    return Json(new { Message = "failure", JsonRequestBehavior.AllowGet });
                }
            }
            else
            {
                return Json(new { Message = "failure", JsonRequestBehavior.AllowGet });
            }
        }

        /// <summary>
        /// Register page
        /// </summary>
        /// <returns>Shows register page to user</returns>
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Post method for register page
        /// </summary>
        /// <param name="Image"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost,HandleError]
        public ActionResult Register(HttpPostedFileBase Image, UserRegistrationVM model)
        {
            if (ModelState.IsValid)
            {
                if (DoRegister(SaveImage(Image),model))
                {
                    TempData["message"] = "User Registered! Please login now";
                    return RedirectToAction("LoginPage");
                }
                else
                {
                    ModelState.AddModelError("Failure", "Email is already exist");
                    ViewBag.EmailError = "Email is already exist";
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("Failure", "Validation failed");
                return View(model);
            }
        }

        /// <summary>
        /// method for saving image
        /// </summary>
        /// <param name="SmallImageUrl"></param>
        /// <returns></returns>
        private string SaveImage(HttpPostedFileBase SmallImageUrl)
        {
            string path = Server.MapPath("~/Uploads/UsersImages/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string dateTime = DateTime.Now.ToString().Replace(@"-", "").Replace(@"/", "").Replace(@":", "").Trim();
            string smallfileName = "User" + dateTime + ".jpg";
            SmallImageUrl.SaveAs(path + smallfileName);
            return smallfileName;
        }

        /// <summary>
        /// private method for saving user register details
        /// </summary>
        /// <param name="Image"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        private bool DoRegister(string Image,UserRegistrationVM user)
        {
            try
            {
                User model = new User
                {
                    Email = user.Email,
                    Name = user.Name,
                    Image = Image,
                    Password = user.Password,
                    ContactNo = user.ContactNo,
                    CreatedAt = DateTime.Now,
                    AddressId = new Guid("eb53730d-ba07-41b1-9787-be724cb40160")
                };
                var record = WebHttpClient.webAPIClient.PostAsJsonAsync<User>("user/Create", model) ;
                record.Wait();
                var saveRecord = record.Result;
                if (saveRecord.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// User Login window
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginPage()
        {
            var loadMessage = TempData["message"];
            if (loadMessage != null)
            {
                ViewBag.Message = loadMessage.ToString();
            }
            return View();
        }

        /// <summary>
        /// Method for user login
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Redirects to index page if user enters correct crendentials</returns>
        [HttpPost,HandleError]
        public ActionResult LoginPage(UserLoginVM model)
        {
            if (ModelState.IsValid)
            {
                if (DoLogin(model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Invalid = "Invalid credentials";
                    return View(model);
                }
            }
            else
            {
                ViewBag.Invalid = "Validation error!!";
                return View(model);
            }
        }

        /// <summary>
        /// Get method of forgot password
        /// </summary>
        /// <returns></returns>
        public ActionResult ForgotPassword()
        {
            return View();
        }

        /// <summary>
        /// Post method for forgot password
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost]
        public string ForgotPassword(string email)
        {
            try
            {
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("User/ForgotPassword/?email="+ email).Result;
                var res =response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["message"] = "We have sent a email to your address";
                    TempData["otp"] = res.ToString();
                    return res.ToString();
                }
                else
                {
                    TempData["message"] = "Some error occured!!";
                    return "-1";
                }
            }
            catch (Exception)
            {
                return "-1";
            }
        }
        [HttpPost]
        public string VerifyPincode(string Pincode)
        {
            try
            {
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("AddressSupport/PincodeCheck/?pincode=" + Pincode).Result;
                var res = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    if(res.ToString()== "\"Avaiable\"")
                    {
                        return "Avalable";
                    }
                    else
                    {
                        return "NotAvalable";
                    }
                }
                else
                {
                    return "Error";
                }
            }
            catch (Exception)
            {
                return "Error";
            }
        }
        [UserSessionManagement]
        public ActionResult UserProfile()
        {
            var loadMessage = TempData["message"];
            if (loadMessage != null)
            {
                ViewBag.Message = loadMessage.ToString();
            }
            User user = getUserDetails();
            if (user == null)
            {
                return RedirectToAction("LoginPage");
            }
            else
            {
                return View(user);
            }
        }
        [HttpPost,UserSessionManagement]
        public ActionResult UpdateProfile(HttpPostedFileBase userImage,string name,string mobile)
        {
            string imageName="";
            if (userImage != null)
                imageName=SaveImage(userImage);
            if (updateUserDetails(imageName, name, mobile))
            {
                TempData["message"] = "Your Profile has been Updated!";
                return RedirectToAction("UserProfile");
            }
            else
            {
                return RedirectToAction("UserProfile");
            }

        }

        private bool updateUserDetails(string image, string name, string mobile)
        {
            try
            {
                User model = new User
                {
                    Name = name,
                    Image = image,
                    ContactNo = mobile,
                    ModifiedAt = DateTime.Now
                };
                var record = WebHttpClient.webAPIClient.PutAsJsonAsync<User>("user/Update", model);
                record.Wait();
                var saveRecord = record.Result;
                if (saveRecord.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private User getUserDetails()
        {
            try
            {
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"] == null ? "" : Session["token"].ToString());
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("User/Get").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<User>().Result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        [HttpPost]
        public bool ConfirmOTP(string otp)
        {
            if(otp == TempData["otp"].ToString())
            {
                return true;
            }
            return false;
        }

        [HttpPost]
        public bool ResetPassword(string email)
        {
            TempData["email"] = email;
            return true;
        }

        public ActionResult ResetPassword()
        {
            ViewBag.Email = TempData["email"];
            return View();
        }
        [HttpPost]
        public ActionResult AddReview(string carId, int rating,string ratingTitle,string ratingDiscription)
        {
            if(carId!=null && carId != "")
            {
                RatingVM ratingVM = new RatingVM
                {
                    CarId = new Guid(carId),
                    Rating = rating,
                    Title = ratingTitle,
                    Discription = ratingDiscription,
                    CreatedAt = DateTime.Now
                };
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"] == null ? "" : Session["token"].ToString());
                var record = WebHttpClient.webAPIClient.PostAsJsonAsync<RatingVM>("Car/AddRating", ratingVM);
                record.Wait();
                var saveRecord = record.Result;
                if (saveRecord.IsSuccessStatusCode)
                {
                    TempData["message"] = "Your review submitted successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("LoginPage");
            }
        }
        [HttpPost]
        public ActionResult ChangePassowrd(string email, string pass)
        {
            AdminLoginVM store = new AdminLoginVM()
            {
                Email = email,
                Passowrd = pass
            };

            WebHttpClient.webAPIClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"] == null ? "" : Session["token"].ToString());
            var record = WebHttpClient.webAPIClient.PostAsJsonAsync<AdminLoginVM>("User/setPassword", store);
            record.Wait();
            var saveRecord = record.Result;
            if (saveRecord.IsSuccessStatusCode)
            {
                TempData["message"] = "Your password has been Updated!";
                return RedirectToAction("UserProfile");
            }
            else
            {
                return RedirectToAction("ForgotPassword");
            }
        }
        [HttpPost]
        public int SetPassword(string email, string pass)
        {
            AdminLoginVM store = new AdminLoginVM()
            {
                Email = email,
                Passowrd = pass
            };

            WebHttpClient.webAPIClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"] == null ? "" : Session["token"].ToString());
            var record = WebHttpClient.webAPIClient.PostAsJsonAsync<AdminLoginVM>("User/setPassword", store);
            record.Wait();
            var saveRecord = record.Result;
            if (saveRecord.IsSuccessStatusCode)
            {
                TempData["message"] = "Password Reset Successfully.";
                return 1;
            }
            else
            {
                TempData["message"] = "Something went wrong.";
                return -1;
            }
        }

        /// <summary>
        /// private method for saving user login details
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Saves user details</returns>
        private bool DoLogin(UserLoginVM model)
        {
            try
            {
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Add("UserType", "User");
                var form = new Dictionary<string, string>
                {
                    {"grant_type", "password"},
                    {"username", model.Email},
                    {"password", model.Password}
                };
                var content = new FormUrlEncodedContent(form);
                var record = WebHttpClient.webAPIClient.PostAsync("token", content);
                record.Wait();

                var response = record.Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseStream = response.Content.ReadAsStringAsync().Result;
                    MyCarApp.BE.ViewModels.Token token = JsonConvert.DeserializeObject<MyCarApp.BE.ViewModels.Token>(responseStream);
                    Session["token"] = token.AccessToken;
                    Debug.WriteLine(token.AccessToken);
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
