using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Drum
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Create context menus
            Tools picture1Tools = new Tools();
            Tools picture2Tools = new Tools();

            picture1Tools.PictureContextMenu(picture1);
            picture2Tools.PictureContextMenu(picture2);
        }

        Bitmap originalImage;
        Bitmap edgeImage;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            // Image opening
            originalImage = Image.Open();
            picture1.Image = originalImage;
        }

        private void btnDetectEdges_Click(object sender, EventArgs e)
        {
            // Edge detection
            edgeImage = Image.DetectEdges(ref originalImage);
            picture2.Image = edgeImage;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Save the image as .PNG
            Image.Save(picture2);
        }

        private void btnSaveCSV_Click(object sender, EventArgs e)
        {
            // Save the points in .CSV file
            Point.Save();
        }

        private void btnBoundaryDetection_Click(object sender, EventArgs e)
        {
            // Boundary detection
            picture2.Image = Image.DetectBoundary(originalImage);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            
        }
    }
}
