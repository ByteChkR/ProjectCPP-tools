namespace TurkeyLauncher
{
    partial class frmLauncher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLauncher));
            this.pbBanner = new System.Windows.Forms.PictureBox();
            this.cbWindowed = new System.Windows.Forms.CheckBox();
            this.cobResolutions = new System.Windows.Forms.ComboBox();
            this.lblRes = new System.Windows.Forms.Label();
            this.btnStoryMode = new System.Windows.Forms.Button();
            this.btnPlaygroundMode = new System.Windows.Forms.Button();
            this.cbShowConsole = new System.Windows.Forms.CheckBox();
            this.cobMaplist = new System.Windows.Forms.ComboBox();
            this.ofdLoadMaplist = new System.Windows.Forms.OpenFileDialog();
            this.cobMSAASamples = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbVSync = new System.Windows.Forms.CheckBox();
            this.cbeditorMode = new System.Windows.Forms.CheckBox();
            this.cbCheats = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBanner
            // 
            this.pbBanner.Location = new System.Drawing.Point(16, 15);
            this.pbBanner.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pbBanner.Name = "pbBanner";
            this.pbBanner.Size = new System.Drawing.Size(471, 148);
            this.pbBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBanner.TabIndex = 0;
            this.pbBanner.TabStop = false;
            // 
            // cbWindowed
            // 
            this.cbWindowed.AutoSize = true;
            this.cbWindowed.Location = new System.Drawing.Point(360, 181);
            this.cbWindowed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbWindowed.Name = "cbWindowed";
            this.cbWindowed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbWindowed.Size = new System.Drawing.Size(118, 21);
            this.cbWindowed.TabIndex = 1;
            this.cbWindowed.Text = "Window Mode";
            this.cbWindowed.UseVisualStyleBackColor = true;
            // 
            // cobResolutions
            // 
            this.cobResolutions.FormattingEnabled = true;
            this.cobResolutions.Location = new System.Drawing.Point(100, 178);
            this.cobResolutions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cobResolutions.Name = "cobResolutions";
            this.cobResolutions.Size = new System.Drawing.Size(160, 24);
            this.cobResolutions.TabIndex = 2;
            this.cobResolutions.SelectedIndexChanged += new System.EventHandler(this.cobResolutions_SelectedIndexChanged);
            // 
            // lblRes
            // 
            this.lblRes.AutoSize = true;
            this.lblRes.Location = new System.Drawing.Point(16, 182);
            this.lblRes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRes.Name = "lblRes";
            this.lblRes.Size = new System.Drawing.Size(79, 17);
            this.lblRes.TabIndex = 3;
            this.lblRes.Text = "Resolution:";
            // 
            // btnStoryMode
            // 
            this.btnStoryMode.Location = new System.Drawing.Point(16, 273);
            this.btnStoryMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStoryMode.Name = "btnStoryMode";
            this.btnStoryMode.Size = new System.Drawing.Size(220, 63);
            this.btnStoryMode.TabIndex = 4;
            this.btnStoryMode.Text = "Play";
            this.btnStoryMode.UseVisualStyleBackColor = true;
            this.btnStoryMode.Click += new System.EventHandler(this.btnStoryMode_Click);
            // 
            // btnPlaygroundMode
            // 
            this.btnPlaygroundMode.Location = new System.Drawing.Point(271, 306);
            this.btnPlaygroundMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPlaygroundMode.Name = "btnPlaygroundMode";
            this.btnPlaygroundMode.Size = new System.Drawing.Size(216, 30);
            this.btnPlaygroundMode.TabIndex = 5;
            this.btnPlaygroundMode.Text = "Start Custom Map List";
            this.btnPlaygroundMode.UseVisualStyleBackColor = true;
            this.btnPlaygroundMode.Click += new System.EventHandler(this.btnPlaygroundMode_Click);
            // 
            // cbShowConsole
            // 
            this.cbShowConsole.AutoSize = true;
            this.cbShowConsole.Location = new System.Drawing.Point(361, 209);
            this.cbShowConsole.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbShowConsole.Name = "cbShowConsole";
            this.cbShowConsole.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbShowConsole.Size = new System.Drawing.Size(119, 21);
            this.cbShowConsole.TabIndex = 6;
            this.cbShowConsole.Text = "Show Console";
            this.cbShowConsole.UseVisualStyleBackColor = true;
            this.cbShowConsole.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cobMaplist
            // 
            this.cobMaplist.FormattingEnabled = true;
            this.cobMaplist.Location = new System.Drawing.Point(271, 273);
            this.cobMaplist.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cobMaplist.Name = "cobMaplist";
            this.cobMaplist.Size = new System.Drawing.Size(215, 24);
            this.cobMaplist.TabIndex = 7;
            this.cobMaplist.Text = "Load From File";
            this.cobMaplist.SelectedIndexChanged += new System.EventHandler(this.cobMaplist_SelectedIndexChanged);
            // 
            // ofdLoadMaplist
            // 
            this.ofdLoadMaplist.DefaultExt = "lua";
            this.ofdLoadMaplist.FileName = "maplist.lua";
            this.ofdLoadMaplist.Filter = "LUA MapList|*.lua";
            this.ofdLoadMaplist.Title = "Load Maplist";
            // 
            // cobMSAASamples
            // 
            this.cobMSAASamples.FormattingEnabled = true;
            this.cobMSAASamples.Items.AddRange(new object[] {
            "OFF",
            "x2",
            "x4",
            "x8"});
            this.cobMSAASamples.Location = new System.Drawing.Point(100, 212);
            this.cobMSAASamples.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cobMSAASamples.Name = "cobMSAASamples";
            this.cobMSAASamples.Size = new System.Drawing.Size(80, 24);
            this.cobMSAASamples.TabIndex = 8;
            this.cobMSAASamples.Text = "OFF";
            this.cobMSAASamples.SelectedIndexChanged += new System.EventHandler(this.cobMSAASamples_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 215);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Antialiasing:";
            // 
            // cbVSync
            // 
            this.cbVSync.AutoSize = true;
            this.cbVSync.Location = new System.Drawing.Point(20, 245);
            this.cbVSync.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbVSync.Name = "cbVSync";
            this.cbVSync.Size = new System.Drawing.Size(160, 21);
            this.cbVSync.TabIndex = 10;
            this.cbVSync.Text = "Enable Vertical Sync";
            this.cbVSync.UseVisualStyleBackColor = true;
            // 
            // cbeditorMode
            // 
            this.cbeditorMode.AutoSize = true;
            this.cbeditorMode.Location = new System.Drawing.Point(380, 238);
            this.cbeditorMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbeditorMode.Name = "cbeditorMode";
            this.cbeditorMode.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbeditorMode.Size = new System.Drawing.Size(102, 21);
            this.cbeditorMode.TabIndex = 11;
            this.cbeditorMode.Text = "EditorMode";
            this.cbeditorMode.UseVisualStyleBackColor = true;
            // 
            // cbCheats
            // 
            this.cbCheats.AutoSize = true;
            this.cbCheats.Location = new System.Drawing.Point(265, 238);
            this.cbCheats.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbCheats.Name = "cbCheats";
            this.cbCheats.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbCheats.Size = new System.Drawing.Size(58, 21);
            this.cbCheats.TabIndex = 12;
            this.cbCheats.Text = "HAX";
            this.cbCheats.UseVisualStyleBackColor = true;
            // 
            // frmLauncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 342);
            this.Controls.Add(this.cbCheats);
            this.Controls.Add(this.cbeditorMode);
            this.Controls.Add(this.cbVSync);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cobMSAASamples);
            this.Controls.Add(this.cobMaplist);
            this.Controls.Add(this.cbShowConsole);
            this.Controls.Add(this.btnPlaygroundMode);
            this.Controls.Add(this.btnStoryMode);
            this.Controls.Add(this.lblRes);
            this.Controls.Add(this.cobResolutions);
            this.Controls.Add(this.cbWindowed);
            this.Controls.Add(this.pbBanner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLauncher";
            this.Text = "Turkey Game Launcher";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLauncher_Close);
            this.Load += new System.EventHandler(this.frmLauncher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbBanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbBanner;
        private System.Windows.Forms.CheckBox cbWindowed;
        private System.Windows.Forms.ComboBox cobResolutions;
        private System.Windows.Forms.Label lblRes;
        private System.Windows.Forms.Button btnStoryMode;
        private System.Windows.Forms.Button btnPlaygroundMode;
        private System.Windows.Forms.CheckBox cbShowConsole;
        private System.Windows.Forms.ComboBox cobMaplist;
        private System.Windows.Forms.OpenFileDialog ofdLoadMaplist;
        private System.Windows.Forms.ComboBox cobMSAASamples;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbVSync;
        private System.Windows.Forms.CheckBox cbeditorMode;
        private System.Windows.Forms.CheckBox cbCheats;
    }
}

