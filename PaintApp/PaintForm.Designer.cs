
namespace PaintApp
{
    partial class PaintForm
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
            this.Canvas = new System.Windows.Forms.Panel();
            this.ColourPalette = new System.Windows.Forms.Panel();
            this.BlackBox = new System.Windows.Forms.PictureBox();
            this.WhiteBox = new System.Windows.Forms.PictureBox();
            this.PinkBox = new System.Windows.Forms.PictureBox();
            this.PurpleBox = new System.Windows.Forms.PictureBox();
            this.BlueBox = new System.Windows.Forms.PictureBox();
            this.GreenBox = new System.Windows.Forms.PictureBox();
            this.YellowBox = new System.Windows.Forms.PictureBox();
            this.OrangeBox = new System.Windows.Forms.PictureBox();
            this.RedBox = new System.Windows.Forms.PictureBox();
            this.Canvas.SuspendLayout();
            this.ColourPalette.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlackBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WhiteBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinkBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurpleBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YellowBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrangeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.BackColor = System.Drawing.Color.White;
            this.Canvas.Controls.Add(this.ColourPalette);
            this.Canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Canvas.Location = new System.Drawing.Point(0, 0);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(800, 450);
            this.Canvas.TabIndex = 0;
            this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            this.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            this.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseUp);
            // 
            // ColourPalette
            // 
            this.ColourPalette.BackColor = System.Drawing.Color.Silver;
            this.ColourPalette.Controls.Add(this.BlackBox);
            this.ColourPalette.Controls.Add(this.WhiteBox);
            this.ColourPalette.Controls.Add(this.PinkBox);
            this.ColourPalette.Controls.Add(this.PurpleBox);
            this.ColourPalette.Controls.Add(this.BlueBox);
            this.ColourPalette.Controls.Add(this.GreenBox);
            this.ColourPalette.Controls.Add(this.YellowBox);
            this.ColourPalette.Controls.Add(this.OrangeBox);
            this.ColourPalette.Controls.Add(this.RedBox);
            this.ColourPalette.Location = new System.Drawing.Point(505, 12);
            this.ColourPalette.Name = "ColourPalette";
            this.ColourPalette.Size = new System.Drawing.Size(283, 32);
            this.ColourPalette.TabIndex = 0;
            // 
            // BlackBox
            // 
            this.BlackBox.BackColor = System.Drawing.Color.Black;
            this.BlackBox.Location = new System.Drawing.Point(253, 4);
            this.BlackBox.Name = "BlackBox";
            this.BlackBox.Size = new System.Drawing.Size(25, 24);
            this.BlackBox.TabIndex = 8;
            this.BlackBox.TabStop = false;
            this.BlackBox.Click += new System.EventHandler(this.ColourBox_Click);
            // 
            // WhiteBox
            // 
            this.WhiteBox.BackColor = System.Drawing.Color.White;
            this.WhiteBox.Location = new System.Drawing.Point(222, 4);
            this.WhiteBox.Name = "WhiteBox";
            this.WhiteBox.Size = new System.Drawing.Size(25, 24);
            this.WhiteBox.TabIndex = 7;
            this.WhiteBox.TabStop = false;
            this.WhiteBox.Click += new System.EventHandler(this.ColourBox_Click);
            // 
            // PinkBox
            // 
            this.PinkBox.BackColor = System.Drawing.Color.Fuchsia;
            this.PinkBox.Location = new System.Drawing.Point(191, 4);
            this.PinkBox.Name = "PinkBox";
            this.PinkBox.Size = new System.Drawing.Size(25, 24);
            this.PinkBox.TabIndex = 6;
            this.PinkBox.TabStop = false;
            this.PinkBox.Click += new System.EventHandler(this.ColourBox_Click);
            // 
            // PurpleBox
            // 
            this.PurpleBox.BackColor = System.Drawing.Color.Purple;
            this.PurpleBox.Location = new System.Drawing.Point(160, 4);
            this.PurpleBox.Name = "PurpleBox";
            this.PurpleBox.Size = new System.Drawing.Size(25, 24);
            this.PurpleBox.TabIndex = 5;
            this.PurpleBox.TabStop = false;
            this.PurpleBox.Click += new System.EventHandler(this.ColourBox_Click);
            // 
            // BlueBox
            // 
            this.BlueBox.BackColor = System.Drawing.Color.Aqua;
            this.BlueBox.Location = new System.Drawing.Point(129, 4);
            this.BlueBox.Name = "BlueBox";
            this.BlueBox.Size = new System.Drawing.Size(25, 24);
            this.BlueBox.TabIndex = 4;
            this.BlueBox.TabStop = false;
            this.BlueBox.Click += new System.EventHandler(this.ColourBox_Click);
            // 
            // GreenBox
            // 
            this.GreenBox.BackColor = System.Drawing.Color.Lime;
            this.GreenBox.Location = new System.Drawing.Point(98, 4);
            this.GreenBox.Name = "GreenBox";
            this.GreenBox.Size = new System.Drawing.Size(25, 24);
            this.GreenBox.TabIndex = 3;
            this.GreenBox.TabStop = false;
            this.GreenBox.Click += new System.EventHandler(this.ColourBox_Click);
            // 
            // YellowBox
            // 
            this.YellowBox.BackColor = System.Drawing.Color.Yellow;
            this.YellowBox.Location = new System.Drawing.Point(67, 4);
            this.YellowBox.Name = "YellowBox";
            this.YellowBox.Size = new System.Drawing.Size(25, 24);
            this.YellowBox.TabIndex = 2;
            this.YellowBox.TabStop = false;
            this.YellowBox.Click += new System.EventHandler(this.ColourBox_Click);
            // 
            // OrangeBox
            // 
            this.OrangeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.OrangeBox.Location = new System.Drawing.Point(36, 4);
            this.OrangeBox.Name = "OrangeBox";
            this.OrangeBox.Size = new System.Drawing.Size(25, 24);
            this.OrangeBox.TabIndex = 1;
            this.OrangeBox.TabStop = false;
            this.OrangeBox.Click += new System.EventHandler(this.ColourBox_Click);
            // 
            // RedBox
            // 
            this.RedBox.BackColor = System.Drawing.Color.Red;
            this.RedBox.Location = new System.Drawing.Point(5, 4);
            this.RedBox.Name = "RedBox";
            this.RedBox.Size = new System.Drawing.Size(25, 24);
            this.RedBox.TabIndex = 0;
            this.RedBox.TabStop = false;
            this.RedBox.Click += new System.EventHandler(this.ColourBox_Click);
            // 
            // PaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Canvas);
            this.Name = "PaintForm";
            this.Text = "Paint Application";
            this.Canvas.ResumeLayout(false);
            this.ColourPalette.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BlackBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WhiteBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PinkBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurpleBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YellowBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrangeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Canvas;
        private System.Windows.Forms.Panel ColourPalette;
        private System.Windows.Forms.PictureBox BlackBox;
        private System.Windows.Forms.PictureBox WhiteBox;
        private System.Windows.Forms.PictureBox PinkBox;
        private System.Windows.Forms.PictureBox PurpleBox;
        private System.Windows.Forms.PictureBox BlueBox;
        private System.Windows.Forms.PictureBox GreenBox;
        private System.Windows.Forms.PictureBox YellowBox;
        private System.Windows.Forms.PictureBox OrangeBox;
        private System.Windows.Forms.PictureBox RedBox;
    }
}

