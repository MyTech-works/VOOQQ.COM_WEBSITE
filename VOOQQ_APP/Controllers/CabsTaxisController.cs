using System;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VOOQQ_APP.Models;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity;
using Razorpay.Api;
using System.Collections.Generic;
using VOOQQ_APP.Helper;

namespace VOOQQ_APP.Controllers
{
    public class CabsTaxisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult UpdateStatusTrue(long? id)
        {
            CabsTaxi forsale = db.CabsTaxis.Find(id);
            forsale.Status = true;
            db.Entry(forsale).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AddsManage", "MyAccount");
        }
        public ActionResult UpdateStatusFalse(long? id)
        {
            CabsTaxi forsale = db.CabsTaxis.Find(id);
            forsale.Status = false;
            db.Entry(forsale).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AddsManage", "MyAccount");
        }
        // GET: CabsTaxis
         public ActionResult Pay(long? prime, long? vid, long? id, string userid ,string amnt)
        {
            CabsTaxi forsale = db.CabsTaxis.Find(id);
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

            return View();
        }
        public ActionResult Index(int? Vid, string Location, string VehicleCategoryId, string VehicleTypeId, string SeatingCapacity)
        {
            ViewBag.VehicleCategory = db.VehicleCategory.ToList();
            ViewBag.VehicleType = db.VehicleType.ToList();
            Vid = Vid == null ? 1 : Vid;
            VehicleCategoryId = VehicleCategoryId == null || VehicleCategoryId == "" ? "0" : VehicleCategoryId;
            VehicleTypeId = VehicleTypeId == null || VehicleTypeId == "" ? "0" : VehicleTypeId;
            SeatingCapacity = SeatingCapacity == null || SeatingCapacity == "" ? "0" : SeatingCapacity;
            SqlParameter[] Parameters = {
                new SqlParameter("@Vid", Vid),
                new SqlParameter("@Location", string.IsNullOrWhiteSpace(Location)? DBNull.Value: (object)Location),
                new SqlParameter("@VehicleCategoryId",  VehicleCategoryId),
                new SqlParameter("@VehicleTypeId",  VehicleTypeId),
                new SqlParameter("@SeatingCapacity",  SeatingCapacity)
            };
            ViewBag.data = db.Database.SqlQuery<CarsTaxiModel>("[dbo].[spGetListingData_CarsTaxi] @Vid, @Location, @VehicleTypeId,@VehicleCategoryId,@SeatingCapacity", Parameters).ToList();
            return View();

           

            
        }
        // GET: CabsTaxis/Details/5
        public ActionResult Details(string id)
        {
            id = id == null ? "" : id;
            SqlParameter[] Parameters = {
                    new SqlParameter("@CabTaxiId", id.ToString())};
            ViewBag.data = db.Database.SqlQuery<CarsTaxiModel>(" [dbo].[spGetListingData_CarsTaxi_Details] @CabTaxiId", Parameters).ToList();

            long ids = Convert.ToInt64(id);
            CabsTaxi forsale = db.CabsTaxis.Find(ids);
            forsale.Views = forsale.Views + 1;
            db.Entry(forsale).State = EntityState.Modified;
            db.SaveChanges();

            return View();
        }

        // GET: CabsTaxis/Create
        public ActionResult Create()
        {
            ViewBag.VehicleCategory = db.VehicleCategory.ToList();
            ViewBag.VehicleType = db.VehicleType.ToList();
            return View();
        }

        // POST: CabsTaxis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CabTaxiId,VId,UserId,Title,About,VehicleCategoryId,VehicleTypeId,Location,DriverAge,YearofExperience,VehicleBrand,VehicleModelName,VehicleYear,SeatingCapacity,MinimumCharge,MobileNumber,LandPhone,Image1,Image2,Image3,Date,Views,Status")] CabsTaxi cabsTaxi, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3)
        {
            ViewBag.VehicleCategory = db.VehicleCategory.ToList();
            ViewBag.VehicleType = db.VehicleType.ToList();

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
                                cabsTaxi.Image1 = "/Images/" + file1.FileName;
                            }
                        }
                    }
                }
                else
                {
                    cabsTaxi.Image1 = "/Images/nullimage.jpg";
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
                                cabsTaxi.Image2 = "/Images/" + file2.FileName;
                            }
                        }
                    }
                }
                else
                {
                    cabsTaxi.Image2 = "/Images/nullimage.jpg";
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
                                cabsTaxi.Image3 = "/Images/" + file3.FileName;
                            }
                        }
                    }
                }
                else
                {
                    cabsTaxi.Image3 = "/Images/nullimage.jpg";
                }
                cabsTaxi.UserId = User.Identity.GetUserId();
                cabsTaxi.Date = DateTime.Now;
                cabsTaxi.StratDate = DateTime.Now;
                cabsTaxi.EndDate = DateTime.Now;
                db.CabsTaxis.Add(cabsTaxi);
                db.SaveChanges();
                return RedirectToAction("ViewPlan", "MyAccount", new { prime = 0, vid = cabsTaxi.VId, id = cabsTaxi.CabTaxiId });
            }

            return View(cabsTaxi);
        }

        // GET: CabsTaxis/Edit/5
        public ActionResult Edit(long? id)
        {
            ViewBag.VehicleCategory = db.VehicleCategory.ToList();
            ViewBag.VehicleType = db.VehicleType.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CabsTaxi cabsTaxi = db.CabsTaxis.Find(id);
            if (cabsTaxi == null)
            {
                return HttpNotFound();
            }
            return View(cabsTaxi);
        }

        // POST: CabsTaxis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,EndDate,status,StratDate,CabTaxiId,VId,UserId,Title,About,VehicleCategoryId,VehicleTypeId,Location,DriverAge,YearofExperience,VehicleBrand,VehicleModelName,VehicleYear,SeatingCapacity,MinimumCharge,MobileNumber,LandPhone,Image1,Image2,Image3,Date,Views,Status")] CabsTaxi cabsTaxi, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3)
        {
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
                                cabsTaxi.Image1 = "/Images/" + file1.FileName;
                            }
                        }
                    }
                }
                else if (cabsTaxi.Image1 != null)
                {

                }
                else
                {
                    cabsTaxi.Image1 = "/Images/nullimage.jpg";
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
                                cabsTaxi.Image2 = "/Images/" + file2.FileName;
                            }
                        }
                    }
                }
                else if (cabsTaxi.Image2 != null)
                {

                }
                else
                {
                    cabsTaxi.Image2 = "/Images/nullimage.jpg";
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
                                cabsTaxi.Image3 = "/Images/" + file3.FileName;
                            }
                        }
                    }
                }
                else if (cabsTaxi.Image3 != null)
                {

                }
                else
                {
                    cabsTaxi.Image3 = "/Images/nullimage.jpg";
                }
                cabsTaxi.Date = DateTime.Now;
                db.Entry(cabsTaxi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "MyAccount");
            }
            return View(cabsTaxi);
        }

        // GET: CabsTaxis/Delete/5
        public ActionResult Delete(long? id)
        {
            CabsTaxi cabsTaxi = db.CabsTaxis.Find(id);
            db.CabsTaxis.Remove(cabsTaxi);
            db.SaveChanges();
          return RedirectToAction("Index", "MyAccount");
        }

        // POST: CabsTaxis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CabsTaxi cabsTaxi = db.CabsTaxis.Find(id);
            db.CabsTaxis.Remove(cabsTaxi);
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
