using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DBFactory.Structures
{
    public class ImageExtension : IEnumerable<ImageExtension>
    {
        private static Bitmap ResizeImage(System.Drawing.Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

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

        public void SaveImage(byte[] data)
        {
            this.image = FormatImage(data);
        }

        public void SaveImage(HttpPostedFileBase file, int With = 500, int Height = 500)
        {
            System.Drawing.Image img = System.Drawing.Image.FromStream(file.InputStream);
            var resizedFile = ResizeImage(img, With, Height);

            using (var stream = new MemoryStream())
            {
                resizedFile.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                SaveImage(stream.ToArray());
            }

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
