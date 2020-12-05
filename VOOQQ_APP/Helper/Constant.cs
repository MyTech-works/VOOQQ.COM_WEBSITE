using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VOOQQ_APP.Helper
{
   public  class Constant
    {

       public string RegistrationEmailContent = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/HtmlPage/RegistrationEmail.html"));
    }
   public static class RazorPayConst
   {
        //////////////test////////////
        //public const string Api_Key = "rzp_test_w3ObbNzolURQmj";
        //public const string Key_Secret = "3U0cVhHWNe4j4hXqQ4wQ9Qrd";

        public const string Api_Key = "rzp_live_5kgOLvrtERMvUF";
        public const string Key_Secret = "OVzMPiQ2QjQX74fYSwcnp7ah";
        //////////live////////////
        //public const string Api_Key = "rzp_live_QhW9OyfoN0VUYT";
        //public const string Key_Secret = "8m0uKPhsJVzOOHb5TrVzVTuY";
    }
}