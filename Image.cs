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
        public static Bitmap Open()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tif;*.tiff|All files (*.*)|*.*";

            Bitmap originalImage = null;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (ofd.OpenFile() != null)
                    {
                        originalImage = new Bitmap(ofd.FileName);
                        return originalImage;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            return originalImage;
        }

        public static Bitmap DetectEdges(ref Bitmap originalImage)
        {
            // Stopwatch
            Stopwatch stopwatch = new Stopwatch();

            Bitmap edgeImage = new Bitmap(originalImage);

            // Definition of circle
            int centerX = originalImage.Width/2; // 150
            int centerY = originalImage.Height/2; // 150
            int radius = ((centerX + centerY) / 2) - 5; // 145

            stopwatch.Start();
            // Clear pixels outside of circle and run Sobel algorithm
            Bitmap processedImage = SetPixelsOutsideCircleToBlack(originalImage);
            // Dispose the used image
            originalImage.Dispose();
            // Run Sobel algorithm to detect an edge on image that was already processed.
            edgeImage = SobelAlgorithm(processedImage, centerX, centerY, radius);
            stopwatch.Stop();

            // Dispose the used image
            processedImage.Dispose();

            // Get the actual function that best fits the points
            LinearFunction linearFunction = Point.Aproximation(edgeImage);
            // Display the linear function in message box
            linearFunction.Show();

            // Display the time spent to process the image
            MessageBox.Show($"Time elapsed: {stopwatch.ElapsedMilliseconds} milliseconds");

            // Set image with only the edge to be visible in picture2
            return edgeImage;
        }

        // Save the processed image as PNG
        public static void Save(ref PictureBox pictureBox)
        {
            Bitmap imageToBeSaved = new Bitmap(pictureBox.Image);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Image Files|*.png";
            sfd.FileName = $"{DateTime.Now:yyyy_MM_dd_HH_mm_ss}.png";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    imageToBeSaved.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Something went wrong! This is the message: {ex.Message}");
                }
            }
        }

        // Sobel edge detection algorithm within a specific circle
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
                        //Color newColor = Color.FromArgb(magnitude, magnitude, magnitude);
                        Color newColor = magnitude > 128 ? Color.White : Color.Black; // Set to white if the magnitude is greater than 128, otherwise set to black
                        edgeDetectedImage.SetPixel(x, y, newColor);
                    }
                }
            }
            edgeDetectedImage = SetPixelsOutsideCircleToBlack(edgeDetectedImage, 2);
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
        static Bitmap SetPixelsOutsideCircleToBlack(Bitmap bitmap, int hack = 0)
        {
            Bitmap processedImage = new Bitmap(bitmap);

            int centerX = bitmap.Width / 2;
            int centerY = bitmap.Height / 2;
            int radius = ((centerX + centerY) / 2) - 5 - hack;

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

        // Boundary detection
        public static Bitmap DetectBoundary(Bitmap image)
        {
            Stopwatch stopwatch = new Stopwatch();
            Bitmap result = new Bitmap(image);
            stopwatch.Start();
            for (int y = 1; y < image.Height - 1; y++)
            {
                for (int x = 1; x < image.Width - 1; x++)
                {
                    if (Stamp(image, x, y)) result.SetPixel(x, y, Color.Black);
                }
            }

            result = SetPixelsOutsideCircleToBlack(result, 2); // I don't know how to detect a circle.
            stopwatch.Stop();

            // Aproximate the points and get linear function parameters
            LinearFunction linearFunction = Point.Aproximation(result);
            // Display the linear function in message box
            linearFunction.Show();

            // Display the time spent to process the image
            MessageBox.Show($"Time elapsed: {stopwatch.ElapsedMilliseconds} milliseconds");

            return result;
        }

        static bool Stamp(Bitmap bitmap, int x, int y)
        {
            int[,] stamp = new int[,] { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 1, 0 } };

            // If the stamp cannot fit in the current position, return without marking as an edge.
            if (x - 1 < 0 || y - 1 < 0 || x + 1 >= bitmap.Width || y + 1 >= bitmap.Height) return false;

            for (int j = -1; j <= 1; j++)
            {
                for (int i = -1; i <= 1; i++)
                {
                    Color currentColor = bitmap.GetPixel(x + i, y + j);
                    if (!IsGreen(currentColor) && stamp[j + 1, i + 1] == 1)
                    {
                        // If the stamp does not match the green pixels, return without marking as an edge.
                        return false;
                    }
                }
            }

            // Mark the pixel as an edge if the stamp matches the green pixels.
            return true;
        }


        // Check if the green component is significantly higher than red and blue
        static bool IsGreen(Color color)
        {
            int greenThreshold = 100;

            if (color.G - color.R > greenThreshold && color.G - color.B > greenThreshold)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
