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
    public partial class FRM_LoadMidiFiles : Form
    {
        public FRM_LoadMidiFiles()
        {
            InitializeComponent();
        }

        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            FRM_MainPage mainPage = new FRM_MainPage();
            mainPage.ShowDialog();
            this.Close();
        }

        private void BTN_Run_Click(object sender, EventArgs e)
        {
            Orpheus_Analyser.MidiAnalyser.LoadMidiFiles();
            FRM_MainPage mainPage = new FRM_MainPage();
            mainPage.ShowDialog();
            this.Close();
        }
    }
}
