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
    public class BusinessesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult UpdateStatusTrue(long? id)
        {
            Business forsale = db.Business.Find(id);
            forsale.Status = true;
            db.Entry(forsale).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AddsManage", "MyAccount");
        }
        public ActionResult UpdateStatusFalse(long? id)
        {
            Business forsale = db.Business.Find(id);
            forsale.Status = false;
            db.Entry(forsale).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AddsManage", "MyAccount");
        }
         public ActionResult Pay(long? prime, long? vid, long? id, string userid ,string amnt)
        {
            Business forsale = db.Business.Find(id);
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


        // GET: Businesses
        public ActionResult Index(int? Vid, string Location, string BusinessCategoryId)
        {
            ViewBag.BusinessCategory = db.BusinessCategory.ToList();
            Vid = Vid == null ? 1 : Vid;
            BusinessCategoryId = BusinessCategoryId == null || BusinessCategoryId == "" ? "0" : BusinessCategoryId;
            SqlParameter[] Parameters = {
                new SqlParameter("@Vid", Vid),
                new SqlParameter("@Location", string.IsNullOrWhiteSpace(Location)? DBNull.Value: (object)Location),
                new SqlParameter("@BusinessCategoryId",  BusinessCategoryId),
            };

            ViewBag.Category = db.R_Category.ToList();
            ViewBag.Type = db.R_Type.ToList();
            ViewBag.Condition = db.R_Condition.ToList();


            ViewBag.data = db.Database.SqlQuery<BusinessModel>("[dbo].[spGetListingData_Business]  @Vid, @Location, @BusinessCategoryId", Parameters).ToList();

          
            return View();
        }

        // GET: Businesses/Details/5
        public ActionResult Details(string id)
        {

            id = id == null ? "" : id;
            SqlParameter[] Parameters = {
                    new SqlParameter("@BusinessId", id.ToString())};
            ViewBag.data = db.Database.SqlQuery<BusinessModel>(" [dbo].[spGetListingData_Business_Details] @BusinessId", Parameters).ToList();
            long ids = Convert.ToInt64(id);
            Business forsale = db.Business.Find(ids);
            forsale.Views = forsale.Views + 1;
            db.Entry(forsale).State = EntityState.Modified;
            db.SaveChanges();

            return View();
        }

        // GET: Businesses/Create
        public ActionResult Create()
        {
            ViewBag.BusinessCategory = db.BusinessCategory.ToList();
            return View();
        }

        // POST: Businesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BusinessId,UserId,VId,Title,BusinessCategoryId,Website,LandPhone,Email,Description,Mobile,Location,Image1,Image2,Image3,Date,Views,Status")] Business business, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3)
        {
            ViewBag.BusinessCategory = db.BusinessCategory.ToList();
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
                                business.Image1 = "/Images/" + file1.FileName;
                            }
                        }
                    }
                }
                else
                {
                    business.Image1 = "/Images/nullimage.jpg";
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
                                business.Image2 = "/Images/" + file2.FileName;
                            }
                        }
                    }
                }
                else
                {
                    business.Image2 = "/Images/nullimage.jpg";
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
                                business.Image3 = "/Images/" + file3.FileName;
                            }
                        }
                    }
                }
                else
                {
                    business.Image3 = "/Images/nullimage.jpg";
                }
                business.UserId = User.Identity.GetUserId();
                business.Date = DateTime.Now;
                business.StratDate = DateTime.Now;
                business.EndDate = DateTime.Now;

                db.Business.Add(business);
                db.SaveChanges();
                return RedirectToAction("Index", "MyAccount");
            }

            return View(business);
        }

        // GET: Businesses/Edit/5
        public ActionResult Edit(long? id)
        {
            ViewBag.BusinessCategory = db.BusinessCategory.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Business business = db.Business.Find(id);
            if (business == null)
            {
                return HttpNotFound();
            }
            return View(business);
        }

        // POST: Businesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,EndDate,status,StratDate,BusinessId,VId,Title,BusinessCategoryId,Website,LandPhone,Email,Description,Mobile,Location,Image1,Image2,Image3,Date,Views,Status")] Business business, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3)
        {
            ViewBag.BusinessCategory = db.BusinessCategory.ToList();
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
                                business.Image1 = "/Images/" + file1.FileName;
                            }
                        }
                    }
                }
                else if (business.Image1 != null)
                {

                }
                else
                {
                    business.Image1 = "/Images/nullimage.jpg";
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
                                business.Image2 = "/Images/" + file2.FileName;
                            }
                        }
                    }
                }
                else if (business.Image2 != null)
                {

                }
                else
                {
                    business.Image2 = "/Images/nullimage.jpg";
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
                                business.Image3 = "/Images/" + file3.FileName;
                            }
                        }
                    }
                }
                else if (business.Image3 != null)
                {

                }
                else
                {
                    business.Image3 = "/Images/nullimage.jpg";
                }
                business.Date = DateTime.Now;
                db.Entry(business).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "MyAccount");
            }
            return View(business);
        }

        // GET: Businesses/Delete/5
        public ActionResult Delete(long? id)
        {
            Business business = db.Business.Find(id);
            db.Business.Remove(business);
            db.SaveChanges();
          return RedirectToAction("Index", "MyAccount");
        }

        // POST: Businesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Business business = db.Business.Find(id);
            db.Business.Remove(business);
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
