using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Web.Mvc;
using VOOQQ_APP.Models;


namespace VOOQQ_APP.Helper
{
    public class WaterMark
    {

        public void writewatermark(HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3)
        {
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
                      //  bmp.Save(HttpContext.Server.MapPath("~/Images/") + file1.FileName);
                       // realEstate.Image1 = "/Images/" + file1.FileName;


                    }
                }
            }
        }
    }
}