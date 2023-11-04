using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Drum
{
    internal class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Point[] points { get; private set; }


        // Aproximation of points
        public static LinearFunction Aproximation(Bitmap image)
        {
            points = FindWhitePixels(image);
            double sumX = 0;
            double sumY = 0;
            double sumXY = 0;
            double sumXX = 0;

            foreach (Point point in points)
            {
                sumX += point.X;
                sumY += point.Y;
                sumXY += point.X * point.Y;
                sumXX += point.X * point.X;
            }

            // Online
            double k = (points.Length * sumXY - sumX * sumY) / (points.Length * sumXX - sumX * sumX);
            double n = (sumY - k * sumX) / points.Length;

            return new LinearFunction(k, n);
        }

        // Find the white pixels (points for approximation)
        private static Point[] FindWhitePixels(Bitmap bitmap)
        {
            List<Point> whitePixels = new List<Point>();

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color pixel = bitmap.GetPixel(x, y);
                    if (pixel.R == 255 && pixel.G == 255 && pixel.B == 255) // Check if the pixel is white
                    {
                        whitePixels.Add(new Point(x, y));
                    }
                }
            }
            return whitePixels.ToArray();
        }

        // Save calculated points to .CSV file (it has to be in this, because othervise you have to pass in the array of points)
        public static void Save()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV file|*.csv";
            sfd.FileName = $"{DateTime.Now:yyyy_MM_dd_HH_mm_ss}.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (var writer = new StreamWriter(sfd.FileName))
                {
                    foreach (var point in points)
                    {
                        writer.WriteLine($"{point.X}|{point.Y}");
                    }
                }
            }
        }
    }

    //internal static class PointExtensions
    //{
    //    // Save calculated points to .CSV file (it has to be in this, because othervise you have to pass in the array of points)
    //    public static void Save(this Point[] points)
    //    {
    //        SaveFileDialog sfd = new SaveFileDialog();
    //        sfd.Filter = "CSV file|*.csv";
    //        sfd.FileName = $"{DateTime.Now:yyyy_MM_dd_HH_mm_ss}.csv";

    //        if (sfd.ShowDialog() == DialogResult.OK)
    //        {
    //            using (var writer = new StreamWriter(sfd.FileName))
    //            {
    //                foreach (var point in points)
    //                {
    //                    writer.WriteLine($"{point.X}|{point.Y}");
    //                }
    //            }
    //        }
    //    }
    //}
}
