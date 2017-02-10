using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DBFactory.Structures.Utils
{
    public class DImage
    {
        public static string GetImage(byte[] Data)
        {
            string FormattedImage = "DefaultImage.png";

            if (Data != null)
            {
                var base64 = Convert.ToBase64String(Data);
                FormattedImage = string.Format("data:image/gif;base64, {0}", base64);
            }

            return FormattedImage;
        }

        /*
         * Create image from 
         */
        public static byte[] CreateImage(HttpFileCollectionBase Files)
        {
            if (Files.Count > 0)
            {
                var file = Files[0] as HttpPostedFileBase;

                if (file.ContentLength > 0)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);
                        byte[] data = ms.GetBuffer();
                        return data;
                    }
                }
            }

            return null;
        }
    }
}
