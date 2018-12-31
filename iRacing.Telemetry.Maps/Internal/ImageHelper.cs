using iRacing.Telemetry.Maps.Ports;
using System.Drawing;
using System.Drawing.Imaging;

namespace iRacing.Telemetry.Maps.Internal
{
    public class ImageHelper : IImageHelper
    {
        // ImageConverter object used to convert byte arrays containing JPEG or PNG file images into 
        //  Bitmap objects. This is static and only gets instantiated once.
        private readonly ImageConverter _imageConverter = new ImageConverter();
        public string FileDialogFilter
        {
            get
            {
                string filter = string.Empty;

                ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
                string sep = string.Empty;

                foreach (var c in codecs)
                {
                    string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                    filter = string.Format("{0}{1}{2} ({3})|{3}", filter, sep, codecName, c.FilenameExtension);
                    sep = "|";
                }

                return string.Format("{0}{1}{2} ({3})|{3}", filter, sep, "All Files", "*.*");
            }
        }

        public Image ZoomImage(Image sourceImage, float zoomFactor)
        {
            Size newSize = new Size((int)(sourceImage.Width * zoomFactor), (int)(sourceImage.Height * zoomFactor));
            Image zoomedImage = new Bitmap(sourceImage, newSize);
            return zoomedImage;
        }

        /// <summary>
        /// Method that uses the ImageConverter object in .Net Framework to convert a byte array, 
        /// presumably containing a JPEG or PNG file image, into a Bitmap object, which can also be 
        /// used as an Image object.
        /// </summary>
        /// <param name="byteArray">byte array containing JPEG or PNG file image or similar</param>
        /// <returns>Bitmap object if it works, else exception is thrown</returns>
        public Bitmap GetImageFromByteArray(byte[] byteArray)
        {
            Bitmap bm = (Bitmap)_imageConverter.ConvertFrom(byteArray);

            if (bm != null && (bm.HorizontalResolution != (int)bm.HorizontalResolution ||
                               bm.VerticalResolution != (int)bm.VerticalResolution))
            {
                // Correct a strange glitch that has been observed in the test program when converting 
                //  from a PNG file image created by CopyImageToByteArray() - the dpi value "drifts" 
                //  slightly away from the nominal integer value
                bm.SetResolution((int)(bm.HorizontalResolution + 0.5f),
                                 (int)(bm.VerticalResolution + 0.5f));
            }

            return bm;
        }

        public Image LoadImageFromFile(string fileName)
        {
            Image trackImage = null;

            if (!string.IsNullOrEmpty(fileName))
            {
                trackImage = Image.FromFile(fileName, true);
            }

            return trackImage;
        }

        public bool SaveImageToFile(Image image, string fileName, ImageFormat format)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                image.Save(fileName, format);
                return true;
            }
            else
                return false;
        }
    }
}
