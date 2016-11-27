namespace LiquidViscosity
{
    partial class SplashScreen
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
            this.components = new System.ComponentModel.Container();
            this.SplashTimer = new System.Windows.Forms.Timer(this.components);
            this.SplashImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SplashImage)).BeginInit();
            this.SuspendLayout();
            // 
            // SplashTimer
            // 
            this.SplashTimer.Interval = 5000;
            this.SplashTimer.Tick += new System.EventHandler(this.SplashTimer_Tick);
            // 
            // SplashImage
            // 
            this.SplashImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SplashImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplashImage.Image = global::LiquidViscosity.Properties.Resources.Splash;
            this.SplashImage.InitialImage = global::LiquidViscosity.Properties.Resources.Splash;
            this.SplashImage.Location = new System.Drawing.Point(0, 0);
            this.SplashImage.Name = "SplashImage";
            this.SplashImage.Size = new System.Drawing.Size(575, 327);
            this.SplashImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.SplashImage.TabIndex = 0;
            this.SplashImage.TabStop = false;
            // 
            // SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 327);
            this.ControlBox = false;
            this.Controls.Add(this.SplashImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SplashScreen";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SplashScreen_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.SplashImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox SplashImage;
        private System.Windows.Forms.Timer SplashTimer;
    }
}