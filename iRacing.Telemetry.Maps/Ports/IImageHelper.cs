using System.Drawing;
using System.Drawing.Imaging;

namespace iRacing.Telemetry.Maps.Ports
{
    public interface IImageHelper
    {
        string FileDialogFilter { get; }
        Image ZoomImage(Image sourceImage, float zoomFactor);
        Bitmap GetImageFromByteArray(byte[] byteArray);
        Image LoadImageFromFile(string fileName);
        bool SaveImageToFile(Image image, string fileName, ImageFormat format);
    }
}