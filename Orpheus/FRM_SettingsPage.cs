using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orpheus
{
    public partial class FRM_SettingsPage : Form
    {
        public FRM_SettingsPage()
        {
            InitializeComponent();
        }

        private void BTN_Title_Click(object sender, EventArgs e)
        {
            this.Hide();
            FRM_MainPage MainPage = new FRM_MainPage();
            MainPage.ShowDialog();
            this.Close();
        }
    }
}
