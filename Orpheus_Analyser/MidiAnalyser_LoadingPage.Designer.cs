namespace Orpheus_Analyser
{
    partial class MidiAnalyser_LoadingPage
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
            this.LBL_Warning = new System.Windows.Forms.Label();
            this.BTN_Cancel = new System.Windows.Forms.Button();
            this.BTN_Run = new System.Windows.Forms.Button();
            this.LBL_Instructions = new System.Windows.Forms.Label();
            this.PGB_LoadMidiFiles = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // LBL_Warning
            // 
            this.LBL_Warning.AutoSize = true;
            this.LBL_Warning.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Warning.Location = new System.Drawing.Point(113, 115);
            this.LBL_Warning.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LBL_Warning.Name = "LBL_Warning";
            this.LBL_Warning.Size = new System.Drawing.Size(296, 18);
            this.LBL_Warning.TabIndex = 9;
            this.LBL_Warning.Text = "WARNING THIS WILL TAKE A LONG TIME";
            // 
            // BTN_Cancel
            // 
            this.BTN_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Cancel.ForeColor = System.Drawing.Color.Black;
            this.BTN_Cancel.Location = new System.Drawing.Point(371, 152);
            this.BTN_Cancel.Name = "BTN_Cancel";
            this.BTN_Cancel.Size = new System.Drawing.Size(93, 33);
            this.BTN_Cancel.TabIndex = 8;
            this.BTN_Cancel.Text = "Cancel";
            this.BTN_Cancel.UseVisualStyleBackColor = true;
            // 
            // BTN_Run
            // 
            this.BTN_Run.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Run.ForeColor = System.Drawing.Color.Black;
            this.BTN_Run.Location = new System.Drawing.Point(46, 152);
            this.BTN_Run.Name = "BTN_Run";
            this.BTN_Run.Size = new System.Drawing.Size(91, 33);
            this.BTN_Run.TabIndex = 7;
            this.BTN_Run.Text = "Run";
            this.BTN_Run.UseVisualStyleBackColor = true;
            this.BTN_Run.Click += new System.EventHandler(this.BTN_Run_Click);
            // 
            // LBL_Instructions
            // 
            this.LBL_Instructions.AutoSize = true;
            this.LBL_Instructions.Font = new System.Drawing.Font("MS Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Instructions.ForeColor = System.Drawing.Color.Black;
            this.LBL_Instructions.Location = new System.Drawing.Point(26, 76);
            this.LBL_Instructions.Name = "LBL_Instructions";
            this.LBL_Instructions.Size = new System.Drawing.Size(450, 21);
            this.LBL_Instructions.TabIndex = 6;
            this.LBL_Instructions.Text = "Press the button to sync the midi folder";
            // 
            // PGB_LoadMidiFiles
            // 
            this.PGB_LoadMidiFiles.Location = new System.Drawing.Point(46, 203);
            this.PGB_LoadMidiFiles.Name = "PGB_LoadMidiFiles";
            this.PGB_LoadMidiFiles.Size = new System.Drawing.Size(418, 23);
            this.PGB_LoadMidiFiles.Step = 1;
            this.PGB_LoadMidiFiles.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.PGB_LoadMidiFiles.TabIndex = 5;
            // 
            // MidiAnalyser_LoadingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 310);
            this.Controls.Add(this.LBL_Warning);
            this.Controls.Add(this.BTN_Cancel);
            this.Controls.Add(this.BTN_Run);
            this.Controls.Add(this.LBL_Instructions);
            this.Controls.Add(this.PGB_LoadMidiFiles);
            this.MaximumSize = new System.Drawing.Size(519, 349);
            this.MinimumSize = new System.Drawing.Size(519, 349);
            this.Name = "MidiAnalyser_LoadingPage";
            this.Text = "MidiAnalyser_LoadingPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LBL_Warning;
        public System.Windows.Forms.Button BTN_Cancel;
        public System.Windows.Forms.Button BTN_Run;
        private System.Windows.Forms.Label LBL_Instructions;
        public System.Windows.Forms.ProgressBar PGB_LoadMidiFiles;

        public void SetProgressBar(int value, int max) 
        {
            this.PGB_LoadMidiFiles.Value = value;
            this.PGB_LoadMidiFiles.Maximum= max;
        }
    }
}