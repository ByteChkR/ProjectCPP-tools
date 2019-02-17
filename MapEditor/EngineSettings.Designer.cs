namespace MapEditor
{
    partial class EngineSettings
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
            this.lblHm = new System.Windows.Forms.Label();
            this.cbHms = new System.Windows.Forms.ComboBox();
            this.btnAddHeightmap = new System.Windows.Forms.Button();
            this.cboxMapMode = new System.Windows.Forms.ComboBox();
            this.lblHorizonTex = new System.Windows.Forms.Label();
            this.cbHorizon = new System.Windows.Forms.ComboBox();
            this.btnAddHorizon = new System.Windows.Forms.Button();
            this.lblGroundTex = new System.Windows.Forms.Label();
            this.cbGround = new System.Windows.Forms.ComboBox();
            this.btnAddMapTex = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHm
            // 
            this.lblHm.AutoSize = true;
            this.lblHm.Location = new System.Drawing.Point(119, 17);
            this.lblHm.Name = "lblHm";
            this.lblHm.Size = new System.Drawing.Size(65, 13);
            this.lblHm.TabIndex = 30;
            this.lblHm.Text = "Height Map:";
            // 
            // cbHms
            // 
            this.cbHms.FormattingEnabled = true;
            this.cbHms.Location = new System.Drawing.Point(190, 14);
            this.cbHms.Name = "cbHms";
            this.cbHms.Size = new System.Drawing.Size(115, 21);
            this.cbHms.TabIndex = 29;
            this.cbHms.Text = "NONE";
            this.cbHms.SelectedIndexChanged += new System.EventHandler(this.cbHms_SelectedIndexChanged);
            // 
            // btnAddHeightmap
            // 
            this.btnAddHeightmap.Location = new System.Drawing.Point(12, 12);
            this.btnAddHeightmap.Name = "btnAddHeightmap";
            this.btnAddHeightmap.Size = new System.Drawing.Size(101, 23);
            this.btnAddHeightmap.TabIndex = 28;
            this.btnAddHeightmap.Text = "Add Heightmap";
            this.btnAddHeightmap.UseVisualStyleBackColor = true;
            // 
            // cboxMapMode
            // 
            this.cboxMapMode.FormattingEnabled = true;
            this.cboxMapMode.Items.AddRange(new object[] {
            "Raw",
            "Lua"});
            this.cboxMapMode.Location = new System.Drawing.Point(330, 14);
            this.cboxMapMode.Name = "cboxMapMode";
            this.cboxMapMode.Size = new System.Drawing.Size(50, 21);
            this.cboxMapMode.TabIndex = 27;
            this.cboxMapMode.Text = "Raw";
            this.cboxMapMode.SelectedIndexChanged += new System.EventHandler(this.cboxMapMode_SelectedIndexChanged);
            // 
            // lblHorizonTex
            // 
            this.lblHorizonTex.AutoSize = true;
            this.lblHorizonTex.Location = new System.Drawing.Point(140, 46);
            this.lblHorizonTex.Name = "lblHorizonTex";
            this.lblHorizonTex.Size = new System.Drawing.Size(85, 13);
            this.lblHorizonTex.TabIndex = 34;
            this.lblHorizonTex.Text = "Horizon Texture:";
            // 
            // cbHorizon
            // 
            this.cbHorizon.FormattingEnabled = true;
            this.cbHorizon.Location = new System.Drawing.Point(229, 43);
            this.cbHorizon.Name = "cbHorizon";
            this.cbHorizon.Size = new System.Drawing.Size(115, 21);
            this.cbHorizon.TabIndex = 33;
            this.cbHorizon.Text = "NONE";
            this.cbHorizon.SelectedIndexChanged += new System.EventHandler(this.cbHorizon_SelectedIndexChanged);
            // 
            // btnAddHorizon
            // 
            this.btnAddHorizon.Location = new System.Drawing.Point(12, 41);
            this.btnAddHorizon.Name = "btnAddHorizon";
            this.btnAddHorizon.Size = new System.Drawing.Size(122, 23);
            this.btnAddHorizon.TabIndex = 32;
            this.btnAddHorizon.Text = "Add Horizon Texture";
            this.btnAddHorizon.UseVisualStyleBackColor = true;
            // 
            // lblGroundTex
            // 
            this.lblGroundTex.AutoSize = true;
            this.lblGroundTex.Location = new System.Drawing.Point(139, 75);
            this.lblGroundTex.Name = "lblGroundTex";
            this.lblGroundTex.Size = new System.Drawing.Size(84, 13);
            this.lblGroundTex.TabIndex = 38;
            this.lblGroundTex.Text = "Ground Texture:";
            // 
            // cbGround
            // 
            this.cbGround.FormattingEnabled = true;
            this.cbGround.Location = new System.Drawing.Point(229, 72);
            this.cbGround.Name = "cbGround";
            this.cbGround.Size = new System.Drawing.Size(115, 21);
            this.cbGround.TabIndex = 37;
            this.cbGround.Text = "NONE";
            this.cbGround.SelectedIndexChanged += new System.EventHandler(this.cbGround_SelectedIndexChanged);
            // 
            // btnAddMapTex
            // 
            this.btnAddMapTex.Location = new System.Drawing.Point(12, 70);
            this.btnAddMapTex.Name = "btnAddMapTex";
            this.btnAddMapTex.Size = new System.Drawing.Size(122, 23);
            this.btnAddMapTex.TabIndex = 36;
            this.btnAddMapTex.Text = "Add Ground Texture";
            this.btnAddMapTex.UseVisualStyleBackColor = true;
            // 
            // EngineSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 106);
            this.Controls.Add(this.lblGroundTex);
            this.Controls.Add(this.cbGround);
            this.Controls.Add(this.btnAddMapTex);
            this.Controls.Add(this.lblHorizonTex);
            this.Controls.Add(this.cbHorizon);
            this.Controls.Add(this.btnAddHorizon);
            this.Controls.Add(this.lblHm);
            this.Controls.Add(this.cbHms);
            this.Controls.Add(this.btnAddHeightmap);
            this.Controls.Add(this.cboxMapMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EngineSettings";
            this.Text = "EngineSettings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EngineSettings_closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHm;
        private System.Windows.Forms.ComboBox cbHms;
        private System.Windows.Forms.Button btnAddHeightmap;
        private System.Windows.Forms.ComboBox cboxMapMode;
        private System.Windows.Forms.Label lblHorizonTex;
        private System.Windows.Forms.ComboBox cbHorizon;
        private System.Windows.Forms.Button btnAddHorizon;
        private System.Windows.Forms.Label lblGroundTex;
        private System.Windows.Forms.ComboBox cbGround;
        private System.Windows.Forms.Button btnAddMapTex;
    }
}