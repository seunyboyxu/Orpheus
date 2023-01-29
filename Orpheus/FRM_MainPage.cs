﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Orpheus_MidiFileMaker;


namespace Orpheus
{
    public partial class FRM_MainPage : Form
    {
        public FRM_MainPage()
        {
            InitializeComponent();
            //BTN_Title.Parent = PCBX_Background;
            //BTN_Generate.Parent = PCBX_Background;
            //PCBX_BPM.Parent = PCBX_Background;
            //PCBX_TimeSig.Parent = PCBX_Background;
            //PCBX_Randomness.Parent = PCBX_Background;
            //PCBX_ExcludedNotes.Parent = PCBX_Background;
            //PCBX_PatternSeed.Parent = PCBX_Background;
            //BTN_LoadMidiFiles.Parent = PCBX_Background;
            //BTN_Settings.Parent = PCBX_Background;
            //PNL_MainMenuItems.Parent = PCBX_Background;
        }

        private void TXBX_PatternSeed_TextChanged(object sender, EventArgs e)
        {

        }

        private void BTN_PatternSeedGen_Click(object sender, EventArgs e)
        {
            Random random= new Random();
            int seedINT1 = random.Next(100, 900);
            int seedINT2 = random.Next(100, 900);
            string seed = seedINT1.ToString() + seedINT2.ToString();
            TXBX_PatternSeed.Text = seed;
        }

        private void BTN_Generate_Click(object sender, EventArgs e)
        {
            string patternseed = TXBX_PatternSeed.Text;
            string[] excludednotes = LSBX_ExcludedNotes.CheckedItems.Cast<string>().ToArray();
            string KeySig = CMBX_KeySigniture.Text;
            string KeySigMajMin = CMBX_MajMin.Text;
            int bpm = (int)TXT_BPM.Value;
            int randomness = (int)TXT_Randomness.Value;
            string timesig = CMBX_TimeSig.Text;

            
            
            InputData UserData = new InputData(patternseed, excludednotes, bpm, timesig , randomness, KeySig, KeySigMajMin);
            Orpheus_MidiFileMaker.MidiMaker.Generate(UserData);
            Console.WriteLine("done");
        }

        private void BTN_Title_Click(object sender, EventArgs e)
        {
              
        }

        private void BTN_Settings_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            FRM_SettingsPage settingsPage = new FRM_SettingsPage();
            settingsPage.ShowDialog();
            this.Close();
        }

        private void BTN_LoadMidiFiles_Click(object sender, EventArgs e)
        {
            this.Hide();
            FRM_LoadMidiFiles MidiFileLoader = new FRM_LoadMidiFiles();
            MidiFileLoader.ShowDialog();
            this.Close();
        }
    }

    


}