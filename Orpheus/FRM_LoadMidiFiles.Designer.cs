﻿namespace Orpheus
{
    partial class FRM_LoadMidiFiles
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
            this.PGB_LoadMidiFiles = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.BTN_Run = new System.Windows.Forms.Button();
            this.BTN_Cancel = new System.Windows.Forms.Button();
            this.LBL_Warning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PGB_LoadMidiFiles
            // 
            this.PGB_LoadMidiFiles.Location = new System.Drawing.Point(45, 189);
            this.PGB_LoadMidiFiles.Name = "PGB_LoadMidiFiles";
            this.PGB_LoadMidiFiles.Size = new System.Drawing.Size(418, 23);
            this.PGB_LoadMidiFiles.Step = 1;
            this.PGB_LoadMidiFiles.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.PGB_LoadMidiFiles.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(25, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(450, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Press the button to sync the midi folder";
            // 
            // BTN_Run
            // 
            this.BTN_Run.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Run.ForeColor = System.Drawing.Color.Black;
            this.BTN_Run.Location = new System.Drawing.Point(45, 138);
            this.BTN_Run.Name = "BTN_Run";
            this.BTN_Run.Size = new System.Drawing.Size(91, 33);
            this.BTN_Run.TabIndex = 2;
            this.BTN_Run.Text = "Run";
            this.BTN_Run.UseVisualStyleBackColor = true;
            this.BTN_Run.Click += new System.EventHandler(this.BTN_Run_Click);
            // 
            // BTN_Cancel
            // 
            this.BTN_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Cancel.ForeColor = System.Drawing.Color.Black;
            this.BTN_Cancel.Location = new System.Drawing.Point(370, 138);
            this.BTN_Cancel.Name = "BTN_Cancel";
            this.BTN_Cancel.Size = new System.Drawing.Size(93, 33);
            this.BTN_Cancel.TabIndex = 3;
            this.BTN_Cancel.Text = "Cancel";
            this.BTN_Cancel.UseVisualStyleBackColor = true;
            this.BTN_Cancel.Click += new System.EventHandler(this.BTN_Cancel_Click);
            // 
            // LBL_Warning
            // 
            this.LBL_Warning.AutoSize = true;
            this.LBL_Warning.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Warning.Location = new System.Drawing.Point(112, 101);
            this.LBL_Warning.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LBL_Warning.Name = "LBL_Warning";
            this.LBL_Warning.Size = new System.Drawing.Size(296, 18);
            this.LBL_Warning.TabIndex = 4;
            this.LBL_Warning.Text = "WARNING THIS WILL TAKE A LONG TIME";
            // 
            // FRM_LoadMidiFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(503, 310);
            this.Controls.Add(this.LBL_Warning);
            this.Controls.Add(this.BTN_Cancel);
            this.Controls.Add(this.BTN_Run);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PGB_LoadMidiFiles);
            this.MaximumSize = new System.Drawing.Size(519, 349);
            this.MinimumSize = new System.Drawing.Size(519, 349);
            this.Name = "FRM_LoadMidiFiles";
            this.Text = "LoadMidiFIles";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar PGB_LoadMidiFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTN_Run;
        private System.Windows.Forms.Button BTN_Cancel;
        private System.Windows.Forms.Label LBL_Warning;
    }
}