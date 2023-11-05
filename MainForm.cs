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
        }

        Bitmap originalImage;
        Bitmap edgeImage;

        private void btnOpen_Click(object sender, EventArgs e)
        {

            originalImage = Image.Open();
            picture1.Image = originalImage;
        }

        private void btnDetectEdges_Click(object sender, EventArgs e)
        {
            edgeImage = Image.DetectEdges(ref originalImage);
            picture2.Image = edgeImage;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Image.Save(ref picture2);
        }

        private void btnSaveCSV_Click(object sender, EventArgs e)
        {
            Point.Save();
        }

        private void btnBoundaryDetection_Click(object sender, EventArgs e)
        {
            picture2.Image = Image.DetectBoundary(originalImage);
        }
    }
}
