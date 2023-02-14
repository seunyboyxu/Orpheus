using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using Orpheus;

namespace Orpheus
{
    public partial class FRM_SplashScreen : Form
    {
        public FRM_SplashScreen()
        {
            InitializeComponent();
        }

        public int timeLeft { get; set; }

        private void FRM_SplashScreen_Load(object sender, EventArgs e)
        {
            timeLeft = 50;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {

                timeLeft = timeLeft - 1;

            }

            else

            {

                timer1.Stop();

                new FRM_MainPage().Show();

                this.Hide();
            }
        }
    }
}
