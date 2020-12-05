using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VOOQQ_APP.CustomFilters;

namespace VOOQQ_APP.Controllers
{
    public class AdminController : Controller
    {
       [AuthLog(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View();
        }
    }
}