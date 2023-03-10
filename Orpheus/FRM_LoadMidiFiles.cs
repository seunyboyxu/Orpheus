using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Orpheus_Analyser;

namespace Orpheus
{
    public partial class FRM_LoadMidiFiles : Form
    {
        public int total = Orpheus_Analyser.MidiAnalyser.NumberOfFiles;
        public FRM_LoadMidiFiles()
        {
            
            InitializeComponent();
            //RunAsync();
        }

        public void ProgressBarChanger()
        {
            PGB_LoadMidiFiles.Maximum = total;
            while (PGB_LoadMidiFiles.Value != PGB_LoadMidiFiles.Maximum)
            {
                
                PGB_LoadMidiFiles.Value = Orpheus_Analyser.MidiAnalyser.ProgressTracker;                
            }
        }

        public void RunAsync()
        {
            Task.Run(()=> MidiAnalyser.LoadMidiFiles());
        }
        private void BTN_Cancel_Click(object sender, EventArgs e)
        {
            FRM_MainPage mainPage = new FRM_MainPage();
            mainPage.ShowDialog();
            this.Close();
        }

        private void BTN_Run_Click(object sender, EventArgs e)
        {
            MidiAnalyser.LoadMidiFiles();
            Console.WriteLine("Done");
            FRM_MainPage mainPage = new FRM_MainPage();
            mainPage.ShowDialog();
            this.Close();
        }

        private void PGB_LoadMidiFiles_Click(object sender, EventArgs e)
        {

        }
    }
}
