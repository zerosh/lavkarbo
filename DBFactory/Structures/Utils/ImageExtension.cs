﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DBFactory.Structures
{
    public class ImageExtension
    {
        private string image { get; set; }
        public string Image
        {
            get
            { 
                if (this.image != null)
                {
                    return this.image;
                }

                return string.Empty;
            }
            private set
            {
                image = value;
            }
        }

        public byte[] SaveImage(HttpPostedFileBase File)
        {
            if (File != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    File.InputStream.CopyTo(ms);
                    byte[] data = ms.GetBuffer();

                    this.Image = FormatImage(data);

                    return data;
                }
            }

            return null;
        }

        private string FormatImage(byte[] imageByteArray)
        {
            string FormattedImage = "DefaultImage.png";

            if (imageByteArray != null)
            {
                var base64 = Convert.ToBase64String(imageByteArray);
                FormattedImage = string.Format("data:image/gif;base64, {0}", base64);

                return FormattedImage;
            }

            return string.Empty;
        }
    }
}