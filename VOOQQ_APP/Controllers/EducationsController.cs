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
    public class EducationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult UpdateStatusTrue(long? id)
        {
            Education forsale = db.Educations.Find(id);
            forsale.Status = true;
            db.Entry(forsale).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AddsManage", "MyAccount");
        }
        public ActionResult UpdateStatusFalse(long? id)
        {
            Education forsale = db.Educations.Find(id);
            forsale.Status = false;
            db.Entry(forsale).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AddsManage", "MyAccount");
        }
         public ActionResult Pay(long? prime, long? vid, long? id, string userid ,string amnt)
        {
            Education forsale = db.Educations.Find(id);
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
        // GET: Educations
        public ActionResult Index(int? Vid, string Location, string EducationCategoryId, string EducationTypeId)
        {

            ViewBag.EducationCategory = db.EducationCategory.ToList();
            ViewBag.EducationTypes = db.educationTypes.ToList();


            Vid = Vid == null ? 1 : Vid;
            EducationCategoryId = EducationCategoryId == null || EducationCategoryId == "" ? "0" : EducationCategoryId;
            EducationTypeId = EducationTypeId == null || EducationTypeId == "" ? "0" : EducationTypeId;
            SqlParameter[] Parameters = {
                new SqlParameter("@Vid", Vid),
                new SqlParameter("@Location", string.IsNullOrWhiteSpace(Location)? DBNull.Value: (object)Location),
                new SqlParameter("@EducationCategoryId",  EducationCategoryId),
                new SqlParameter("@EducationTypeId",  EducationTypeId)
            };
            ViewBag.data = db.Database.SqlQuery<EducationModel>("[dbo].[spGetListingData_Educations] @Vid, @Location, @EducationCategoryId, @EducationTypeId", Parameters).ToList();
            return View();
        }
        // GET: Educations/Details/5
        public ActionResult Details(string id)
        {
            id = id == null ? "" : id;
            SqlParameter[] Parameters = {
                    new SqlParameter("@EducationId", id.ToString())};
            ViewBag.data = db.Database.SqlQuery<EducationModel>(" [dbo].[spGetListingData_Educations_Details] @EducationId", Parameters).ToList();

            long ids = Convert.ToInt64(id);
            Education forsale = db.Educations.Find(ids);
            forsale.Views = forsale.Views + 1;
            db.Entry(forsale).State = EntityState.Modified;
            db.SaveChanges();
            return View();
        }

        // GET: Educations/Create
        public ActionResult Create()
        {
            ViewBag.EducationCategory = db.EducationCategory.ToList();
            ViewBag.EducationTypes = db.educationTypes.ToList();
            return View();
        }

        // POST: Educations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EducationId,VId,UserId,NameofInstitute,EducationCategoryId,Address,Location,LandPhone,MobileNumber,Email,Website,About,Image1,Image2,Image3,Date,Views,Status,EducationTypeId")] Education education, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3)
        {
            ViewBag.EducationCategory = db.EducationCategory.ToList();
            ViewBag.EducationTypes = db.educationTypes.ToList();
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
                                education.Image1 = "/Images/" + file1.FileName;
                            }
                        }
                    }
                }
                else
                {
                    education.Image1 = "/Images/nullimage.jpg";
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
                                education.Image2 = "/Images/" + file2.FileName;
                            }
                        }
                    }
                }
                else
                {
                    education.Image2 = "/Images/nullimage.jpg";
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
                                education.Image3 = "/Images/" + file3.FileName;
                            }
                        }
                    }
                }
                else
                {
                    education.Image3 = "/Images/nullimage.jpg";
                }
                education.UserId = User.Identity.GetUserId();
                education.Date = DateTime.Now;
                education.StratDate = DateTime.Now;
                education.EndDate = DateTime.Now;
                db.Educations.Add(education);
                db.SaveChanges();
                return RedirectToAction("ViewPlan", "MyAccount", new { prime = 0, vid = education.VId, id = education.EducationId });
            }

            return View(education);
        }

        // GET: Educations/Edit/5
        public ActionResult Edit(long? id)
        {
            ViewBag.EducationCategory = db.EducationCategory.ToList();
            ViewBag.EducationTypes = db.educationTypes.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education education = db.Educations.Find(id);
            if (education == null)
            {
                return HttpNotFound();
            }
            return View(education);
        }

        // POST: Educations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,EndDate,status,StratDate,EducationId,VId,UserId,NameofInstitute,EducationCategoryId,Address,Location,LandPhone,MobileNumber,Email,Website,About,Image1,Image2,Image3,Date,Views,Status,EducationTypeId")] Education education, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3)
        {
            ViewBag.EducationCategory = db.EducationCategory.ToList();
            ViewBag.EducationTypes = db.educationTypes.ToList();
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
                                education.Image1 = "/Images/" + file1.FileName;
                            }
                        }
                    }
                }
                else if (education.Image1 != null)
                {

                }
                else
                {
                    education.Image1 = "/Images/nullimage.jpg";
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
                                education.Image2 = "/Images/" + file2.FileName;
                            }
                        }
                    }
                }
                else if (education.Image2 != null)
                {

                }
                else
                {
                    education.Image2 = "/Images/nullimage.jpg";
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
                                education.Image3 = "/Images/" + file3.FileName;
                            }
                        }
                    }
                }
                else if (education.Image3 != null)
                {

                }
                else
                {
                    education.Image3 = "/Images/nullimage.jpg";
                }
                education.Date = DateTime.Now;
                db.Entry(education).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "MyAccount");
            }
            return View(education);
        }

        // GET: Educations/Delete/5
        public ActionResult Delete(long? id)
        {
            Education education = db.Educations.Find(id);
            db.Educations.Remove(education);
            db.SaveChanges();
            return RedirectToAction("Index", "MyAccount");
        }

        // POST: Educations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Education education = db.Educations.Find(id);
            db.Educations.Remove(education);
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
