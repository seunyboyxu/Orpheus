using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Orpheus_Analyser;

namespace Orpheus_Analyser
{
    public partial class MidiAnalyser_LoadingPage : Form
    {
        public MidiAnalyser_LoadingPage()
        {
            InitializeComponent();
        }

        private void BTN_Run_Click(object sender, EventArgs e)
        {
            MidiAnalyser.LoadMidiFiles();
        }
    }
}
