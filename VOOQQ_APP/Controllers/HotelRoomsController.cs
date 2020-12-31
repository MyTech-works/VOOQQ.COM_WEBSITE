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
    public class HotelRoomsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult UpdateStatusTrue(long? id)
        {
            HotelRooms forsale = db.HotelRooms.Find(id);
            forsale.Status = true;
            db.Entry(forsale).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AddsManage", "MyAccount");
        }
        public ActionResult UpdateStatusFalse(long? id)
        {
            HotelRooms forsale = db.HotelRooms.Find(id);
            forsale.Status = false;
            db.Entry(forsale).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("AddsManage", "MyAccount");
        }
         public ActionResult Pay(long? prime, long? vid, long? id, string userid ,string amnt)
        {
            HotelRooms forsale = db.HotelRooms.Find(id);
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



        // GET: HotelRooms
        public ActionResult Index(int? Vid, string Location, string PropertyTypeId, string ClassTypeId, string PriceRangeMin, string PriceRangeMax)
        {
            ViewBag.HotelRoomPropertyType = db.HotelRoomPropertyType.ToList();
            ViewBag.HotelRoomClassType = db.HotelRoomClassType.ToList();
            Vid = Vid == null ? 1 : Vid;
            ClassTypeId = ClassTypeId == null || ClassTypeId == "" ? "0" : ClassTypeId;
            PropertyTypeId = PropertyTypeId == null || PropertyTypeId == "" ? "0" : PropertyTypeId;
            int MinPriceRange = PriceRangeMin == "" || PriceRangeMin == null ? 0 : Convert.ToInt32(PriceRangeMin);
            int MaxPriceRange = PriceRangeMax == "" || PriceRangeMax == null ? 10000 : Convert.ToInt32(PriceRangeMax);
            ViewBag.MinPriceRange = MinPriceRange;
            ViewBag.MaxPriceRange = MaxPriceRange;
            SqlParameter[] Parameters = {
                new SqlParameter("@Vid", Vid),
                new SqlParameter("@Location", string.IsNullOrWhiteSpace(Location)? DBNull.Value: (object)Location),
                new SqlParameter("@PropertyTypeId",  PropertyTypeId),
                new SqlParameter("@ClassTypeId",  ClassTypeId),
                new SqlParameter("@MinPriceRange",  MinPriceRange),
                new SqlParameter("@MaxPriceRange",  MaxPriceRange)
            };
            ViewBag.data = db.Database.SqlQuery<HotelRoomsModel>("[dbo].[spGetListingData_HotelRooms] @Vid, @Location, @ClassTypeId, @PropertyTypeId, @MinPriceRange, @MaxPriceRange", Parameters).ToList();
            return View();



          
         
        }
        // GET: HotelRooms/Details/5
        public ActionResult Details(string id)
        {
            id = id == null ? "" : id;
            SqlParameter[] Parameters = {
                    new SqlParameter("@HotelRoomId", id.ToString())};
            ViewBag.data = db.Database.SqlQuery<HotelRoomsModel>(" [dbo].[spGetListingData_HotelRooms_Details] @HotelRoomId", Parameters).ToList();
            long ids = Convert.ToInt64(id);
            HotelRooms forsale = db.HotelRooms.Find(ids);
            forsale.Views = forsale.Views + 1;
            db.Entry(forsale).State = EntityState.Modified;
            db.SaveChanges();

            return View();
        }

        // GET: HotelRooms/Create
        public ActionResult Create()
        {
            ViewBag.HotelRoomPropertyType = db.HotelRoomPropertyType.ToList();
            ViewBag.HotelRoomClassType = db.HotelRoomClassType.ToList();
            ViewBag.HotelRoomInternetType = db.HotelRoomInternetType.ToList();
            return View();
        }

        // POST: HotelRooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HotelRoomId,VId,UserId,Title,Address,Location,PropertyTypeId,ClassTypeId,CheckIn,CheckOut,InternetTypeID,IsParking,IsBreakfast,IsEscalator,IsRoomService,IsRestaurant,IsBar,IsSpaMassage,IsSwimmingPool,Price,LandPhone,Mobile,Email,Website,Description,Image1,Image2,Image3,Date,Views,Status")] HotelRooms hotelRooms, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3)
        {
            ViewBag.HotelRoomPropertyType = db.HotelRoomPropertyType.ToList();
            ViewBag.HotelRoomClassType = db.HotelRoomClassType.ToList();
            ViewBag.HotelRoomInternetType = db.HotelRoomInternetType.ToList();
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
                                hotelRooms.Image1 = "/Images/" + file1.FileName;
                            }
                        }
                    }
                }
                else
                {
                    hotelRooms.Image1 = "/Images/nullimage.jpg";
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
                                hotelRooms.Image2 = "/Images/" + file2.FileName;
                            }
                        }
                    }
                }
                else
                {
                    hotelRooms.Image2 = "/Images/nullimage.jpg";
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
                                hotelRooms.Image3 = "/Images/" + file3.FileName;
                            }
                        }
                    }
                }
                else
                {
                    hotelRooms.Image3 = "/Images/nullimage.jpg";
                }
                hotelRooms.UserId = User.Identity.GetUserId();
                hotelRooms.Date = DateTime.Now;
                hotelRooms.StratDate = DateTime.Now;
                hotelRooms.EndDate = DateTime.Now;
                db.HotelRooms.Add(hotelRooms);
                db.SaveChanges();
                return RedirectToAction("ViewPlan", "MyAccount", new { prime = 0, vid = hotelRooms.VId, id = hotelRooms.HotelRoomId });
            }

            return View(hotelRooms);
        }

        // GET: HotelRooms/Edit/5
        public ActionResult Edit(long? id)
        {
            ViewBag.HotelRoomPropertyType = db.HotelRoomPropertyType.ToList();
            ViewBag.HotelRoomClassType = db.HotelRoomClassType.ToList();
            ViewBag.HotelRoomInternetType = db.HotelRoomInternetType.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelRooms hotelRooms = db.HotelRooms.Find(id);
            if (hotelRooms == null)
            {
                return HttpNotFound();
            }
            return View(hotelRooms);
        }

        // POST: HotelRooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,EndDate,status,StratDate,HotelRoomId,VId,UserId,Title,Address,Location,PropertyTypeId,ClassTypeId,CheckIn,CheckOut,InternetTypeID,IsParking,IsBreakfast,IsEscalator,IsRoomService,IsRestaurant,IsBar,IsSpaMassage,IsSwimmingPool,Price,LandPhone,Mobile,Email,Website,Description,Image1,Image2,Image3,Date,Views,Status")] HotelRooms hotelRooms, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3)
        {
            ViewBag.HotelRoomPropertyType = db.HotelRoomPropertyType.ToList();
            ViewBag.HotelRoomClassType = db.HotelRoomClassType.ToList();
            ViewBag.HotelRoomInternetType = db.HotelRoomInternetType.ToList();
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
                                hotelRooms.Image1 = "/Images/" + file1.FileName;
                            }
                        }
                    }
                }
                else if (hotelRooms.Image1 != null)
                {

                }
                else
                {
                    hotelRooms.Image1 = "/Images/nullimage.jpg";
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
                                hotelRooms.Image2 = "/Images/" + file2.FileName;
                            }
                        }
                    }
                }
                else if (hotelRooms.Image2 != null)
                {

                }
                else
                {
                    hotelRooms.Image2 = "/Images/nullimage.jpg";
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
                                hotelRooms.Image3 = "/Images/" + file3.FileName;
                            }
                        }
                    }
                }
                else if (hotelRooms.Image3 != null)
                {

                }
                else
                {
                    hotelRooms.Image3 = "/Images/nullimage.jpg";
                }
                hotelRooms.Date = DateTime.Now;
                db.Entry(hotelRooms).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "MyAccount");
            }
            return View(hotelRooms);
        }

        // GET: HotelRooms/Delete/5
        public ActionResult Delete(long? id)
        {
            HotelRooms hotelRooms = db.HotelRooms.Find(id);
            db.HotelRooms.Remove(hotelRooms);
            db.SaveChanges();
            return RedirectToAction("Index", "MyAccount");
        }

        // POST: HotelRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            HotelRooms hotelRooms = db.HotelRooms.Find(id);
            db.HotelRooms.Remove(hotelRooms);
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
