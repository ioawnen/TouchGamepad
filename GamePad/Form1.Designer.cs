namespace gamepad
{
    partial class Form1
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
            this.yButtonImage = new System.Windows.Forms.PictureBox();
            this.xButtonImage = new System.Windows.Forms.PictureBox();
            this.bButtonImage = new System.Windows.Forms.PictureBox();
            this.aButtonImage = new System.Windows.Forms.PictureBox();
            this.rightImage = new System.Windows.Forms.PictureBox();
            this.downImage = new System.Windows.Forms.PictureBox();
            this.leftImage = new System.Windows.Forms.PictureBox();
            this.upImage = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.yButtonImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bButtonImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aButtonImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.downImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // yButtonImage
            // 
            this.yButtonImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.yButtonImage.Image = global::gamepad.Properties.Resources.y;
            this.yButtonImage.Location = new System.Drawing.Point(1084, 258);
            this.yButtonImage.Name = "yButtonImage";
            this.yButtonImage.Size = new System.Drawing.Size(128, 128);
            this.yButtonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.yButtonImage.TabIndex = 7;
            this.yButtonImage.TabStop = false;
            this.yButtonImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.yButtonPress);
            // 
            // xButtonImage
            // 
            this.xButtonImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.xButtonImage.Image = global::gamepad.Properties.Resources.x;
            this.xButtonImage.Location = new System.Drawing.Point(950, 392);
            this.xButtonImage.Name = "xButtonImage";
            this.xButtonImage.Size = new System.Drawing.Size(128, 128);
            this.xButtonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.xButtonImage.TabIndex = 6;
            this.xButtonImage.TabStop = false;
            this.xButtonImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.xButtonPress);
            // 
            // bButtonImage
            // 
            this.bButtonImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bButtonImage.Image = global::gamepad.Properties.Resources.b;
            this.bButtonImage.Location = new System.Drawing.Point(1218, 392);
            this.bButtonImage.Name = "bButtonImage";
            this.bButtonImage.Size = new System.Drawing.Size(128, 128);
            this.bButtonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bButtonImage.TabIndex = 5;
            this.bButtonImage.TabStop = false;
            this.bButtonImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bButtonPress);
            // 
            // aButtonImage
            // 
            this.aButtonImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aButtonImage.Image = global::gamepad.Properties.Resources.a;
            this.aButtonImage.Location = new System.Drawing.Point(1084, 526);
            this.aButtonImage.Name = "aButtonImage";
            this.aButtonImage.Size = new System.Drawing.Size(128, 128);
            this.aButtonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.aButtonImage.TabIndex = 4;
            this.aButtonImage.TabStop = false;
            this.aButtonImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.aButtonPress);
            // 
            // rightImage
            // 
            this.rightImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rightImage.Image = global::gamepad.Properties.Resources.right;
            this.rightImage.Location = new System.Drawing.Point(274, 392);
            this.rightImage.Name = "rightImage";
            this.rightImage.Size = new System.Drawing.Size(128, 128);
            this.rightImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rightImage.TabIndex = 3;
            this.rightImage.TabStop = false;
            this.rightImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rightPress);
            // 
            // downImage
            // 
            this.downImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.downImage.Image = global::gamepad.Properties.Resources.down;
            this.downImage.Location = new System.Drawing.Point(140, 526);
            this.downImage.Name = "downImage";
            this.downImage.Size = new System.Drawing.Size(128, 128);
            this.downImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.downImage.TabIndex = 2;
            this.downImage.TabStop = false;
            this.downImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.downPress);
            // 
            // leftImage
            // 
            this.leftImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.leftImage.Image = global::gamepad.Properties.Resources.left;
            this.leftImage.Location = new System.Drawing.Point(6, 392);
            this.leftImage.Name = "leftImage";
            this.leftImage.Size = new System.Drawing.Size(128, 128);
            this.leftImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.leftImage.TabIndex = 1;
            this.leftImage.TabStop = false;
            this.leftImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.leftPress);
            // 
            // upImage
            // 
            this.upImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.upImage.Image = global::gamepad.Properties.Resources.up;
            this.upImage.Location = new System.Drawing.Point(140, 258);
            this.upImage.Name = "upImage";
            this.upImage.Size = new System.Drawing.Size(128, 128);
            this.upImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.upImage.TabIndex = 0;
            this.upImage.TabStop = false;
            this.upImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.upPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox1.Image = global::gamepad.Properties.Resources.menu;
            this.pictureBox1.Location = new System.Drawing.Point(616, 526);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuButtonPress);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox2.Image = global::gamepad.Properties.Resources.select;
            this.pictureBox2.Location = new System.Drawing.Point(482, 526);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(128, 128);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.selectButtonPress);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBox3.Image = global::gamepad.Properties.Resources.start;
            this.pictureBox3.Location = new System.Drawing.Point(750, 526);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(128, 128);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.startButtonPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Magenta;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1348, 697);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.yButtonImage);
            this.Controls.Add(this.xButtonImage);
            this.Controls.Add(this.bButtonImage);
            this.Controls.Add(this.aButtonImage);
            this.Controls.Add(this.rightImage);
            this.Controls.Add(this.downImage);
            this.Controls.Add(this.leftImage);
            this.Controls.Add(this.upImage);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "Gamepad";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Magenta;
            ((System.ComponentModel.ISupportInitialize)(this.yButtonImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bButtonImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aButtonImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.downImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox upImage;
        private System.Windows.Forms.PictureBox leftImage;
        private System.Windows.Forms.PictureBox downImage;
        private System.Windows.Forms.PictureBox rightImage;
        private System.Windows.Forms.PictureBox aButtonImage;
        private System.Windows.Forms.PictureBox bButtonImage;
        private System.Windows.Forms.PictureBox xButtonImage;
        private System.Windows.Forms.PictureBox yButtonImage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

