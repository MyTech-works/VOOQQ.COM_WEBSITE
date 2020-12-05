using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult ViewPlan(long? prime, long? vid, long? id, string userid, string amnt)
        {

          

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
        public ActionResult Success()
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
