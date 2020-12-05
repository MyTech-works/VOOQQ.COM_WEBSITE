using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
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
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using VOOQQ_APP.Helper;
using VOOQQ_APP.Models;

namespace VOOQQ_APP.Controllers
{
    public class ForsalesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult UpdateStatusTrue(long? id)
        {
            Forsale forsale = db.Forsales.Find(id);
            forsale.Status = true;
            db.Entry(forsale).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AddsManage", "MyAccount");
        }
        public ActionResult UpdateStatusFalse(long? id)
        {
            Forsale forsale = db.Forsales.Find(id);
            forsale.Status = false;
            db.Entry(forsale).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AddsManage", "MyAccount");
        }
        public ActionResult Pay(long?prime, long? vid, long? id, string userid ,string amnt)
        {
            Forsale forsale = db.Forsales.Find(id);
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
            options.Add("receipt", "order_id"+ ids);
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
      
      

     
       
        // GET: Forsales
        public ActionResult Index(int? Vid,string Location,string CategoryId,string TypeId,string ConditionId)
        {

            CategoryId = CategoryId == null || CategoryId == "" ? "0" : CategoryId;
            TypeId = TypeId == null || TypeId == "" ? "0" : TypeId;
            ConditionId = ConditionId == null || ConditionId == "" ? "0" : ConditionId;
            Location = Location == null ? "" : Location;
            Vid = Vid == null ? 1 : Vid;
            SqlParameter[] Parameters = {
                new SqlParameter("@Vid", Vid),
                new SqlParameter("@Location", Location),
                new SqlParameter("@CategoryId", CategoryId),
                new SqlParameter("@TypeId", TypeId),
                new SqlParameter("@ConditionId", ConditionId),
            };

            ViewBag.Category = db.R_Category.ToList();
            ViewBag.Type = db.R_Type.ToList();
            ViewBag.Condition = db.R_Condition.ToList();

            
            ViewBag.data = db.Database.SqlQuery<ForsaleModel>("[dbo].[spGetListingData_Forsale] @Vid, @Location, @CategoryId, @TypeId, @ConditionId", Parameters).ToList();
            return View();
        }

        // GET: Forsales/Details/5
        public ActionResult Details(string id)
        {
            id = id == null ? "" : id;
            SqlParameter[] Parameters = {
                    new SqlParameter("@ForsaleId", id.ToString())};
            ViewBag.data = db.Database.SqlQuery<ForsaleModel>(" [dbo].[spGetListingData_Forsale_Details] @ForsaleId", Parameters).ToList();

            long ids  = Convert.ToInt64(id);
            Forsale forsale = db.Forsales.Find(ids);
            forsale.Views = forsale.Views+1;
            db.Entry(forsale).State = EntityState.Modified;
            db.SaveChanges();

            return View();
        }

        // GET: Forsales/Create
        public ActionResult Create()
        {
            ViewBag.Category = db.R_Category.ToList();
            ViewBag.Type = db.R_Type.ToList();
            ViewBag.Condition = db.R_Condition.ToList();
            return View();
        }

        // POST: Forsales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ForsaleId,VId,Title,CategoryId,TypeId,ConditionId,Email,Price,Description,Mobile,Location,Image1,Image2,Image3,Date,Views,Status")] Forsale forsale, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3)
        {
            ViewBag.Category = db.R_Category.ToList();
            ViewBag.Type = db.R_Type.ToList();
            ViewBag.Condition = db.R_Condition.ToList();

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
                                forsale.Image1 = "/Images/" + file1.FileName;
                            }
                        }
                    }
                }
                else
                {
                    forsale.Image1 = "/Images/nullimage.jpg";
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
                                forsale.Image2 = "/Images/" + file2.FileName;
                            }
                        }
                    }
                }
                else
                {
                    forsale.Image2 = "/Images/nullimage.jpg";
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
                                forsale.Image3 = "/Images/" + file3.FileName;
                            }
                        }
                    }
                }
                else
                {
                    forsale.Image3 = "/Images/nullimage.jpg";
                }
                forsale.UserId = User.Identity.GetUserId();
                forsale.Date = DateTime.Now;
                forsale.StratDate = DateTime.Now;
                forsale.EndDate = DateTime.Now;
                db.Forsales.Add(forsale);
                db.SaveChanges();
                return RedirectToAction("Index", "MyAccount");
            }

            return View(forsale);
        }

        // GET: Forsales/Edit/5
        public ActionResult Edit(long? id)
        {
            ViewBag.Category = db.R_Category.ToList();
            ViewBag.Type = db.R_Type.ToList();
            ViewBag.Condition = db.R_Condition.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forsale forsale = db.Forsales.Find(id);
            if (forsale == null)
            {
                return HttpNotFound();
            }
            return View(forsale);
        }

        // POST: Forsales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,StratDate,EndDate,status,ForsaleId,VId,Title,CategoryId,TypeId,ConditionId,Email,Price,Description,Mobile,Location,Image1,Image2,Image3,Date,Views,Status")] Forsale forsale, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3)
        {
            ViewBag.Category = db.R_Category.ToList();
            ViewBag.Type = db.R_Type.ToList();
            ViewBag.Condition = db.R_Condition.ToList();
            if (ModelState.IsValid)
            {
                if (file1 != null )
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
                                forsale.Image1 = "/Images/" + file1.FileName;
                            }
                        }
                    }
                }
                else if (forsale.Image1 != null)
                {

                }
                else
                {
                    forsale.Image1 = "/Images/nullimage.jpg";
                }
                if (file2 != null )
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
                                forsale.Image2 = "/Images/" + file2.FileName;
                            }
                        }
                    }
                }
                else if (forsale.Image2 != null)
                {

                }
                else
                {
                    forsale.Image2 = "/Images/nullimage.jpg";
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
                                forsale.Image3 = "/Images/" + file3.FileName;
                            }
                        }
                    }
                }
                else if (forsale.Image3 != null)
                {

                }
                else
                {
                    forsale.Image3 = "/Images/nullimage.jpg";
                }
                forsale.Date = DateTime.Now;
                forsale.StratDate = DateTime.Now;
                db.Entry(forsale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "MyAccount");
            }
            return View(forsale);
        }

        // GET: Forsales/Delete/5
        public ActionResult Delete(long? id)
        {
            Forsale forsale = db.Forsales.Find(id);
            db.Forsales.Remove(forsale);
            db.SaveChanges();
            return RedirectToAction("Index", "MyAccount");
        }

        // POST: Forsales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Forsale forsale = db.Forsales.Find(id);
            db.Forsales.Remove(forsale);
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
