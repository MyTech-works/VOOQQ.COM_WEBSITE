using Microsoft.AspNet.Identity;
using PagedList;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using VOOQQ_APP.Helper;
using VOOQQ_APP.Models;

namespace VOOQQ_APP.Controllers
{
    public class MyAccountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MyAccount
        public ActionResult Index(string UserId)
        {
           
            if (User.Identity.GetUserId()!=null)
            {
                var id = User.Identity.GetUserId();

                if (id.ToString() == "17f77cf4-b103-4bd8-b912-3ae38c666c2d")
                {
                    ViewBag.data = db.Database.SqlQuery<MyAccountModel>("[dbo].[Sp_MyaccountlistUser]").ToList();
                }
                else
                {
                    var UserIds  = User.Identity.GetUserId();
                    UserId = UserId == null  ? "" : UserIds;
                    SqlParameter[] Parameters = {
                    new SqlParameter("@UserId", UserIds.ToString())};

                    ViewBag.data = db.Database.SqlQuery<MyAccountModel>("[dbo].[Sp_MyaccountlistUser] @UserId", Parameters).ToList();
                }
                
            }

            else
            {

                return RedirectToAction("Login", "Account");
            }

            return View();
        }
        public string SendMailpayment(string email)
        {
            try
            {
                string message = System.IO.File.ReadAllText(Request.PhysicalApplicationPath + "MailTemplates\\veri.config");
                message = message.Replace("{UserName}", email).Replace("{Password}", "Registration");
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

                var senderEmail = new MailAddress("info@vooqq.com", "Vooqq.com");
                var receiverEmail = new MailAddress(email, "Receiver");
                var password = "Travel#123";
                var sub = "Registration With Order !";
                var body = message;


                var smtp = new SmtpClient
                {
                    Host = "mail.vooqq.com",
                    Port = 587,
                    EnableSsl = false,

                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };


                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = "Registration Confirmation",
                    IsBodyHtml = true,
                    Body = body

                })
                {
                    smtp.ServicePoint.MaxIdleTime = 1; /* without this the connection is idle too long and not terminated, times out at the server and gives sequencing errors */


                    smtp.Send(mess);

                }
                return "Please check your email";


            }
            catch (Exception ex)
            {
                return "Some Error";
            }
        }
        public string SendMail(string email)
        {
            try
            {
                string message = System.IO.File.ReadAllText(Request.PhysicalApplicationPath + "MailTemplates\\veri.config");
                message = message.Replace("{UserName}", email).Replace("{Password}", "Registration");
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

                var senderEmail = new MailAddress("info@vooqq.com", "Vooqq.com");
                var receiverEmail = new MailAddress(email, "Receiver");
                var password = "Travel#123";
                var sub = "Registration With Order !";
                var body = message;


                var smtp = new SmtpClient
                {
                    Host = "mail.vooqq.com",
                    Port = 587,
                    EnableSsl = false,

                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };


                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = "Registration Confirmation",
                    IsBodyHtml = true,
                    Body = body

                })
                {
                    smtp.ServicePoint.MaxIdleTime = 1; /* without this the connection is idle too long and not terminated, times out at the server and gives sequencing errors */


                    smtp.Send(mess);

                }
                return "Please check your email";


            }
            catch (Exception ex)
            {
                return "Some Error";
            }
        }
        public ActionResult Pay(long? prime, long? vid, long? id, string userid, string amnt)
        {
            
            var amnts = amnt.Replace(".","");
            var ids = DateTime.Now.ToString("mmddyyyy");
            RazorpayClient client = new RazorpayClient(RazorPayConst.Api_Key, RazorPayConst.Key_Secret);
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", amnts); // amount in the smallest currency unit
            options.Add("receipt", "order_id" + ids);
            options.Add("currency", "INR");
            options.Add("payment_capture", "1");
            Order order = client.Order.Create(options);

            List<Order> payments = client.Order.All();
            string datas = payments[0]["id"];
            ViewBag.receipt = datas;
            ViewBag.userid = User.Identity.GetUserId();
         
            ViewBag.vid = vid;
            ViewBag.id = id;
            ViewBag.prime = prime;
            ViewBag.email = User.Identity.Name;


            RazorPayPaymentDetails clients = new RazorPayPaymentDetails();
            clients.Amount = Convert.ToDouble(amnt);
            clients.Currency = "INR";
            clients.Captured = "Paid";
            clients.RazorpayOrderId = ids;
            clients.MerchantOrderId = "vooq.com";
            clients.PaymentId = User.Identity.GetUserId();
            clients.PaymentDate = DateTime.Now;
            db.RazorPayPaymentDetails.Add(clients);
            db.SaveChanges();

            return View();
        }
        public ActionResult Success(long? prime, long? vid, long? id, string userid)
        {
            try
            {
                userid = userid == null ? "" : userid;
                id = id == null ? 0 : id;
                prime = prime == null ? 0 : prime;
                vid = vid == null ? 0 : vid;

                SqlParameter[] Parameters = { new SqlParameter("@PlanMasterId", prime), new SqlParameter("@vid", vid),
              new SqlParameter("@RefId", id),
            new SqlParameter("@UserId", userid) };
                ViewBag.data = db.Database.SqlQuery<string>("[dbo].[spUpdatePlanForAds] @PlanMasterId,@vid,@RefId,@UserId", Parameters).ToList();
                ViewBag.addsId = id;
            }
            catch (Exception ex)
            { 
               
                return RedirectToAction("Failure");
            }
            return View();
        }
        public ActionResult Failure(long? prime, long? vid, long? id, string userid)
        {
            try
            {
                //userid = userid == null ? "" : userid;
                //id = id == null ? 0 : id;
                //prime = prime == null ? 0 : prime;
                //vid = vid == null ? 0 : vid;

                //SqlParameter[] Parameters = { new SqlParameter("@prime", prime), new SqlParameter("@vid", vid) };
                //ViewBag.data = db.Database.SqlQuery<PlanMasters>("[dbo].[Sp_GetPlanDetails] @prime,@vid", Parameters).ToList();
                //ViewBag.addsId = id;


             
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
           
            return View();
        }
        public ActionResult ViewPlan(long? prime, long? vid, long? id, string userid)
        {
            userid = userid == null ? "" : userid;
            id = id == null ? 0 : id;
            prime = prime == null ? 0 : prime;
            vid = vid == null ? 0 : vid;

            SqlParameter[] Parameters = { new SqlParameter("@prime", prime), new SqlParameter("@vid", vid) };
            ViewBag.data = db.Database.SqlQuery<PlanMasters>("[dbo].[Sp_GetPlanDetails] @prime,@vid", Parameters).ToList();
            ViewBag.addsId = id;
           
            return View();
        }
        public ActionResult AddsManage()
        {
            ViewBag.data = db.Database.SqlQuery<MyAccountModelcount>(" [dbo].[Sp_MyaccountlistUserCount]").ToList();

            return View();
        }

        public ActionResult Views()
        {
            ViewBag.data = db.Database.SqlQuery<MyAccountModelcount>(" [dbo].[Sp_MyaccountlistUserCount]").ToList();

            return View();
        }
        public ActionResult Dashboard()
        {
            ViewBag.data = db.Database.SqlQuery<MyAccountModelcount>(" [dbo].[Sp_MyaccountlistUserCount]").ToList();
           



            return View();
        }
        public ActionResult Payments()
        {
            ViewBag.data = db.RazorPayPaymentDetails.ToList();
            return View();
        }
        public ActionResult Index1()
        {
            return View(db.RealEstates.ToList());
        }
        public ActionResult UsersList()
        {
            ViewBag.data = db.Database.SqlQuery<MyAccountModel1>("[dbo].[Sp_MyaccountUserslist]").ToList();
            return View();
        }
        // GET: MyAccount/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MyAccount/Create
        public ActionResult Create()
        {
            return View();
        }
        
        public ActionResult Failed()
        {
            return View();
        }

        // POST: MyAccount/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

              return RedirectToAction("Index", "MyAccount");
            }
            catch
            {
                return View();
            }
        }

        // GET: MyAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MyAccount/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

              return RedirectToAction("Index", "MyAccount");
            }
            catch
            {
                return View();
            }
        }

        // GET: MyAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MyAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

              return RedirectToAction("Index", "MyAccount");
            }
            catch
            {
                return View();
            }
        }
    }
}
