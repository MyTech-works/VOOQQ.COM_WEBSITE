using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VOOQQ_APP.Models;
using PagedList;
namespace VOOQQ_APP.Controllers
{
    public class RealEstatesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RealEstates
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            var result = db.Database.SqlQuery<RealEstate>("GetMyAddress").ToList();

            ViewBag.CurrentFilter = searchString;

            var students = from s in db.RealEstates
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.Title.Contains(searchString) || s.Title.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    students = students.OrderBy(s => s.RealEstateId);
                    break;
                case "date_desc": 
                    students = students.OrderByDescending(s => s.Date);
                    break;
                default:  // Name ascending 
                    students = students.OrderBy(s => s.Date);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Index1()
        {
            return View(db.RealEstates.ToList());
        }

        // GET: RealEstates/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstate realEstate = db.RealEstates.Find(id);
           




            if (realEstate == null)
            {
                return HttpNotFound();
            }
            return View(realEstate);
        }

        // GET: RealEstates/Create
        public ActionResult Create()
        {
            ViewBag.Category = db.R_Category.ToList();
            ViewBag.Type = db.R_Type.ToList();
            ViewBag.Condition = db.R_Condition.ToList();
            ViewBag.Bedrooms = db.R_Bedrooms.ToList();
            ViewBag.Bathrooms = db.R_Bathrooms.ToList();
            ViewBag.Direction = db.R_Direction.ToList();
            ViewBag.PostedBy = db.R_PostedBy.ToList();

            return View();
        }

        // POST: RealEstates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RealEstateId,Title,CategoryId,TypeId,ConditionId,SquareFeet,BedroomsId,BathroomsId,DirectionId,PostedById,Description,Mobile,Location,Image1,Image2,Image3,Date")] RealEstate realEstate, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3)
        {
            ViewBag.Category = db.R_Category.ToList();
            ViewBag.Type = db.R_Type.ToList();
            ViewBag.Condition = db.R_Condition.ToList();
            ViewBag.Bedrooms = db.R_Bedrooms.ToList();
            ViewBag.Bathrooms = db.R_Bathrooms.ToList();
            ViewBag.Direction = db.R_Direction.ToList();
            ViewBag.PostedBy = db.R_PostedBy.ToList();



         
            


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
                                realEstate.Image1 = "/Images/" + file1.FileName;
                            }
                        }
                    }
                }
                else
                {
                    realEstate.Image1 = "/Images/nullimage.jpg";
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
                                realEstate.Image2 = "/Images/" + file2.FileName;
                            }
                        }
                    }
                }
                else
                {
                    realEstate.Image2 = "/Images/nullimage.jpg";
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
                                realEstate.Image3 = "/Images/" + file3.FileName;
                            }
                        }
                    }
                }
                else
                {
                    realEstate.Image3 = "/Images/nullimage.jpg";
                }
                realEstate.Date = DateTime.Now;
                db.RealEstates.Add(realEstate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(realEstate);
        }

        // GET: RealEstates/Edit/5
        public ActionResult Edit(long? id)
        {
            ViewBag.Category = db.R_Category.ToList();
            ViewBag.Type = db.R_Type.ToList();
            ViewBag.Condition = db.R_Condition.ToList();
            ViewBag.Bedrooms = db.R_Bedrooms.ToList();
            ViewBag.Bathrooms = db.R_Bathrooms.ToList();
            ViewBag.Direction = db.R_Direction.ToList();
            ViewBag.PostedBy = db.R_PostedBy.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstate realEstate = db.RealEstates.Find(id);
            if (realEstate == null)
            {
                return HttpNotFound();
            }
            return View(realEstate);
        }

        // POST: RealEstates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RealEstateId,Title,CategoryId,TypeId,ConditionId,SquareFeet,BedroomsId,BathroomsId,DirectionId,PostedById,Description,Mobile,Location,Image1,Image2,Image3,Date")] RealEstate realEstate, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3)
        {
            ViewBag.Category = db.R_Category.ToList();
            ViewBag.Type = db.R_Type.ToList();
            ViewBag.Condition = db.R_Condition.ToList();
            ViewBag.Bedrooms = db.R_Bedrooms.ToList();
            ViewBag.Bathrooms = db.R_Bathrooms.ToList();
            ViewBag.Direction = db.R_Direction.ToList();
            ViewBag.PostedBy = db.R_PostedBy.ToList();
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
                                realEstate.Image1 = "/Images/" + file1.FileName;
                            }
                        }
                    }
                }
                else if (realEstate.Image1 == null && file1 != null)
                {
                    realEstate.Image1 = "/Images/nullimage.jpg";
                }
                else
                {
                   
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
                                realEstate.Image2 = "/Images/" + file2.FileName;
                            }
                        }
                    }
                }
                else if (realEstate.Image2 == null && file2 != null)
                {
                    realEstate.Image2 = "/Images/nullimage.jpg";
                }
                else
                {

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
                                realEstate.Image3 = "/Images/" + file3.FileName;
                            }
                        }
                    }
                }
                else if (realEstate.Image3 == null && file3 != null)
                {
                    realEstate.Image3 = "/Images/nullimage.jpg";
                }
                else
                {

                }
                db.Entry(realEstate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(realEstate);
        }

        // GET: RealEstates/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RealEstate realEstate = db.RealEstates.Find(id);
            if (realEstate == null)
            {
                return HttpNotFound();
            }
            return View(realEstate);
        }

        // POST: RealEstates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            RealEstate realEstate = db.RealEstates.Find(id);
            db.RealEstates.Remove(realEstate);
            db.SaveChanges();
            return RedirectToAction("Index");
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
