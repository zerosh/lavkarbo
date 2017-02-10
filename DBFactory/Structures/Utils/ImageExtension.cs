using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DBFactory.Structures
{
    public class ImageExtension : IEnumerable<ImageExtension>
    {
        List<ImageExtension> imageList = new List<ImageExtension>();

        public ImageExtension this[int index]
        {
            get { return imageList[index]; }
            set { imageList.Insert(index, value); }
        }

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
            if (imageByteArray != null)
            {
                return string.Format("data:image/gif;base64, {0}", Convert.ToBase64String(imageByteArray));
            }

            return string.Empty;
        }

        public IEnumerator<ImageExtension> GetEnumerator()
        {
            return imageList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
