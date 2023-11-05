using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drum
{
    internal class Tools
    {
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem saveAsPngMenuItem;
        private PictureBox pictureBox;

        public void PictureContextMenu(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            contextMenuStrip = new ContextMenuStrip();

            // Add menu item for saving as PNG
            saveAsPngMenuItem = new ToolStripMenuItem("Save image as PNG");
            saveAsPngMenuItem.Click += SaveAsPngMenuItem_Click;
            contextMenuStrip.Items.Add(saveAsPngMenuItem);

            // Attach the menu item to the context menu
            this.pictureBox.ContextMenuStrip = contextMenuStrip;
        }

        // For some reason i couldn't use the Image.Save() :)
        private void SaveAsPngMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                Bitmap imageToBeSaved = new Bitmap(pictureBox.Image);

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PNG Files (*.png)|*.png";
                    sfd.FileName = $"{DateTime.Now:yyyy_MM_dd_HH_mm_ss}.png";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        imageToBeSaved.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    }
                }
            }
        }
    }
}
