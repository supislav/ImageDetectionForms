using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Drum
{
    internal static class Image
    {
        public static void Open(ref Bitmap originalImage, ref PictureBox picture)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tif;*.tiff|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (ofd.OpenFile() != null)
                    {
                        originalImage = new Bitmap(ofd.FileName);
                        picture.Image = new Bitmap(originalImage);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        public static void Process(ref Bitmap originalImage, ref Bitmap edgeImage, ref PictureBox pictureBox)
        {
            // Stopwatch
            Stopwatch stopwatch = new Stopwatch();

            // Definition of circle
            int centerX = 150;
            int centerY = 150;
            int radius = 145;

            stopwatch.Start();
            // Clear pixels outside of circle and run Sobel algorithm
            Bitmap processedImage = SetPixelsOutsideCircleToBlack(originalImage, centerX, centerY, radius);
            // Dispose the used image
            originalImage.Dispose();
            // Run Sobel algorithm to detect an edge on image that was already processed.
            edgeImage = SobelAlgorithm(processedImage, centerX, centerY, radius);
            stopwatch.Stop();

            // Dispose the used image
            processedImage.Dispose();

            // Set image with only the edge to be visible in picture2
            pictureBox.Image = edgeImage;

            // Get the actual function that best fits the points
            LinearFunction linearFunction = Point.Aproximation(edgeImage);
            // Display the linear function in message box
            linearFunction.Show();

            // Display the time spent to process the image
            MessageBox.Show($"Time elapsed: {stopwatch.ElapsedMilliseconds} milliseconds");
        }


        // Save the processed image as PNG
        public static void Save(ref Bitmap edgeImage)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Image Files|*.png";
            sfd.FileName = $"{DateTime.Now:yyyy_MM_dd_HH_mm_ss}.png";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    edgeImage.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Something went wrong! This is the message: {ex.Message}");
                }
            }
        }

        // Apply Sobel edge detection algorithm within a specific circle
        static Bitmap SobelAlgorithm(Bitmap bitmap, int centerX, int centerY, int radius)
        {
            Bitmap edgeDetectedImage = new Bitmap(bitmap);

            for (int y = Math.Max(0, centerY - radius); y < Math.Min(bitmap.Height, centerY + radius); y++)
            {
                for (int x = Math.Max(0, centerX - radius); x < Math.Min(bitmap.Width, centerX + radius); x++)
                {
                    // Check if the pixel is within the circle
                    if (Math.Pow(x - centerX, 2) + Math.Pow(y - centerY, 2) <= radius * radius)
                    {
                        // Compute gradient in the x and y directions
                        int gradientX = ComputeGradient(bitmap, x, y, true);
                        int gradientY = ComputeGradient(bitmap, x, y, false);

                        // Compute the magnitude of the gradient
                        int magnitude = (int)Math.Sqrt(gradientX * gradientX + gradientY * gradientY);

                        // Normalize the magnitude to fit within the valid range
                        magnitude = Math.Max(0, Math.Min(255, magnitude));

                        // Set the new color based on the magnitude
                        Color newColor = Color.FromArgb(magnitude, magnitude, magnitude);
                        edgeDetectedImage.SetPixel(x, y, newColor);
                    }
                }
            }
            edgeDetectedImage = SetPixelsOutsideCircleToBlack(edgeDetectedImage, centerX, centerY, radius - 2);
            return edgeDetectedImage;
        }

        // Compute gradient in the x or y direction
        static int ComputeGradient(Bitmap bitmap, int x, int y, bool horizontal)
        {
            int result = 0;
            int[,] kernel = horizontal ? new int[,] { { -1, 0, 1 },
                                                      { -2, 0, 2 },
                                                      { -1, 0, 1 } } : new int[,]
                                                    { { -1, -2, -1 },
                                                      { 0, 0, 0 },
                                                      { 1, 2, 1 } };

            for (int j = -1; j <= 1; j++)
            {
                for (int i = -1; i <= 1; i++)
                {
                    Color pixel = bitmap.GetPixel(x + i, y + j);
                    int value = pixel.R; // Assuming grayscale image
                    result += kernel[j + 1, i + 1] * value;
                }
            }
            return result;
        }

        // Set all the pixels outside of the circular area to be black
        static Bitmap SetPixelsOutsideCircleToBlack(Bitmap bitmap, int centerX, int centerY, int radius)
        {
            Bitmap processedImage = new Bitmap(bitmap);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    // Check if the pixel is outside the circle
                    if (Math.Pow(x - centerX, 2) + Math.Pow(y - centerY, 2) > radius * radius)
                    {
                        // Set the pixel to black
                        processedImage.SetPixel(x, y, Color.Black);
                    }
                }
            }
            return processedImage;
        }
    }
}
