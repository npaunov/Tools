using Factories.Resources;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Factories
{
    public class ImageCustom : System.Windows.Controls.Image
    {
        public ImageCustom Icon(string path)
        {
            ImageCustom smallImage = new ImageCustom();
            smallImage.Width = 24;
            smallImage.Height = 24;

            FileAttributes attr = File.GetAttributes(path);
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                string patho = Assembly.GetAssembly(typeof(ImageCustom)).Location;
                path = Globals.ReplaceIconPath;
            }

            Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(path);

            using (Bitmap bmp = icon.ToBitmap())
            {
                var stream = new MemoryStream();
                bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                smallImage.Source = BitmapFrame.Create(stream);
            }          

            return smallImage;
        }

    }
}
