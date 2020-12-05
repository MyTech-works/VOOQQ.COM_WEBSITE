using VOOQQ_APP.CustomFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace VOOQQ_APP.Controllers
{
    public class UsersController : Controller
    {
       [AuthLog(Roles = "User")]
        public ActionResult Index()
        {
            return View();
        }
    }
}