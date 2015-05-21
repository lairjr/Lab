using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace OwnDone.OwnDoneFolders.FunctionsPages
{
    public partial class imagemMiniatura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string FileName = Request.QueryString["img"];
            int MaxH = Convert.ToInt32(Request.QueryString["maxH"]);
            int MaxW = Convert.ToInt32(Request.QueryString["maxW"]);
            int h = MaxH;
            int w = MaxW;
            System.Drawing.Image OriImg = System.Drawing.Image.FromFile(Server.MapPath(FileName));
            if (OriImg.Width > w)
            {
                h = Convert.ToInt32(OriImg.Height * w) / OriImg.Width;
            }
            else
            {
                if (OriImg.Height > h)
                {
                    w = Convert.ToInt32(OriImg.Width * w) / OriImg.Height;
                }
                else
                {
                    w = OriImg.Width;
                    h = OriImg.Height;
                }
            }
            System.Drawing.Image thumbnail = new Bitmap(MaxW, MaxH, OriImg.PixelFormat);
            System.Drawing.Graphics graphic = System.Drawing.Graphics.FromImage(thumbnail);
            var Params = new EncoderParameters(1);
            Params.Param[0] = new EncoderParameter(Encoder.Quality, 100L);
            graphic.InterpolationMode = InterpolationMode.HighQualityBilinear;
            graphic.SmoothingMode = SmoothingMode.HighQuality;
            graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphic.CompositingQuality = CompositingQuality.HighQuality;
            graphic.DrawImage(OriImg, 0, 0, w, h);

            var MS = new MemoryStream();
            thumbnail.Save(MS, ImageFormat.Png);
            byte[] MsAr = MS.ToArray();
            Response.ContentType = "image/Png";
            Response.BinaryWrite(MsAr);
            if (MS != null)
            {
                MS.Close();
                MS.Dispose();
            }
            if (OriImg != null)
            {
                OriImg.Dispose();
                OriImg = null;
            } 
        }
    }
}