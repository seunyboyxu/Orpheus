namespace Orpheus
{
    partial class FRM_SettingsPage
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
            this.BTN_Title = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTN_Title
            // 
            this.BTN_Title.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Title.BackgroundImage = global::Orpheus.Properties.Resources.OrpheusLogo;
            this.BTN_Title.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BTN_Title.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_Title.FlatAppearance.BorderSize = 0;
            this.BTN_Title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Title.ForeColor = System.Drawing.Color.Transparent;
            this.BTN_Title.Location = new System.Drawing.Point(9, 9);
            this.BTN_Title.Margin = new System.Windows.Forms.Padding(0);
            this.BTN_Title.Name = "BTN_Title";
            this.BTN_Title.Size = new System.Drawing.Size(500, 119);
            this.BTN_Title.TabIndex = 2;
            this.BTN_Title.UseVisualStyleBackColor = false;
            this.BTN_Title.Click += new System.EventHandler(this.BTN_Title_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::Orpheus.Properties.Resources.settings_title;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.FlatAppearance.BorderSize = 5;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(499, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(500, 117);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // FRM_SettingsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Orpheus.Properties.Resources.Orpheus_MainBCKGRND1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BTN_Title);
            this.Name = "FRM_SettingsPage";
            this.Text = "Orpheus - Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTN_Title;
        private System.Windows.Forms.Button button1;
    }
}