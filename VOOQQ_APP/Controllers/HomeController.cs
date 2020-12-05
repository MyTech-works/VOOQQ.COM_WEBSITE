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

    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Categories()
        {
            if (User.Identity.GetUserId() != null)
            {

                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

             
        }
        public ActionResult Success()
        {
          
            return View();
        }
        public ActionResult Cancel()
        {

            return View();
        }
        public ActionResult Search(string customword,string Location ,int Vid)
                         {
            ViewBag.AuditoriumCategory = db.AuditoriumCategory.ToList();

            Location = Location == null ? "" : Location;
            customword = customword == null ? "" : customword;
            Vid = Vid == null ? 1 : Vid;
            SqlParameter[] Parameters = {
                new SqlParameter("@Vid", Vid),
                new SqlParameter("@Location", Location),
                new SqlParameter("@customword", customword),
            };



            var data = db.Database.SqlQuery<MyAccountModel>("dbo.Sp_MyaccountlistSearch @Vid, @Location, @customword", Parameters).ToList();
            return View(data);
        }
         public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public class Searchlist
        {
           
            public string customword { get; set; }
            public string Location { get; set; }
            public long VId { get; set; }
           
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}