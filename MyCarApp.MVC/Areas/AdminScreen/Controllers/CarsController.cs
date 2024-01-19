using MyCarApp.BE.BussinessEntities;
using MyCarApp.BE.ViewModels;
using MyCarApp.Common.Enums;
using MyCarApp.Common.WebClient;
using MyCarApp.MVC.Filters.AdminIndentityFilter;
using PagedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace MyCarApp.MVC.Areas.AdminScreen.Controllers
{
    [AdminSessionManagement]
    public class CarsController : Controller
    {
        /// <summary>
        /// shows all cars
        /// </summary>
        /// <returns>get cars</returns>
        public ActionResult AllCars(int? page)
        {
            fillNotification();
            IEnumerable<Car> cars = GetCars();
            if (cars == null)
            {
                return RedirectToAction("login", "admin");
            }
            return View("Vehicles",cars.ToList().ToPagedList(page ?? 1, 8));
        }

        /// <summary>
        /// Method for get car by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Get car by id</returns>
        public ActionResult Car(Guid? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = GetCar(Id);
            return View(car);
        }

        /// <summary>
        /// Method for get countries
        /// </summary>
        /// <returns>Shows all countries</returns>
        public ActionResult GetCountries()
        {
            try
            {
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("AddressSupport/Countries").Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json(response.Content.ReadAsAsync<IEnumerable<Country>>().Result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Method for get states from country id
        /// </summary>
        /// <param name="CountryId"></param>
        /// <returns>Shows all states of selected country</returns>
        public ActionResult GetStates(Guid CountryId)
        {
            try
            {
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("AddressSupport/States?CountryId=" + CountryId).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json(response.Content.ReadAsAsync<IEnumerable<State>>().Result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Method for get cities from state id
        /// </summary>
        /// <param name="StateId"></param>
        /// <returns>Shows all cities of selected state</returns>
        public ActionResult GetCities(Guid StateId)
        {
            try
            {
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("AddressSupport/Cities?StateId=" + StateId).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json(response.Content.ReadAsAsync<IEnumerable<City>>().Result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Method for get pincodes from city id
        /// </summary>
        /// <param name="CityId"></param>
        /// <returns>Shows all pincodes of selected city</returns>
        public ActionResult GetPincodes(Guid CityId)
        {
            try
            {
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("AddressSupport/Pincodes?CityId=" + CityId).Result;
                if (response.IsSuccessStatusCode)
                {
                    return Json(response.Content.ReadAsAsync<IEnumerable<Pincode>>().Result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// private method for saving car details 
        /// fetch car details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// Method for adding car
        /// </summary>
        /// <returns></returns>
        public ActionResult AddCar()
        {
            ViewBag.CarCategoryId = new SelectList(FillCategoryDropdown(), "Id", "Name");
            var brands = new List<ConvertEnum>();
            foreach (BrandEnum brand in Enum.GetValues(typeof(BrandEnum)))
                brands.Add(new ConvertEnum
                {
                    Value = (int)brand,
                    Text = brand.ToString()
                });
            ViewBag.Brand = brands;
            return View();
        }

        /// <summary>
        ///  Method for saving image
        /// </summary>
        /// <param name="SmallImageUrl"></param>
        /// <returns></returns>
        private string SaveImage(HttpPostedFileBase SmallImageUrl)
        {
            string path = Server.MapPath("~/Uploads/CarsImages/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string dateTime = DateTime.Now.ToString().Replace(@"-", "").Replace(@"/", "").Replace(@":", "").Trim();
            string smallfileName = "Car" + dateTime + ".jpg";
            SmallImageUrl.SaveAs(path + smallfileName);
            return smallfileName;
        }

        /// <summary>
        /// Post method for adding car
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Image"></param>
        /// <returns>Adds car and its details in the database</returns>
        [HttpPost,HandleError,ValidateAntiForgeryToken]
        public ActionResult AddCar(Car model, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (SaveCarDetails(SaveImage(Image), model))
                {
                    createNotification("green", model.Name+" Added successfully");
                    return RedirectToAction("AllCars");
                }
                else
                {
                    createNotification("red", "Some error occured");
                    return RedirectToAction("AllCars");
                }
            }
            createNotification("red", "Validation Failed");
            return RedirectToAction("AllCars");
        }

        /// <summary>
        /// Get Method for editing car details
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult EditCar(Guid? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = GetCar(Id);
            var brands = new List<ConvertEnum>();
            foreach (BrandEnum brand in Enum.GetValues(typeof(BrandEnum)))
                brands.Add(new ConvertEnum
                {
                    Value = (int)brand,
                    Text = brand.ToString()
                });
            ViewBag.Brand = brands;
            return View(car);
        }

        /// <summary>
        /// Post method for editing car details
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Saves edited data in the database</returns>
        [HttpPost,HandleError,ValidateAntiForgeryToken]
        public ActionResult EditCar(Car model)
        {
            if (ModelState.IsValid)
            {
                if (UpdateCarDetails(model))
                {
                    createNotification("blue", model.Name + " updated successfully");
                    return RedirectToAction("AllCars");
                }
                else
                {
                    createNotification("red", "Some error occured");
                    return RedirectToAction("AllCars");
                }
            }
            createNotification("red", "Some error occured");
            return RedirectToAction("AllCars");
        }

        /// <summary>
        /// Method for adding car varient
        /// </summary>
        /// <param name="carId"></param>
        /// <param name="carVarientPrice"></param>
        /// <param name="varientName"></param>
        [HttpPost,HandleError]
        public void AddVarient(Guid carId,decimal carVarientPrice,string varientName, HttpPostedFileBase varientImage)
        {
            if (SaveVarientDetails(SaveImage(varientImage), carId, carVarientPrice, varientName))
            {
                createNotification("blue", "Car Varient added successfully");
                Response.Redirect("/AdminScreen/Cars/Car?Id=" + carId);
            }
            else
            {
                Response.Redirect("/AdminScreen/Cars/Car?Id=" + carId);
            }
        }

        /// <summary>
        /// Adding address
        /// </summary>
        /// <param name="carId"></param>
        /// <param name="localAddress"></param>
        /// <param name="PincodeDropdown"></param>
        [HttpPost, HandleError]
        public void AddAddress(Guid carId,string localAddress,string PincodeDropdown)
        {
            if (SaveAddress(carId, localAddress, PincodeDropdown))
            {
                createNotification("blue", "Car Address added successfully");
                Response.Redirect("/AdminScreen/Cars/Car?Id=" + carId);
            }
            else
            {
                Response.Redirect("/AdminScreen/Cars/Car?Id=" + carId);
            }
        }

        /// <summary>
        /// Saving Address
        /// </summary>
        /// <param name="carId"></param>
        /// <param name="localAddress"></param>
        /// <param name="pincodeDropdown"></param>
        /// <returns>Save address</returns>
        private bool SaveAddress(Guid carId, string localAddress, string pincodeDropdown)
        {
            try
            {
                CarDetails carDetails = new CarDetails();
                carDetails.LocalAddress = localAddress;
                carDetails.CarId = carId;
                carDetails.PincodeId = new Guid(pincodeDropdown);
                
                var record = WebHttpClient.webAPIClient.PostAsJsonAsync("AddressSupport/CreateAddress", carDetails);
                record.Wait();
                var saveRecord = record.Result;
                if (saveRecord.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
            return false;
        }

        /// <summary>
        /// Method for saving car varient details
        /// </summary>
        /// <param name="carId"></param>
        /// <param name="carVarientPrice"></param>
        /// <param name="varientName"></param>
        /// <returns>Save car varient details</returns>
        private bool SaveVarientDetails(string varientImage,Guid carId, decimal carVarientPrice,string varientName)
        {
            try
            {
                CarVarient carVarient = new CarVarient();
                carVarient.carId = carId;
                carVarient.Price = carVarientPrice;
                carVarient.Name = varientName;
                carVarient.ModifiedAt = DateTime.Now;
                //carVarient.CreatedBy = new Guid(Session["adminId"].ToString());
                carVarient.CreatedAt = DateTime.Now;
                carVarient.Image = varientImage;    
                //carVarient.ModifiedBy = new Guid(Session["adminId"].ToString());
                var record = WebHttpClient.webAPIClient.PostAsJsonAsync("Car/AddVarient", carVarient);
                record.Wait();
                var saveRecord = record.Result;
                if (saveRecord.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
            return false;
        }

        /// <summary>
        /// Updates car details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private bool UpdateCarDetails(Car model)
        {
            try
            {
                model.Brand = ((BrandEnum)Convert.ToInt32(model.Brand)).ToString();
                //model.ModifiedBy = new Guid(Session["adminId"].ToString());
                model.ModifyAt = DateTime.Now;
                var record = WebHttpClient.webAPIClient.PutAsJsonAsync("Car/Update", model);
                record.Wait();
                var saveRecord = record.Result;
                if (saveRecord.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            return false;
        }

        /// <summary>
        /// Save car details
        /// </summary>
        /// <param name="Image"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        private bool SaveCarDetails(string Image,Car model)
        {
            try
            {
                model.Brand=((BrandEnum)Convert.ToInt32(model.Brand)).ToString();
                model.CreatedAt = DateTime.Now;
                model.ModifyAt = DateTime.Now;
                model.Image = Image;
                var record = WebHttpClient.webAPIClient.PostAsJsonAsync("Car/Add", model);
                record.Wait();
                var saveRecord = record.Result;
                if (saveRecord.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            return false;
        }

        /// <summary>
        /// Dropdown for selecting car category
        /// </summary>
        /// <returns></returns>
        private IEnumerable<CustomDropdown> FillCategoryDropdown()
        {
            try
            {
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("Car/GetCateogry").Result;
                return response.Content.ReadAsAsync<IEnumerable<CustomDropdown>>().Result;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Delete car
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult DeleteCar(Guid? Id)
        {
            try
            {
                if (Id != null)
                {
                    HttpResponseMessage deleteResponse = WebHttpClient.webAPIClient.DeleteAsync("Car/Delete/" + Id).Result;
                    createNotification("red", "Car deleted successfully");
                    return RedirectToAction("AllCars");
                }
                else
                {
                    return HttpNotFound();
                }

            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Shows all cars
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Car> GetCars()
        {
            try
            {
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"]==null?"":Session["token"].ToString());
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("Car/GetAll").Result;
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
        /// display notifications
        /// </summary>
        private void fillNotification()
        {
            try
            {
                var loadMessage = TempData["message"];
                var createMessage = (CreateMessageNotificationModel)loadMessage;
                if (createMessage != null)
                {
                    ViewBag.Message = createMessage.message;
                    ViewBag.Color = createMessage.color;
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Create notifications
        /// </summary>
        /// <param name="color"></param>
        /// <param name="message"></param>
        private void createNotification(string color, string message)
        {
            CreateMessageNotificationModel createMessageNotificationModel = new CreateMessageNotificationModel();
            createMessageNotificationModel.message = message;
            createMessageNotificationModel.color = color;
            TempData["message"] = createMessageNotificationModel;
        }
    }
}
