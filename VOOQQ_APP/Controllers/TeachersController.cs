using Microsoft.AspNet.Identity;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VOOQQ_APP.Helper;
using VOOQQ_APP.Models;

namespace VOOQQ_APP.Controllers
{
    public class TeachersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult UpdateStatusTrue(long? id)
        {
            Teacher forsale = db.Teachers.Find(id);
            forsale.Status = true;
            db.Entry(forsale).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AddsManage", "MyAccount");
        }
        public ActionResult UpdateStatusFalse(long? id)
        {
            Teacher forsale = db.Teachers.Find(id);
            forsale.Status = false;
            db.Entry(forsale).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AddsManage", "MyAccount");
        }
         public ActionResult Pay(long? prime, long? vid, long? id, string userid ,string amnt)
        {
            Teacher forsale = db.Teachers.Find(id);
            DateTime _date = Convert.ToDateTime(DateTime.Now);
            _date = _date.AddDays(365);


            forsale.UserId = User.Identity.GetUserId();

            forsale.Status = true;
            forsale.Date = DateTime.Now;
            forsale.EndDate = _date;
            forsale.StratDate = DateTime.Now;

            db.Entry(forsale).State = EntityState.Modified;
            db.SaveChanges();
            var ids = DateTime.Now.ToString("mmddyyyy");
            RazorpayClient client = new RazorpayClient(RazorPayConst.Api_Key, RazorPayConst.Key_Secret);
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", amnt); // amount in the smallest currency unit
            options.Add("receipt", "order_id" + ids);
            options.Add("currency", "INR");
            options.Add("payment_capture", "1");
            Order order = client.Order.Create(options);

            List<Order> payments = client.Order.All();
            string datas = payments[0]["id"];
            ViewBag.receipt = datas;

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


        // GET: Teachers
        public ActionResult Index(int? Vid, string Location, string GenderId, string QualifiedTeachinglevelsId, string SubjectId, string Availability)
        {
            
            ViewBag.Subject = db.Subject.ToList();
            ViewBag.QualifiedTeachinglevels = db.T_QualifiedLevels.ToList();
            ViewBag.Gender = db.T_Gender.ToList();
            ViewBag.Availability = db.t_Availabilities.ToList();


            Vid = Vid == null ? 1 : Vid;
            QualifiedTeachinglevelsId = QualifiedTeachinglevelsId == null || QualifiedTeachinglevelsId == "" ? "0" : QualifiedTeachinglevelsId;
            Availability = Availability == null || Availability == "" ? "0" : Availability;
            GenderId = GenderId == null || GenderId == "" ? "0" : GenderId;
            SubjectId = SubjectId == null || SubjectId == "" ? "0" : SubjectId;
            SqlParameter[] Parameters = {
                new SqlParameter("@Vid", Vid),
                new SqlParameter("@Location", string.IsNullOrWhiteSpace(Location)? DBNull.Value: (object)Location),
                new SqlParameter("@GenderId",  GenderId),
                new SqlParameter("@QualifiedTeachinglevelsId",  QualifiedTeachinglevelsId),
                 new SqlParameter("@SubjectId",  SubjectId),
                 new SqlParameter("@Availability",  Availability)
            };
        ViewBag.data = db.Database.SqlQuery<TeachersModel>("[dbo].[spGetListingData_Teachers] @Vid, @Location, @GenderId,@QualifiedTeachinglevelsId,@SubjectId,@Availability", Parameters).ToList();
            return View();

    }


        // GET: Teachers/Details/5
        public ActionResult Details(string id)
        {
            id = id == null ? "" : id;
            SqlParameter[] Parameters = {
                    new SqlParameter("@TeacherId", id.ToString())};
            ViewBag.data = db.Database.SqlQuery<TeachersModel>(" [dbo].[spGetListingData_Teachers_Details] @TeacherId", Parameters).ToList();

            long ids = Convert.ToInt64(id);
            Teacher forsale = db.Teachers.Find(ids);
            forsale.Views = forsale.Views + 1;
            db.Entry(forsale).State = EntityState.Modified;
            db.SaveChanges();
            return View();
        }

        // GET: Teachers/Create
        public ActionResult Create()
        {
           
                
                ViewBag.Subject = db.Subject.ToList();
                ViewBag.QualifiedTeachinglevels = db.T_QualifiedLevels.ToList();
                ViewBag.Gender = db.T_Gender.ToList();
            ViewBag.Availability = db.t_Availabilities.ToList();


            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubjectId,TeacherId,VId,UserId,Title,QualifiedTeachinglevelsId,GenderId,YearsOfExperience,LandPhone,Email,Mobile,Location,Description,Image1,Image2,Image3,Date,Views,Status,Availability")] Teacher teacher, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3)
        {
          
            ViewBag.Subject = db.Subject.ToList();
            ViewBag.QualifiedTeachinglevels = db.T_QualifiedLevels.ToList();
            ViewBag.Availability = db.t_Availabilities.ToList();
            ViewBag.Gender = db.T_Gender.ToList();


            if (ModelState.IsValid)
            {
                if (file1 != null)
                {
                    //file1.SaveAs(HttpContext.Server.MapPath("~/Images/")+ file1.FileName);
                    //realEstate.Image1 = "/Images/"+file1.FileName;
                    string watermarkText = "© Vooqq.Com";

                    //Get the file name.
                    string fileName = Path.GetFileNameWithoutExtension(file1.FileName);

                    //Read the File into a Bitmap.
                    using (Bitmap bmp = new Bitmap(file1.InputStream, false))
                    {
                        using (Graphics grp = Graphics.FromImage(bmp))
                        {
                            //Set the Color of the Watermark text.
                            Brush brush = new SolidBrush(Color.DimGray);

                            //Set the Font and its size.
                            Font font = new System.Drawing.Font("Arial", 30, FontStyle.Bold, GraphicsUnit.Pixel);

                            //Determine the size of the Watermark text.
                            SizeF textSize = new SizeF();
                            textSize = grp.MeasureString(watermarkText, font);

                            //Position the text and draw it on the image.
                            Point position = new Point((bmp.Width - ((int)textSize.Width + 10)), (bmp.Height - ((int)textSize.Height + 10)));
                            grp.DrawString(watermarkText, font, brush, position);

                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                //Save the Watermarked image to the MemoryStream.
                                bmp.Save(HttpContext.Server.MapPath("~/Images/") + file1.FileName);
                                teacher.Image1 = "/Images/" + file1.FileName;
                            }
                        }
                    }
                }
                else
                {
                    teacher.Image1 = "/Images/nullimage.jpg";
                }
                if (file2 != null)
                {
                    string watermarkText = "© Vooqq.Com";

                    //Get the file name.
                    string fileName = Path.GetFileNameWithoutExtension(file2.FileName);

                    //Read the File into a Bitmap.
                    using (Bitmap bmp = new Bitmap(file2.InputStream, false))
                    {
                        using (Graphics grp = Graphics.FromImage(bmp))
                        {
                            //Set the Color of the Watermark text.
                            Brush brush = new SolidBrush(Color.DimGray);

                            //Set the Font and its size.
                            Font font = new System.Drawing.Font("Arial", 30, FontStyle.Bold, GraphicsUnit.Pixel);

                            //Determine the size of the Watermark text.
                            SizeF textSize = new SizeF();
                            textSize = grp.MeasureString(watermarkText, font);

                            //Position the text and draw it on the image.
                            Point position = new Point((bmp.Width - ((int)textSize.Width + 10)), (bmp.Height - ((int)textSize.Height + 10)));
                            grp.DrawString(watermarkText, font, brush, position);

                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                //Save the Watermarked image to the MemoryStream.
                                bmp.Save(HttpContext.Server.MapPath("~/Images/") + file2.FileName);
                                teacher.Image2 = "/Images/" + file2.FileName;
                            }
                        }
                    }
                }
                else
                {
                    teacher.Image2 = "/Images/nullimage.jpg";
                }
                if (file3 != null)
                {
                    string watermarkText = "© Vooqq.Com";

                    //Get the file name.
                    string fileName = Path.GetFileNameWithoutExtension(file3.FileName);

                    //Read the File into a Bitmap.
                    using (Bitmap bmp = new Bitmap(file3.InputStream, false))
                    {
                        using (Graphics grp = Graphics.FromImage(bmp))
                        {
                            //Set the Color of the Watermark text.
                            Brush brush = new SolidBrush(Color.DimGray);

                            //Set the Font and its size.
                            Font font = new System.Drawing.Font("Arial", 30, FontStyle.Bold, GraphicsUnit.Pixel);

                            //Determine the size of the Watermark text.
                            SizeF textSize = new SizeF();
                            textSize = grp.MeasureString(watermarkText, font);

                            //Position the text and draw it on the image.
                            Point position = new Point((bmp.Width - ((int)textSize.Width + 10)), (bmp.Height - ((int)textSize.Height + 10)));
                            grp.DrawString(watermarkText, font, brush, position);

                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                //Save the Watermarked image to the MemoryStream.
                                bmp.Save(HttpContext.Server.MapPath("~/Images/") + file3.FileName);
                                teacher.Image3 = "/Images/" + file3.FileName;
                            }
                        }
                    }
                }
                else
                {
                    teacher.Image3 = "/Images/nullimage.jpg";
                }
                teacher.UserId = User.Identity.GetUserId();
                teacher.Date = DateTime.Now;
                teacher.StratDate = DateTime.Now;
                teacher.EndDate = DateTime.Now;
                db.Teachers.Add(teacher);
                db.SaveChanges();
                return RedirectToAction("ViewPlan", "MyAccount", new { prime = 0, vid = teacher.VId, id = teacher.TeacherId });
            }

            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public ActionResult Edit(long? id)
        {
            ViewBag.Subject = db.Subject.ToList();
            ViewBag.QualifiedTeachinglevels = db.T_QualifiedLevels.ToList();
            ViewBag.Availability = db.t_Availabilities.ToList();
            ViewBag.Gender = db.T_Gender.ToList();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,EndDate,status,StratDate,SubjectId,TeacherId,VId,UserId,Title,QualifiedTeachinglevelsId,GenderId,YearsOfExperience,LandPhone,Email,Mobile,Location,Description,Image1,Image2,Image3,Date,Views,Status,Availability")] Teacher teacher, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3)
        {
            ViewBag.Subject = db.Subject.ToList();
            ViewBag.QualifiedTeachinglevels = db.T_QualifiedLevels.ToList();
            ViewBag.Availability = db.t_Availabilities.ToList();
            ViewBag.Gender = db.T_Gender.ToList();

            if (ModelState.IsValid)
            {
                if (file1 != null)
                {
                    //file1.SaveAs(HttpContext.Server.MapPath("~/Images/")+ file1.FileName);
                    //realEstate.Image1 = "/Images/"+file1.FileName;
                    string watermarkText = "© Vooqq.Com";

                    //Get the file name.
                    string fileName = Path.GetFileNameWithoutExtension(file1.FileName);

                    //Read the File into a Bitmap.
                    using (Bitmap bmp = new Bitmap(file1.InputStream, false))
                    {
                        using (Graphics grp = Graphics.FromImage(bmp))
                        {
                            //Set the Color of the Watermark text.
                            Brush brush = new SolidBrush(Color.DimGray);

                            //Set the Font and its size.
                            Font font = new System.Drawing.Font("Arial", 30, FontStyle.Bold, GraphicsUnit.Pixel);

                            //Determine the size of the Watermark text.
                            SizeF textSize = new SizeF();
                            textSize = grp.MeasureString(watermarkText, font);

                            //Position the text and draw it on the image.
                            Point position = new Point((bmp.Width - ((int)textSize.Width + 10)), (bmp.Height - ((int)textSize.Height + 10)));
                            grp.DrawString(watermarkText, font, brush, position);

                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                //Save the Watermarked image to the MemoryStream.
                                bmp.Save(HttpContext.Server.MapPath("~/Images/") + file1.FileName);
                                teacher.Image1 = "/Images/" + file1.FileName;
                            }
                        }
                    }
                }
                else if (teacher.Image1 != null)
                {

                }
                else
                {
                    teacher.Image1 = "/Images/nullimage.jpg";
                }
                if (file2 != null)
                {
                    string watermarkText = "© Vooqq.Com";

                    //Get the file name.
                    string fileName = Path.GetFileNameWithoutExtension(file2.FileName);

                    //Read the File into a Bitmap.
                    using (Bitmap bmp = new Bitmap(file2.InputStream, false))
                    {
                        using (Graphics grp = Graphics.FromImage(bmp))
                        {
                            //Set the Color of the Watermark text.
                            Brush brush = new SolidBrush(Color.DimGray);

                            //Set the Font and its size.
                            Font font = new System.Drawing.Font("Arial", 30, FontStyle.Bold, GraphicsUnit.Pixel);

                            //Determine the size of the Watermark text.
                            SizeF textSize = new SizeF();
                            textSize = grp.MeasureString(watermarkText, font);

                            //Position the text and draw it on the image.
                            Point position = new Point((bmp.Width - ((int)textSize.Width + 10)), (bmp.Height - ((int)textSize.Height + 10)));
                            grp.DrawString(watermarkText, font, brush, position);

                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                //Save the Watermarked image to the MemoryStream.
                                bmp.Save(HttpContext.Server.MapPath("~/Images/") + file2.FileName);
                                teacher.Image2 = "/Images/" + file2.FileName;
                            }
                        }
                    }
                }
                else if (teacher.Image2 != null)
                {

                }
                else
                {
                    teacher.Image2 = "/Images/nullimage.jpg";
                }
                if (file3 != null)
                {
                    string watermarkText = "© Vooqq.Com";

                    //Get the file name.
                    string fileName = Path.GetFileNameWithoutExtension(file3.FileName);

                    //Read the File into a Bitmap.
                    using (Bitmap bmp = new Bitmap(file3.InputStream, false))
                    {
                        using (Graphics grp = Graphics.FromImage(bmp))
                        {
                            //Set the Color of the Watermark text.
                            Brush brush = new SolidBrush(Color.DimGray);

                            //Set the Font and its size.
                            Font font = new System.Drawing.Font("Arial", 30, FontStyle.Bold, GraphicsUnit.Pixel);

                            //Determine the size of the Watermark text.
                            SizeF textSize = new SizeF();
                            textSize = grp.MeasureString(watermarkText, font);

                            //Position the text and draw it on the image.
                            Point position = new Point((bmp.Width - ((int)textSize.Width + 10)), (bmp.Height - ((int)textSize.Height + 10)));
                            grp.DrawString(watermarkText, font, brush, position);

                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                //Save the Watermarked image to the MemoryStream.
                                bmp.Save(HttpContext.Server.MapPath("~/Images/") + file3.FileName);
                                teacher.Image3 = "/Images/" + file3.FileName;
                            }
                        }
                    }
                }
                else if (teacher.Image3 != null)
                {

                }
                else
                {
                    teacher.Image3 = "/Images/nullimage.jpg";
                }
                teacher.Date = DateTime.Now;
                db.Entry(teacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "MyAccount");
            }
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public ActionResult Delete(long? id)
        {
            Teacher teacher = db.Teachers.Find(id);
            db.Teachers.Remove(teacher);
            db.SaveChanges();
            return RedirectToAction("Index", "MyAccount");
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Teacher teacher = db.Teachers.Find(id);
            db.Teachers.Remove(teacher);
            db.SaveChanges();
          return RedirectToAction("Index", "MyAccount");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
