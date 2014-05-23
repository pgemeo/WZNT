using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EyeOpen.Imaging.Processing;
using System.IO;

namespace Services
{
    public class ImageParser
    {
        static int MAX_WIDTH = 400;

        public static double ParsePixels(string File1, string File2)
        {
            string Pixel1, Pixel2;
            double Total = 0, NotMatch = 0;
            Bitmap Image1 = new Bitmap(File1);
            Bitmap Image2 = new Bitmap(File2);
            // diferent size
            if (!(Image1.Size.Equals(Image2.Size)) || Image1.Width > MAX_WIDTH || Image2.Width > MAX_WIDTH)
            {
                // resize images
                Image1 = ImageUtility.ResizeBitmap(Image1, 100, 100);
                Image2 = ImageUtility.ResizeBitmap(Image2, 100, 100);
            }
            // compare pixel by pixel
            for (int i = 0; i < Image1.Width; i++)
            {
                for (int j = 0; j < Image1.Height; j++)
                {
                    Pixel1 = Image1.GetPixel(i, j).ToString();
                    Pixel2 = Image2.GetPixel(i, j).ToString();
                    if (!Pixel1.Equals(Pixel2))
                    {
                        NotMatch++;
                    }
                    Total++;
                }
            }
            double Similarity = (double)NotMatch/Total;
            Similarity = (1 - Similarity);
            Log.Info(string.Format("Images have {0} of similarity", Similarity));
            return Similarity;
        }
        public static double ParseSimilarity(string File1, string File2)
        {
            FileInfo FileInfo1 = new FileInfo(File1);
            FileInfo FileInfo2 = new FileInfo(File2);
            ComparableImage Img1 = new ComparableImage(FileInfo1);
            ComparableImage Img2 = new ComparableImage(FileInfo2);
            double Similarity = Img1.CalculateSimilarity(Img2);
            Log.Info(string.Format("Images have {0} of similarity", Similarity));
            return Similarity;
        }
        public static Image ResizeImage(string File, int width, int height)
        {
            Bitmap Image = new Bitmap(File);
            Image = ImageUtility.ResizeBitmap(Image, width, height);
            return Image;
        }
    }
}
