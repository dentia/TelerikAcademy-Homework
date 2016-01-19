namespace CustomHttpHandler
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Web;

    public class ImgHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/png";
            var imageAsText = context.Request.Params[0];
            byte[] bytes = Convert.FromBase64String(imageAsText);
            using (Bitmap image = (Bitmap)Image.FromStream(new MemoryStream(bytes)))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    ms.WriteTo(context.Response.OutputStream);
                }
            }
        }
    }
}