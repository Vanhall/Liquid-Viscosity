using System;
using System.Windows.Forms;

namespace LiquidViscosity
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            SplashTimer.Start();
        }

        private void SplashScreen_KeyDown(object sender, KeyEventArgs e)
        {
            SplashTimer.Stop();
            Main Main = new Main();
            Main.Show();
            Hide();
        }

        private void SplashTimer_Tick(object sender, EventArgs e)
        {
            SplashTimer.Stop();
            Main Main = new Main();
            Main.Show();
            Hide();
        }
    }
}
