namespace Orpheus
{
    partial class FRM_MainPage
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
            this.PCBX_PatternSeed = new System.Windows.Forms.PictureBox();
            this.PCBX_ExcludedNotes = new System.Windows.Forms.PictureBox();
            this.PCBX_Randomness = new System.Windows.Forms.PictureBox();
            this.PCBX_TimeSig = new System.Windows.Forms.PictureBox();
            this.PCBX_BPM = new System.Windows.Forms.PictureBox();
            this.BTN_Generate = new System.Windows.Forms.Button();
            this.PCBX_Background = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TXT_BPM = new System.Windows.Forms.NumericUpDown();
            this.CMBX_TimeSig = new System.Windows.Forms.ComboBox();
            this.LSBX_ExcludedNotes = new System.Windows.Forms.CheckedListBox();
            this.BTN_PatternSeedGen = new System.Windows.Forms.Button();
            this.TXBX_PatternSeed = new System.Windows.Forms.TextBox();
            this.TXT_Randomness = new System.Windows.Forms.NumericUpDown();
            this.BTN_Title = new System.Windows.Forms.Button();
            this.BTN_Settings = new System.Windows.Forms.Button();
            this.BTN_LoadMidiFiles = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PCBX_PatternSeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCBX_ExcludedNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCBX_Randomness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCBX_TimeSig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCBX_BPM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCBX_Background)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_BPM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_Randomness)).BeginInit();
            this.SuspendLayout();
            // 
            // PCBX_PatternSeed
            // 
            this.PCBX_PatternSeed.BackColor = System.Drawing.Color.Transparent;
            this.PCBX_PatternSeed.Image = global::Orpheus.Properties.Resources.Pattern_Seed;
            this.PCBX_PatternSeed.Location = new System.Drawing.Point(26, 485);
            this.PCBX_PatternSeed.Name = "PCBX_PatternSeed";
            this.PCBX_PatternSeed.Size = new System.Drawing.Size(322, 44);
            this.PCBX_PatternSeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PCBX_PatternSeed.TabIndex = 7;
            this.PCBX_PatternSeed.TabStop = false;
            // 
            // PCBX_ExcludedNotes
            // 
            this.PCBX_ExcludedNotes.BackColor = System.Drawing.Color.Transparent;
            this.PCBX_ExcludedNotes.Image = global::Orpheus.Properties.Resources.Excluded_Notes;
            this.PCBX_ExcludedNotes.Location = new System.Drawing.Point(354, 273);
            this.PCBX_ExcludedNotes.Name = "PCBX_ExcludedNotes";
            this.PCBX_ExcludedNotes.Size = new System.Drawing.Size(342, 40);
            this.PCBX_ExcludedNotes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PCBX_ExcludedNotes.TabIndex = 6;
            this.PCBX_ExcludedNotes.TabStop = false;
            // 
            // PCBX_Randomness
            // 
            this.PCBX_Randomness.BackColor = System.Drawing.Color.Transparent;
            this.PCBX_Randomness.Image = global::Orpheus.Properties.Resources.Randomness;
            this.PCBX_Randomness.Location = new System.Drawing.Point(682, 485);
            this.PCBX_Randomness.Name = "PCBX_Randomness";
            this.PCBX_Randomness.Size = new System.Drawing.Size(332, 44);
            this.PCBX_Randomness.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PCBX_Randomness.TabIndex = 5;
            this.PCBX_Randomness.TabStop = false;
            // 
            // PCBX_TimeSig
            // 
            this.PCBX_TimeSig.BackColor = System.Drawing.Color.Transparent;
            this.PCBX_TimeSig.Image = global::Orpheus.Properties.Resources.Time_Signiture;
            this.PCBX_TimeSig.Location = new System.Drawing.Point(1210, 485);
            this.PCBX_TimeSig.Name = "PCBX_TimeSig";
            this.PCBX_TimeSig.Size = new System.Drawing.Size(344, 44);
            this.PCBX_TimeSig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PCBX_TimeSig.TabIndex = 4;
            this.PCBX_TimeSig.TabStop = false;
            // 
            // PCBX_BPM
            // 
            this.PCBX_BPM.BackColor = System.Drawing.Color.Transparent;
            this.PCBX_BPM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PCBX_BPM.Image = global::Orpheus.Properties.Resources.BPM;
            this.PCBX_BPM.InitialImage = null;
            this.PCBX_BPM.Location = new System.Drawing.Point(1060, 273);
            this.PCBX_BPM.Margin = new System.Windows.Forms.Padding(0);
            this.PCBX_BPM.Name = "PCBX_BPM";
            this.PCBX_BPM.Size = new System.Drawing.Size(145, 50);
            this.PCBX_BPM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PCBX_BPM.TabIndex = 3;
            this.PCBX_BPM.TabStop = false;
            // 
            // BTN_Generate
            // 
            this.BTN_Generate.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Generate.BackgroundImage = global::Orpheus.Properties.Resources.Generate_Logo;
            this.BTN_Generate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BTN_Generate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_Generate.FlatAppearance.BorderSize = 0;
            this.BTN_Generate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Generate.ForeColor = System.Drawing.Color.Transparent;
            this.BTN_Generate.Location = new System.Drawing.Point(607, 743);
            this.BTN_Generate.Name = "BTN_Generate";
            this.BTN_Generate.Size = new System.Drawing.Size(485, 83);
            this.BTN_Generate.TabIndex = 2;
            this.BTN_Generate.UseVisualStyleBackColor = false;
            this.BTN_Generate.Click += new System.EventHandler(this.BTN_Generate_Click);
            // 
            // PCBX_Background
            // 
            this.PCBX_Background.Image = global::Orpheus.Properties.Resources.Orpheus_MainBCKGRND1;
            this.PCBX_Background.Location = new System.Drawing.Point(-2, -2);
            this.PCBX_Background.Name = "PCBX_Background";
            this.PCBX_Background.Size = new System.Drawing.Size(1586, 866);
            this.PCBX_Background.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PCBX_Background.TabIndex = 0;
            this.PCBX_Background.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::Orpheus.Properties.Resources.OrpheusLogo;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(74, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(439, 139);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // TXT_BPM
            // 
            this.TXT_BPM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TXT_BPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_BPM.Location = new System.Drawing.Point(1071, 335);
            this.TXT_BPM.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.TXT_BPM.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.TXT_BPM.Name = "TXT_BPM";
            this.TXT_BPM.Size = new System.Drawing.Size(120, 27);
            this.TXT_BPM.TabIndex = 9;
            this.TXT_BPM.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // CMBX_TimeSig
            // 
            this.CMBX_TimeSig.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMBX_TimeSig.FormattingEnabled = true;
            this.CMBX_TimeSig.Items.AddRange(new object[] {
            "None",
            "2/4",
            "3/4",
            "4/4"});
            this.CMBX_TimeSig.Location = new System.Drawing.Point(1315, 535);
            this.CMBX_TimeSig.Name = "CMBX_TimeSig";
            this.CMBX_TimeSig.Size = new System.Drawing.Size(147, 33);
            this.CMBX_TimeSig.TabIndex = 10;
            // 
            // LSBX_ExcludedNotes
            // 
            this.LSBX_ExcludedNotes.CheckOnClick = true;
            this.LSBX_ExcludedNotes.FormattingEnabled = true;
            this.LSBX_ExcludedNotes.Items.AddRange(new object[] {
            "A",
            "A#",
            "B",
            "C",
            "C#",
            "D",
            "D#",
            "E",
            "F",
            "F#",
            "G",
            "G#"});
            this.LSBX_ExcludedNotes.Location = new System.Drawing.Point(416, 319);
            this.LSBX_ExcludedNotes.MultiColumn = true;
            this.LSBX_ExcludedNotes.Name = "LSBX_ExcludedNotes";
            this.LSBX_ExcludedNotes.Size = new System.Drawing.Size(233, 124);
            this.LSBX_ExcludedNotes.TabIndex = 11;
            // 
            // BTN_PatternSeedGen
            // 
            this.BTN_PatternSeedGen.ForeColor = System.Drawing.SystemColors.Control;
            this.BTN_PatternSeedGen.Location = new System.Drawing.Point(354, 545);
            this.BTN_PatternSeedGen.Name = "BTN_PatternSeedGen";
            this.BTN_PatternSeedGen.Size = new System.Drawing.Size(93, 23);
            this.BTN_PatternSeedGen.TabIndex = 12;
            this.BTN_PatternSeedGen.Text = "New Seed";
            this.BTN_PatternSeedGen.UseVisualStyleBackColor = true;
            this.BTN_PatternSeedGen.Click += new System.EventHandler(this.BTN_PatternSeedGen_Click);
            // 
            // TXBX_PatternSeed
            // 
            this.TXBX_PatternSeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXBX_PatternSeed.Location = new System.Drawing.Point(77, 548);
            this.TXBX_PatternSeed.Name = "TXBX_PatternSeed";
            this.TXBX_PatternSeed.Size = new System.Drawing.Size(226, 31);
            this.TXBX_PatternSeed.TabIndex = 13;
            this.TXBX_PatternSeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TXBX_PatternSeed.TextChanged += new System.EventHandler(this.TXBX_PatternSeed_TextChanged);
            // 
            // TXT_Randomness
            // 
            this.TXT_Randomness.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TXT_Randomness.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_Randomness.Location = new System.Drawing.Point(794, 545);
            this.TXT_Randomness.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.TXT_Randomness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TXT_Randomness.Name = "TXT_Randomness";
            this.TXT_Randomness.Size = new System.Drawing.Size(120, 27);
            this.TXT_Randomness.TabIndex = 14;
            this.TXT_Randomness.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // BTN_Title
            // 
            this.BTN_Title.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Title.BackgroundImage = global::Orpheus.Properties.Resources.OrpheusLogo;
            this.BTN_Title.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BTN_Title.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_Title.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.BTN_Title.FlatAppearance.BorderSize = 5;
            this.BTN_Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Title.ForeColor = System.Drawing.Color.Transparent;
            this.BTN_Title.Location = new System.Drawing.Point(9, 9);
            this.BTN_Title.Margin = new System.Windows.Forms.Padding(0);
            this.BTN_Title.Name = "BTN_Title";
            this.BTN_Title.Size = new System.Drawing.Size(500, 119);
            this.BTN_Title.TabIndex = 1;
            this.BTN_Title.UseVisualStyleBackColor = false;
            this.BTN_Title.Click += new System.EventHandler(this.BTN_Title_Click);
            // 
            // BTN_Settings
            // 
            this.BTN_Settings.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Settings.BackgroundImage = global::Orpheus.Properties.Resources.settings_title;
            this.BTN_Settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BTN_Settings.FlatAppearance.BorderSize = 0;
            this.BTN_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Settings.Location = new System.Drawing.Point(512, 9);
            this.BTN_Settings.Name = "BTN_Settings";
            this.BTN_Settings.Size = new System.Drawing.Size(500, 117);
            this.BTN_Settings.TabIndex = 15;
            this.BTN_Settings.UseVisualStyleBackColor = false;
            this.BTN_Settings.Click += new System.EventHandler(this.BTN_Settings_Click_1);
            // 
            // BTN_LoadMidiFiles
            // 
            this.BTN_LoadMidiFiles.BackColor = System.Drawing.Color.Transparent;
            this.BTN_LoadMidiFiles.BackgroundImage = global::Orpheus.Properties.Resources.LoadMidiFiles_Title;
            this.BTN_LoadMidiFiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BTN_LoadMidiFiles.FlatAppearance.BorderSize = 0;
            this.BTN_LoadMidiFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_LoadMidiFiles.Location = new System.Drawing.Point(1018, 9);
            this.BTN_LoadMidiFiles.Name = "BTN_LoadMidiFiles";
            this.BTN_LoadMidiFiles.Size = new System.Drawing.Size(322, 114);
            this.BTN_LoadMidiFiles.TabIndex = 16;
            this.BTN_LoadMidiFiles.UseVisualStyleBackColor = false;
            this.BTN_LoadMidiFiles.Click += new System.EventHandler(this.BTN_LoadMidiFiles_Click);
            // 
            // FRM_MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Orpheus.Properties.Resources.Orpheus_MainBCKGRND1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.BTN_LoadMidiFiles);
            this.Controls.Add(this.BTN_Settings);
            this.Controls.Add(this.BTN_Title);
            this.Controls.Add(this.TXT_Randomness);
            this.Controls.Add(this.TXBX_PatternSeed);
            this.Controls.Add(this.BTN_PatternSeedGen);
            this.Controls.Add(this.LSBX_ExcludedNotes);
            this.Controls.Add(this.CMBX_TimeSig);
            this.Controls.Add(this.TXT_BPM);
            this.Controls.Add(this.PCBX_PatternSeed);
            this.Controls.Add(this.PCBX_ExcludedNotes);
            this.Controls.Add(this.PCBX_Randomness);
            this.Controls.Add(this.PCBX_TimeSig);
            this.Controls.Add(this.PCBX_BPM);
            this.Controls.Add(this.BTN_Generate);
            this.Controls.Add(this.PCBX_Background);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(1600, 900);
            this.MinimumSize = new System.Drawing.Size(1600, 900);
            this.Name = "FRM_MainPage";
            this.Text = "Orpheus";
            ((System.ComponentModel.ISupportInitialize)(this.PCBX_PatternSeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCBX_ExcludedNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCBX_Randomness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCBX_TimeSig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCBX_BPM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCBX_Background)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_BPM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_Randomness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox PCBX_Background;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BTN_Generate;
        private System.Windows.Forms.PictureBox PCBX_BPM;
        private System.Windows.Forms.PictureBox PCBX_TimeSig;
        private System.Windows.Forms.PictureBox PCBX_Randomness;
        private System.Windows.Forms.PictureBox PCBX_ExcludedNotes;
        private System.Windows.Forms.PictureBox PCBX_PatternSeed;
        private System.Windows.Forms.NumericUpDown TXT_BPM;
        private System.Windows.Forms.ComboBox CMBX_TimeSig;
        private System.Windows.Forms.CheckedListBox LSBX_ExcludedNotes;
        private System.Windows.Forms.Button BTN_PatternSeedGen;
        private System.Windows.Forms.TextBox TXBX_PatternSeed;
        private System.Windows.Forms.NumericUpDown TXT_Randomness;
        private System.Windows.Forms.Button BTN_Title;
        private System.Windows.Forms.Button BTN_Settings;
        private System.Windows.Forms.Button BTN_LoadMidiFiles;
    }
}

