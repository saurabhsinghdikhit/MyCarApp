using ClosedXML.Excel;
using MyCarApp.BE.BussinessEntities;
using MyCarApp.BE.ViewModels;
using MyCarApp.Common.WebClient;
using MyCarApp.MVC.Filters.AdminIndentityFilter;
using Newtonsoft.Json;
using PagedList;
using Stripe;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyCarApp.MVC.Areas.AdminScreen.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminScreen/Admin

        /// <summary>
        /// Get method of login for admin
        /// </summary>
        /// <returns>Login view</returns>
        public ActionResult Login()
        {
            return View();
        }
        [AdminSessionManagement]
        public ActionResult ShowFeedbacks()
        {
            try
            {
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"] == null ? "" : Session["token"].ToString());
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("Feedback/GetAll").Result;
                if (response.IsSuccessStatusCode)
                {
                    return View(response.Content.ReadAsAsync<IEnumerable<Feedback>>().Result);
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
        [HttpGet, AdminSessionManagement]
        public ActionResult RentRefund()
        {
            var loadMessage = TempData["message"];
            if (loadMessage != null)
            {
                ViewBag.Message = loadMessage.ToString();
            }
            try
            {
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"] == null ? "" : Session["token"].ToString());
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("admin/GetAllPendingRefund?IsRent=true").Result;
                if (response.IsSuccessStatusCode)
                {
                    return View(response.Content.ReadAsAsync<IEnumerable<CarRent>>().Result);
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
        [HttpGet, AdminSessionManagement]
        public ActionResult ApproveRentRequest(string Response,Guid id)
        {
            try
            {
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"] == null ? "" : Session["token"].ToString());
                BE.ViewModels.UpdateStatus updateStatus = new BE.ViewModels.UpdateStatus()
                {
                    id = id,
                    IsRent = true
                };
                dynamic record=null;
                if(Response == "accept")
                {
                    record = WebHttpClient.webAPIClient.PostAsJsonAsync("user/StatusApprove", updateStatus).Result;
                    
                }else if(Response== "reject")
                {
                    record = WebHttpClient.webAPIClient.PostAsJsonAsync("user/StatusReject", updateStatus).Result;
                }
                string trasaction = record.Content.ReadAsStringAsync().Result;
                trasaction= trasaction.Remove(0, 1);
                trasaction = trasaction.Remove(trasaction.Length-1);
                if (true)
                {
                    if (Response == "accept")
                    {
                        StripeConfiguration.ApiKey = "sk_test_51IQnXsLfHfDp45guwO4cVJsIig8Mq9PaM6TnLkHVJ8Xj1tXuyVuuj8HKM7lailxCjjCbSFT3jgHU2ejqRF91bIhl00I9lHQaOh";
                        var options = new RefundCreateOptions
                        {
                            Charge = trasaction,
                            Reason = "Booking Cancellation",
                        };
                        var services = new RefundService();
                        var refund = services.Create(options);
                        if (refund.Status.Equals("succeeded"))
                        {
                            TempData["message"] = "Refund has been done";
                        }
                        /*if (trasaction != "")
                        {
                            TempData["message"] = "Refund has been done";
                        }*/
                        else
                        {
                            TempData["message"] = "Some error has been occured in refund";
                        }
                    }
                    else
                    {
                        TempData["message"] = "Request has been rejected";
                    }
                    return RedirectToAction("RentRefund");
                }
                else
                {
                    TempData["message"] = "some error occured";
                    return RedirectToAction("RentRefund");
                }
            }
            catch (Exception ex)
            {

                return RedirectToAction("RentRefund");
            }
        }
        [HttpGet, AdminSessionManagement]
        public ActionResult PurchaseRefund()
        {
            try
            {
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"] == null ? "" : Session["token"].ToString());
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("admin/GetAllPendingRefund?IsRent=false").Result;
                if (response.IsSuccessStatusCode)
                {
                    return View(response.Content.ReadAsAsync<IEnumerable<CarPurchase>>().Result);
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
        [HttpGet, AdminSessionManagement]
        public ActionResult ApprovePurchaseRequest(string Response, Guid id)
        {
            try
            {
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"] == null ? "" : Session["token"].ToString());
                BE.ViewModels.UpdateStatus updateStatus = new BE.ViewModels.UpdateStatus()
                {
                    id = id,
                    IsRent = false
                };
                dynamic record = null;
                if (Response == "accept")
                {
                    record = WebHttpClient.webAPIClient.PostAsJsonAsync("user/StatusApprove", updateStatus).Result;

                }
                else if (Response == "reject")
                {
                    record = WebHttpClient.webAPIClient.PostAsJsonAsync("user/StatusReject", updateStatus).Result;
                }
                string trasaction = record.Content.ReadAsStringAsync().Result;
                trasaction = trasaction.Remove(0, 1);
                trasaction = trasaction.Remove(trasaction.Length - 1);
                if (true)
                {
                    if (Response == "accept")
                    {
                        StripeConfiguration.ApiKey = "sk_test_51IQnXsLfHfDp45guwO4cVJsIig8Mq9PaM6TnLkHVJ8Xj1tXuyVuuj8HKM7lailxCjjCbSFT3jgHU2ejqRF91bIhl00I9lHQaOh";
                        var options = new RefundCreateOptions
                        {
                            Charge = trasaction
                        };
                        var services = new RefundService();
                        var refund = services.Create(options);
                        if (refund.Status.Equals("succeeded"))
                        {
                            TempData["message"] = "Refund has been done";
                        }
                        /*if (trasaction != "")
                        {
                            TempData["message"] = "Refund has been done";
                        }*/
                        else
                        {
                            TempData["message"] = "Some error has been occured in refund";
                        }
                    }
                    else
                    {
                        TempData["message"] = "Request has been rejected";
                    }
                    return RedirectToAction("PurchaseRefund");
                }
                else
                {
                    TempData["message"] = "some error occured";
                    return RedirectToAction("RentRefund");
                }
            }
            catch (Exception ex)
            {

                return RedirectToAction("RentRefund");
            }
        }
        [HttpPost,AdminSessionManagement]
        public FileResult ExportRentToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[7]
            { new DataColumn("CarName"),
            new DataColumn("CarVarientName"),
            new DataColumn("Price"),
            new DataColumn("UserName"),
            new DataColumn("UserAddress"),
            new DataColumn("StartDate"),
            new DataColumn("EndDate"),
            });

            var rentHistory = fillRentDetails();

            foreach (var purchase in rentHistory)
            {
                dt.Rows.Add(purchase.CarName, purchase.CarVarientName, purchase.Price, purchase.UserName,
                    purchase.UserAddress, purchase.StartDate, purchase.EndDate);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "RentHistory.xlsx");
                }
            }
        }

        private IEnumerable<RentPdfVM> fillRentDetails()
        {
            try
            {
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"] == null ? "" : Session["token"].ToString());
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("admin/GetAllRent").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<RentPdfVM>>().Result;
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

        [HttpPost,AdminSessionManagement]
        public FileResult ExportPurchaseToExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[9]
            { new DataColumn("CarName"),
            new DataColumn("CarVarientName"),
            new DataColumn("Price"),
            new DataColumn("UserName"),
            new DataColumn("UserAddress"),
            new DataColumn("DealerName"),
            new DataColumn("DealerAddress"),
            new DataColumn("DealerContact"),
            new DataColumn("Date"),
            });

            var purchaseHistory = fillPruchaseDetails();

            foreach (var purchase in purchaseHistory)
            {
                dt.Rows.Add(purchase.CarName, purchase.CarVarientName, purchase.Price, purchase.UserName,
                    purchase.UserAddress, purchase.DealerName, purchase.DealerAddress, purchase.DealerContact,
                    purchase.Date);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "PurchaseHistory.xlsx");
                }
            }
        }
        private IEnumerable<PdfVM> fillPruchaseDetails()
        {
            try
            {
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"] == null ? "" : Session["token"].ToString());
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("admin/GetAllPurchase").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<PdfVM>>().Result;
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
        [AdminSessionManagement]
        public ActionResult ShowContactUs()
        {
            try
            {
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"] == null ? "" : Session["token"].ToString());
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("Support/GetAll").Result;
                if (response.IsSuccessStatusCode)
                {
                    return View(response.Content.ReadAsAsync<IEnumerable<ContactUs>>().Result);
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
        [AdminSessionManagement]
        public ActionResult ShowRentHistory(int? page)
        {
            try
            {
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"] == null ? "" : Session["token"].ToString());
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("admin/GetAllRent").Result;
                if (response.IsSuccessStatusCode)
                {
                    return View(response.Content.ReadAsAsync<IEnumerable<RentPdfVM>>().Result.ToList().ToPagedList(page ?? 1, 8));
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
        [AdminSessionManagement]
        public ActionResult ShowPurchaseHistory(int? page)
        {
            try
            {
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["token"] == null ? "" : Session["token"].ToString());
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("admin/GetAllPurchase").Result;
                if (response.IsSuccessStatusCode)
                {
                    var param = response.Content.ReadAsAsync<IEnumerable<PdfVM>>().Result.ToList();
                    return View(param.ToPagedList(page ?? 1, 8));
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
        /// Post method for admin login
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Checks if the credentials entered are correct or not,
        /// If corrent then redirect to dashboard</returns>
        [HandleError,HttpPost,ValidateAntiForgeryToken]
        public ActionResult Login(AdminLoginVM model)
        {
            if (ModelState.IsValid)
            {
                if(DoLogin(model))
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    ViewBag.Invalid = "Invalid Credientials!";
                    return View();
                }
            }
            else
            {
                ViewBag.Invalid = "Validation error!!";
                return View();
            }
        }

        /// <summary>
        /// Method for saving login details of admin
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private bool DoLogin(AdminLoginVM model)
        {
            try
            {
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Clear();
                WebHttpClient.webAPIClient.DefaultRequestHeaders.Add("UserType", "Admin");
                var form = new Dictionary<string, string>
                {
                    {"grant_type", "password"},
                    {"username", model.Email},
                    {"password", model.Passowrd}
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
        [AdminSessionManagement]

        /// <summary>
        /// Admin dashboard
        /// </summary>
        /// <returns>View of admin dashboard</returns>
        public ActionResult Dashboard()
        {
            try
            {
                HttpResponseMessage response = WebHttpClient.webAPIClient.GetAsync("Charts/cars").Result;
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Cars = response.Content.ReadAsAsync<Dictionary<string, IEnumerable<TotalCarsVM>>>().Result;
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
        /// Method for logout
        /// </summary>
        /// <returns>Redirect to login page after successfull logout</returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}