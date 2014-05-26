using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Services.WZNTServices;
using EyeOpen.Imaging.Processing;

namespace Services
{
    public class ImageParser
    {
        public static double ParsePixels(string File1, string File2)
        {
            // Create client
            ServiceClient WZNTServices = new ServiceClient();
            double Similarity = WZNTServices.ParsePixels(File1, File2);
            Log.Info(string.Format("Images have {0} of similarity", Similarity));
            // Close the client.
            WZNTServices.Close();
            return Similarity;
        }
        public static double ParseSimilarity(string File1, string File2)
        {
            // Create client
            ServiceClient WZNTServices = new ServiceClient();
            double Similarity = 0;// WZNTServices.ParseSimilarity(File1, File2);
            Log.Info(string.Format("Images have {0} of similarity", Similarity));
            // Close the client.
            WZNTServices.Close();
            return Similarity;
        }
        public static Image ResizeImage(string File, int Width, int Height)
        {
            Bitmap Image = new Bitmap(File);
            Image = ImageUtility.ResizeBitmap(Image, Width, Height);
            return Image;
        }
    }
}
