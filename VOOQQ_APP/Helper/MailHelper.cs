using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace VOOQQ_APP.Helper
{
    public class MailHelper
    {
        public string SendMail(string email ,string url)
        {
            try
            {
                string message = System.IO.File.ReadAllText(url);
                message = message.Replace("{UserName}", email).Replace("{Password}", "Registration");
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

                var senderEmail = new MailAddress("customercare@bigshopr.com", "Vooqq.com");
                var receiverEmail = new MailAddress(email, "Receiver");
                var password = "GoDaddy!695";
                var sub = "Registration With Order !";
                var body = message;


                var smtp = new SmtpClient
                {
                    Host = "smtpout.asia.secureserver.net",
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
               return("Please check your email");


            }
            catch (Exception ex)
            {
                return ("Some Errorl");
               
            }
        }
        public string vrifySendMail(string email,string clbk, string url)
        {
            try
            {
                string message = System.IO.File.ReadAllText(url);
                message = message.Replace("{UserName}", email).Replace("{Password}", clbk);
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

                var senderEmail = new MailAddress("info@vooqq.com", "Vooqq.com");
                var receiverEmail = new MailAddress(email, "Receiver");
                var password = "Travel#123";
                var sub = "Reset Password ";
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
                return ("Please check your email");


            }
            catch (Exception ex)
            {
                return ("Some Errorl");

            }
        }
    }
}