﻿namespace Drum
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnDetectEdges = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBoundaryDetection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnSaveImage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSavePng = new System.Windows.Forms.ToolStripMenuItem();
            this.layout1 = new System.Windows.Forms.TableLayoutPanel();
            this.layout2 = new System.Windows.Forms.TableLayoutPanel();
            this.picture2 = new System.Windows.Forms.PictureBox();
            this.picture1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTest = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.layout1.SuspendLayout();
            this.layout2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen,
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.btnTest});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(462, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(76, 22);
            this.btnOpen.Text = "Open image";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDetectEdges,
            this.btnBoundaryDetection});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(113, 22);
            this.toolStripDropDownButton1.Text = "Image processing";
            // 
            // btnDetectEdges
            // 
            this.btnDetectEdges.Name = "btnDetectEdges";
            this.btnDetectEdges.Size = new System.Drawing.Size(219, 22);
            this.btnDetectEdges.Text = "Detect edges (old)";
            this.btnDetectEdges.Click += new System.EventHandler(this.btnDetectEdges_Click);
            // 
            // btnBoundaryDetection
            // 
            this.btnBoundaryDetection.Name = "btnBoundaryDetection";
            this.btnBoundaryDetection.Size = new System.Drawing.Size(219, 22);
            this.btnBoundaryDetection.Text = "Boundary detection (green)";
            this.btnBoundaryDetection.Click += new System.EventHandler(this.btnBoundaryDetection_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSaveImage,
            this.btnSavePng});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(44, 22);
            this.toolStripDropDownButton2.Text = "Save";
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(145, 22);
            this.btnSaveImage.Text = "Image (.PNG)";
            this.btnSaveImage.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSavePng
            // 
            this.btnSavePng.Name = "btnSavePng";
            this.btnSavePng.Size = new System.Drawing.Size(145, 22);
            this.btnSavePng.Text = "CSV file";
            this.btnSavePng.Click += new System.EventHandler(this.btnSaveCSV_Click);
            // 
            // layout1
            // 
            this.layout1.ColumnCount = 2;
            this.layout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.layout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 312F));
            this.layout1.Controls.Add(this.layout2, 1, 0);
            this.layout1.Controls.Add(this.panel1, 0, 0);
            this.layout1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout1.Location = new System.Drawing.Point(0, 25);
            this.layout1.Margin = new System.Windows.Forms.Padding(0);
            this.layout1.Name = "layout1";
            this.layout1.RowCount = 1;
            this.layout1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layout1.Size = new System.Drawing.Size(462, 618);
            this.layout1.TabIndex = 1;
            // 
            // layout2
            // 
            this.layout2.ColumnCount = 1;
            this.layout2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layout2.Controls.Add(this.picture2, 0, 1);
            this.layout2.Controls.Add(this.picture1, 0, 0);
            this.layout2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout2.Location = new System.Drawing.Point(153, 3);
            this.layout2.Name = "layout2";
            this.layout2.RowCount = 2;
            this.layout2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layout2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layout2.Size = new System.Drawing.Size(306, 612);
            this.layout2.TabIndex = 0;
            // 
            // picture2
            // 
            this.picture2.Location = new System.Drawing.Point(3, 309);
            this.picture2.Name = "picture2";
            this.picture2.Size = new System.Drawing.Size(300, 300);
            this.picture2.TabIndex = 2;
            this.picture2.TabStop = false;
            // 
            // picture1
            // 
            this.picture1.Location = new System.Drawing.Point(3, 3);
            this.picture1.Name = "picture1";
            this.picture1.Size = new System.Drawing.Size(300, 300);
            this.picture1.TabIndex = 1;
            this.picture1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 612);
            this.panel1.TabIndex = 1;
            // 
            // btnTest
            // 
            this.btnTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnTest.Image = ((System.Drawing.Image)(resources.GetObject("btnTest.Image")));
            this.btnTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(35, 22);
            this.btnTest.Text = "TEST";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 643);
            this.Controls.Add(this.layout1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(478, 682);
            this.MinimumSize = new System.Drawing.Size(478, 682);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImageProcessingZaLerhera";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.layout1.ResumeLayout(false);
            this.layout2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.TableLayoutPanel layout1;
        private System.Windows.Forms.TableLayoutPanel layout2;
        private System.Windows.Forms.PictureBox picture2;
        private System.Windows.Forms.PictureBox picture1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem btnDetectEdges;
        private System.Windows.Forms.ToolStripMenuItem btnBoundaryDetection;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem btnSaveImage;
        private System.Windows.Forms.ToolStripMenuItem btnSavePng;
        private System.Windows.Forms.ToolStripButton btnTest;
    }
}

