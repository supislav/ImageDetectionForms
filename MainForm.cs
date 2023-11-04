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
            Image.Open(ref originalImage, ref picture1);
        }

        private void btnDetectEdges_Click(object sender, EventArgs e)
        {
            Image.Process(ref originalImage, ref edgeImage, ref picture2);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Image.Save(ref edgeImage);
        }

        private void btnSaveCSV_Click(object sender, EventArgs e)
        {
            Point.Save();
        }
    }
}
