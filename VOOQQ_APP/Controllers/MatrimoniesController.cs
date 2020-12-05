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
    public class MatrimoniesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult UpdateStatusTrue(long? id)
        {
            Matrimony forsale = db.Matrimony.Find(id);
            forsale.Status = true;
            db.Entry(forsale).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AddsManage", "MyAccount");
        }
        public ActionResult UpdateStatusFalse(long? id)
        {
            Matrimony forsale = db.Matrimony.Find(id);
            forsale.Status = false;
            db.Entry(forsale).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AddsManage", "MyAccount");
        }
         public ActionResult Pay(long? prime, long? vid, long? id, string userid ,string amnt)
        {
            Matrimony forsale = db.Matrimony.Find(id);
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
        // GET: Matrimonies
        public ActionResult Index(int? Vid, string Location, string MatrimonyCategoryId, string M_AgeCategoryId, string M_MaritalStatusId, string ReligionId)
          {


            ViewBag.Religion = db.Religion.ToList();
            ViewBag.M_AgeCategory = db.M_AgeCategory.ToList();
            ViewBag.M_MaritalStatus = db.M_MaritalStatus.ToList();
            ViewBag.MatrimonyCategory = db.MatrimonyCategory.ToList();


            Location = Location == null ? "" : Location;
            Vid = Vid == null ? 1 : Vid;

            MatrimonyCategoryId = MatrimonyCategoryId == null || MatrimonyCategoryId == "" ? "0" : MatrimonyCategoryId;
            M_AgeCategoryId = M_AgeCategoryId == null || M_AgeCategoryId == "" ? "0" : M_AgeCategoryId;
            M_MaritalStatusId = M_MaritalStatusId == null || M_MaritalStatusId == "" ? "0" : M_MaritalStatusId;
            ReligionId = ReligionId == null || ReligionId == "" ? "0" : ReligionId;
          
            SqlParameter[] Parameters = {
                new SqlParameter("@Vid", Vid),
                new SqlParameter("@Location", Location),
                new SqlParameter("@MatrimonyCategoryId", MatrimonyCategoryId),
                new SqlParameter("@M_MaritalStatusId", M_MaritalStatusId),
                new SqlParameter("@M_AgeCategoryId", M_AgeCategoryId),
                 new SqlParameter("@ReligionId", ReligionId),
            };

            ViewBag.Category = db.R_Category.ToList();
            ViewBag.Type = db.R_Type.ToList();
            ViewBag.Condition = db.R_Condition.ToList();


            ViewBag.data = db.Database.SqlQuery<MatrimoniesModel>(" [dbo].[spGetListingData_Matrimonies] @Vid, @Location, @MatrimonyCategoryId, @M_MaritalStatusId, @M_AgeCategoryId,@ReligionId", Parameters).ToList();
            return View();
        }


        // GET: Matrimonies/Details/5
        public ActionResult Details(string id)
        {
            id = id == null ? "" : id;
            SqlParameter[] Parameters = {
                    new SqlParameter("@MatrimonyId", id.ToString())};
            ViewBag.data = db.Database.SqlQuery<MatrimoniesModel>(" [dbo].[spGetListingData_Matrimonies_Details] @MatrimonyId", Parameters).ToList();

            long ids = Convert.ToInt64(id);
            Matrimony forsale = db.Matrimony.Find(ids);
            forsale.Views = forsale.Views + 1;
            db.Entry(forsale).State = EntityState.Modified;
            db.SaveChanges();
            return View();
        }

        // GET: Matrimonies/Create
        public ActionResult Create()
        {

            ViewBag.Religion = db.Religion.ToList();
            ViewBag.M_AgeCategory = db.M_AgeCategory.ToList();
            ViewBag.M_MaritalStatus = db.M_MaritalStatus.ToList();
            ViewBag.M_PhysicalStatus = db.M_PhysicalStatus.ToList();
            ViewBag.M_BodySkinTone = db.M_BodySkinTone.ToList();
            ViewBag.MatrimonyCategory = db.MatrimonyCategory.ToList();



            return View();
        }

        // POST: Matrimonies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MatrimonyId,VId,UserId,Title,DateOfBirth,MatrimonyCategoryId,M_AgeCategoryId,M_MaritalStatusId,M_PhysicalStatusId,M_BodySkinToneId,ReligionId,Community,SubCommunity,Nakshatra,Job,Qualification,Languages,Email,Description,LandPhone,Mobile,Location,Image1,Image2,Image3,Date,Views,Status")] Matrimony matrimony, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3)
        {
            ViewBag.Religion = db.Religion.ToList();
            ViewBag.M_AgeCategory = db.M_AgeCategory.ToList();
            ViewBag.M_MaritalStatus = db.M_MaritalStatus.ToList();
            ViewBag.M_PhysicalStatus = db.M_PhysicalStatus.ToList();
            ViewBag.M_BodySkinTone = db.M_BodySkinTone.ToList();
            ViewBag.MatrimonyCategory = db.MatrimonyCategory.ToList();


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
                                matrimony.Image1 = "/Images/" + file1.FileName;
                            }
                        }
                    }
                }
                else
                {
                    matrimony.Image1 = "/Images/nullimage.jpg";
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
                                matrimony.Image2 = "/Images/" + file2.FileName;
                            }
                        }
                    }
                }
                else
                {
                    matrimony.Image2 = "/Images/nullimage.jpg";
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
                                matrimony.Image3 = "/Images/" + file3.FileName;
                            }
                        }
                    }
                }
                else
                {
                    matrimony.Image3 = "/Images/nullimage.jpg";
                }
                matrimony.UserId = User.Identity.GetUserId();
                matrimony.Date = DateTime.Now;
                matrimony.StratDate = DateTime.Now;
                matrimony.EndDate = DateTime.Now;
                db.Matrimony.Add(matrimony);
                db.SaveChanges();
                return RedirectToAction("Index", "MyAccount");
            }

            return View(matrimony);
        }

        // GET: Matrimonies/Edit/5
        public ActionResult Edit(long? id)
        {
            ViewBag.Religion = db.Religion.ToList();
            ViewBag.M_AgeCategory = db.M_AgeCategory.ToList();
            ViewBag.M_MaritalStatus = db.M_MaritalStatus.ToList();
            ViewBag.M_PhysicalStatus = db.M_PhysicalStatus.ToList();
            ViewBag.M_BodySkinTone = db.M_BodySkinTone.ToList();
            ViewBag.MatrimonyCategory = db.MatrimonyCategory.ToList();


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matrimony matrimony = db.Matrimony.Find(id);
            if (matrimony == null)
            {
                return HttpNotFound();
            }
            return View(matrimony);
        }

        // POST: Matrimonies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,EndDate,status,StratDate,MatrimonyId,VId,UserId,Title,DateOfBirth,MatrimonyCategoryId,M_AgeCategoryId,M_MaritalStatusId,M_PhysicalStatusId,M_BodySkinToneId,ReligionId,Community,SubCommunity,Nakshatra,Job,Qualification,Languages,Email,Description,LandPhone,Mobile,Location,Image1,Image2,Image3,Date,Views,Status")] Matrimony matrimony, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3)
        {
            ViewBag.Religion = db.Religion.ToList();
            ViewBag.M_AgeCategory = db.M_AgeCategory.ToList();
            ViewBag.M_MaritalStatus = db.M_MaritalStatus.ToList();
            ViewBag.M_PhysicalStatus = db.M_PhysicalStatus.ToList();
            ViewBag.M_BodySkinTone = db.M_BodySkinTone.ToList();
            ViewBag.MatrimonyCategory = db.MatrimonyCategory.ToList();

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
                                matrimony.Image1 = "/Images/" + file1.FileName;
                            }
                        }
                    }
                }
                else if (matrimony.Image1 != null)
                {

                }
                else
                {
                    matrimony.Image1 = "/Images/nullimage.jpg";
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
                                matrimony.Image2 = "/Images/" + file2.FileName;
                            }
                        }
                    }
                }
                else if (matrimony.Image2 != null)
                {

                }
                else
                {
                    matrimony.Image2 = "/Images/nullimage.jpg";
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
                                matrimony.Image3 = "/Images/" + file3.FileName;
                            }
                        }
                    }
                }
                else if (matrimony.Image3 != null)
                {

                }
                else
                {
                    matrimony.Image3 = "/Images/nullimage.jpg";
                }
                matrimony.Date = DateTime.Now;
                db.Entry(matrimony).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "MyAccount");
            }
            return View(matrimony);
        }

        // GET: Matrimonies/Delete/5
        public ActionResult Delete(long? id)
        {
            Matrimony matrimony = db.Matrimony.Find(id);
            db.Matrimony.Remove(matrimony);
            db.SaveChanges();
            return RedirectToAction("Index", "MyAccount");
        }

        // POST: Matrimonies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Matrimony matrimony = db.Matrimony.Find(id);
            db.Matrimony.Remove(matrimony);
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
