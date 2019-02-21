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
            this.lblGroundTex = new System.Windows.Forms.Label();
            this.cbGround = new System.Windows.Forms.ComboBox();
            this.lblGenerationOffset = new System.Windows.Forms.Label();
            this.nudGenOffset = new System.Windows.Forms.NumericUpDown();
            this.nudXCurvature = new System.Windows.Forms.NumericUpDown();
            this.lblxCurvature = new System.Windows.Forms.Label();
            this.nudXCurvatureSmoothness = new System.Windows.Forms.NumericUpDown();
            this.lblxCurvSmooth = new System.Windows.Forms.Label();
            this.nudHeightMapTiling = new System.Windows.Forms.NumericUpDown();
            this.lblHeightMapZTiling = new System.Windows.Forms.Label();
            this.nudHeightMapSpeed = new System.Windows.Forms.NumericUpDown();
            this.lblHeightMapSpeed = new System.Windows.Forms.Label();
            this.nudHeightMapMaxHeight = new System.Windows.Forms.NumericUpDown();
            this.lblHeightMapMaxHeight = new System.Windows.Forms.Label();
            this.nudHeightMapSamplingWidth = new System.Windows.Forms.NumericUpDown();
            this.lblHeightMapSamplingWidth = new System.Windows.Forms.Label();
            this.nudXMoveTiling = new System.Windows.Forms.NumericUpDown();
            this.lblxMoveTiling = new System.Windows.Forms.Label();
            this.gbMapSettings = new System.Windows.Forms.GroupBox();
            this.lblGroundNormal = new System.Windows.Forms.Label();
            this.cbGroundNormal = new System.Windows.Forms.ComboBox();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudGenOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXCurvature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXCurvatureSmoothness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeightMapTiling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeightMapSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeightMapMaxHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeightMapSamplingWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXMoveTiling)).BeginInit();
            this.gbMapSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHm
            // 
            this.lblHm.AutoSize = true;
            this.lblHm.Location = new System.Drawing.Point(6, 9);
            this.lblHm.Name = "lblHm";
            this.lblHm.Size = new System.Drawing.Size(65, 13);
            this.lblHm.TabIndex = 30;
            this.lblHm.Text = "Height Map:";
            // 
            // cbHms
            // 
            this.cbHms.FormattingEnabled = true;
            this.cbHms.Location = new System.Drawing.Point(132, 6);
            this.cbHms.Name = "cbHms";
            this.cbHms.Size = new System.Drawing.Size(153, 21);
            this.cbHms.TabIndex = 29;
            this.cbHms.Text = "NONE";
            this.cbHms.SelectedIndexChanged += new System.EventHandler(this.cbHms_SelectedIndexChanged);
            // 
            // btnAddHeightmap
            // 
            this.btnAddHeightmap.Location = new System.Drawing.Point(291, 85);
            this.btnAddHeightmap.Name = "btnAddHeightmap";
            this.btnAddHeightmap.Size = new System.Drawing.Size(102, 23);
            this.btnAddHeightmap.TabIndex = 28;
            this.btnAddHeightmap.Text = "Refresh Textures";
            this.btnAddHeightmap.UseVisualStyleBackColor = true;
            this.btnAddHeightmap.Click += new System.EventHandler(this.btnAddHeightmap_Click);
            // 
            // cboxMapMode
            // 
            this.cboxMapMode.FormattingEnabled = true;
            this.cboxMapMode.Items.AddRange(new object[] {
            "Raw",
            "Lua"});
            this.cboxMapMode.Location = new System.Drawing.Point(343, 6);
            this.cboxMapMode.Name = "cboxMapMode";
            this.cboxMapMode.Size = new System.Drawing.Size(50, 21);
            this.cboxMapMode.TabIndex = 27;
            this.cboxMapMode.Text = "Raw";
            this.cboxMapMode.SelectedIndexChanged += new System.EventHandler(this.cboxMapMode_SelectedIndexChanged);
            // 
            // lblHorizonTex
            // 
            this.lblHorizonTex.AutoSize = true;
            this.lblHorizonTex.Location = new System.Drawing.Point(7, 36);
            this.lblHorizonTex.Name = "lblHorizonTex";
            this.lblHorizonTex.Size = new System.Drawing.Size(85, 13);
            this.lblHorizonTex.TabIndex = 34;
            this.lblHorizonTex.Text = "Horizon Texture:";
            // 
            // cbHorizon
            // 
            this.cbHorizon.FormattingEnabled = true;
            this.cbHorizon.Location = new System.Drawing.Point(132, 33);
            this.cbHorizon.Name = "cbHorizon";
            this.cbHorizon.Size = new System.Drawing.Size(153, 21);
            this.cbHorizon.TabIndex = 33;
            this.cbHorizon.Text = "NONE";
            this.cbHorizon.SelectedIndexChanged += new System.EventHandler(this.cbHorizon_SelectedIndexChanged);
            // 
            // lblGroundTex
            // 
            this.lblGroundTex.AutoSize = true;
            this.lblGroundTex.Location = new System.Drawing.Point(6, 63);
            this.lblGroundTex.Name = "lblGroundTex";
            this.lblGroundTex.Size = new System.Drawing.Size(84, 13);
            this.lblGroundTex.TabIndex = 38;
            this.lblGroundTex.Text = "Ground Texture:";
            // 
            // cbGround
            // 
            this.cbGround.FormattingEnabled = true;
            this.cbGround.Location = new System.Drawing.Point(132, 60);
            this.cbGround.Name = "cbGround";
            this.cbGround.Size = new System.Drawing.Size(153, 21);
            this.cbGround.TabIndex = 37;
            this.cbGround.Text = "NONE";
            this.cbGround.SelectedIndexChanged += new System.EventHandler(this.cbGround_SelectedIndexChanged);
            // 
            // lblGenerationOffset
            // 
            this.lblGenerationOffset.AutoSize = true;
            this.lblGenerationOffset.Location = new System.Drawing.Point(4, 22);
            this.lblGenerationOffset.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGenerationOffset.Name = "lblGenerationOffset";
            this.lblGenerationOffset.Size = new System.Drawing.Size(129, 13);
            this.lblGenerationOffset.TabIndex = 39;
            this.lblGenerationOffset.Text = "GenerationOffset(Horizon)";
            // 
            // nudGenOffset
            // 
            this.nudGenOffset.DecimalPlaces = 1;
            this.nudGenOffset.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudGenOffset.Location = new System.Drawing.Point(284, 20);
            this.nudGenOffset.Margin = new System.Windows.Forms.Padding(2);
            this.nudGenOffset.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudGenOffset.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nudGenOffset.Name = "nudGenOffset";
            this.nudGenOffset.Size = new System.Drawing.Size(90, 20);
            this.nudGenOffset.TabIndex = 40;
            this.nudGenOffset.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
            this.nudGenOffset.ValueChanged += new System.EventHandler(this.nudGenOffset_ValueChanged);
            // 
            // nudXCurvature
            // 
            this.nudXCurvature.DecimalPlaces = 1;
            this.nudXCurvature.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudXCurvature.InterceptArrowKeys = false;
            this.nudXCurvature.Location = new System.Drawing.Point(284, 43);
            this.nudXCurvature.Margin = new System.Windows.Forms.Padding(2);
            this.nudXCurvature.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudXCurvature.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            -2147483648});
            this.nudXCurvature.Name = "nudXCurvature";
            this.nudXCurvature.Size = new System.Drawing.Size(90, 20);
            this.nudXCurvature.TabIndex = 42;
            this.nudXCurvature.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudXCurvature.ValueChanged += new System.EventHandler(this.nudXCurvature_ValueChanged);
            // 
            // lblxCurvature
            // 
            this.lblxCurvature.AutoSize = true;
            this.lblxCurvature.Location = new System.Drawing.Point(4, 45);
            this.lblxCurvature.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblxCurvature.Name = "lblxCurvature";
            this.lblxCurvature.Size = new System.Drawing.Size(149, 13);
            this.lblxCurvature.TabIndex = 41;
            this.lblxCurvature.Text = "xCurvature(x Offset at horizon)";
            // 
            // nudXCurvatureSmoothness
            // 
            this.nudXCurvatureSmoothness.DecimalPlaces = 1;
            this.nudXCurvatureSmoothness.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudXCurvatureSmoothness.Location = new System.Drawing.Point(284, 66);
            this.nudXCurvatureSmoothness.Margin = new System.Windows.Forms.Padding(2);
            this.nudXCurvatureSmoothness.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudXCurvatureSmoothness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudXCurvatureSmoothness.Name = "nudXCurvatureSmoothness";
            this.nudXCurvatureSmoothness.Size = new System.Drawing.Size(90, 20);
            this.nudXCurvatureSmoothness.TabIndex = 44;
            this.nudXCurvatureSmoothness.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudXCurvatureSmoothness.ValueChanged += new System.EventHandler(this.nudXCurvatureSmoothness_ValueChanged);
            // 
            // lblxCurvSmooth
            // 
            this.lblxCurvSmooth.AutoSize = true;
            this.lblxCurvSmooth.Location = new System.Drawing.Point(4, 67);
            this.lblxCurvSmooth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblxCurvSmooth.Name = "lblxCurvSmooth";
            this.lblxCurvSmooth.Size = new System.Drawing.Size(228, 13);
            this.lblxCurvSmooth.TabIndex = 43;
            this.lblxCurvSmooth.Text = "xCurvatureSmoothness(1= straight, 2 = curved)";
            // 
            // nudHeightMapTiling
            // 
            this.nudHeightMapTiling.DecimalPlaces = 1;
            this.nudHeightMapTiling.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudHeightMapTiling.Location = new System.Drawing.Point(284, 89);
            this.nudHeightMapTiling.Margin = new System.Windows.Forms.Padding(2);
            this.nudHeightMapTiling.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudHeightMapTiling.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudHeightMapTiling.Name = "nudHeightMapTiling";
            this.nudHeightMapTiling.Size = new System.Drawing.Size(90, 20);
            this.nudHeightMapTiling.TabIndex = 46;
            this.nudHeightMapTiling.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHeightMapTiling.ValueChanged += new System.EventHandler(this.nudHeightMapTiling_ValueChanged);
            // 
            // lblHeightMapZTiling
            // 
            this.lblHeightMapZTiling.AutoSize = true;
            this.lblHeightMapZTiling.Location = new System.Drawing.Point(4, 90);
            this.lblHeightMapZTiling.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeightMapZTiling.Name = "lblHeightMapZTiling";
            this.lblHeightMapZTiling.Size = new System.Drawing.Size(265, 13);
            this.lblHeightMapZTiling.TabIndex = 45;
            this.lblHeightMapZTiling.Text = "HeightMapTiling(1 = original, 2 = higher texture density)";
            // 
            // nudHeightMapSpeed
            // 
            this.nudHeightMapSpeed.DecimalPlaces = 1;
            this.nudHeightMapSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudHeightMapSpeed.Location = new System.Drawing.Point(284, 111);
            this.nudHeightMapSpeed.Margin = new System.Windows.Forms.Padding(2);
            this.nudHeightMapSpeed.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudHeightMapSpeed.Name = "nudHeightMapSpeed";
            this.nudHeightMapSpeed.Size = new System.Drawing.Size(90, 20);
            this.nudHeightMapSpeed.TabIndex = 48;
            this.nudHeightMapSpeed.ValueChanged += new System.EventHandler(this.nudHeightMapSpeed_ValueChanged);
            // 
            // lblHeightMapSpeed
            // 
            this.lblHeightMapSpeed.AutoSize = true;
            this.lblHeightMapSpeed.Location = new System.Drawing.Point(4, 113);
            this.lblHeightMapSpeed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeightMapSpeed.Name = "lblHeightMapSpeed";
            this.lblHeightMapSpeed.Size = new System.Drawing.Size(203, 13);
            this.lblHeightMapSpeed.TabIndex = 47;
            this.lblHeightMapSpeed.Text = "HeightMapSpeed(Movement Per second)";
            // 
            // nudHeightMapMaxHeight
            // 
            this.nudHeightMapMaxHeight.DecimalPlaces = 1;
            this.nudHeightMapMaxHeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudHeightMapMaxHeight.Location = new System.Drawing.Point(284, 134);
            this.nudHeightMapMaxHeight.Margin = new System.Windows.Forms.Padding(2);
            this.nudHeightMapMaxHeight.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudHeightMapMaxHeight.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.nudHeightMapMaxHeight.Name = "nudHeightMapMaxHeight";
            this.nudHeightMapMaxHeight.Size = new System.Drawing.Size(90, 20);
            this.nudHeightMapMaxHeight.TabIndex = 50;
            this.nudHeightMapMaxHeight.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudHeightMapMaxHeight.ValueChanged += new System.EventHandler(this.nudHeightMapMaxHeight_ValueChanged);
            // 
            // lblHeightMapMaxHeight
            // 
            this.lblHeightMapMaxHeight.AutoSize = true;
            this.lblHeightMapMaxHeight.Location = new System.Drawing.Point(4, 136);
            this.lblHeightMapMaxHeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeightMapMaxHeight.Name = "lblHeightMapMaxHeight";
            this.lblHeightMapMaxHeight.Size = new System.Drawing.Size(110, 13);
            this.lblHeightMapMaxHeight.TabIndex = 49;
            this.lblHeightMapMaxHeight.Text = "HeightMapMaxHeight";
            // 
            // nudHeightMapSamplingWidth
            // 
            this.nudHeightMapSamplingWidth.DecimalPlaces = 1;
            this.nudHeightMapSamplingWidth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudHeightMapSamplingWidth.Location = new System.Drawing.Point(284, 157);
            this.nudHeightMapSamplingWidth.Margin = new System.Windows.Forms.Padding(2);
            this.nudHeightMapSamplingWidth.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudHeightMapSamplingWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudHeightMapSamplingWidth.Name = "nudHeightMapSamplingWidth";
            this.nudHeightMapSamplingWidth.Size = new System.Drawing.Size(90, 20);
            this.nudHeightMapSamplingWidth.TabIndex = 52;
            this.nudHeightMapSamplingWidth.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudHeightMapSamplingWidth.ValueChanged += new System.EventHandler(this.nudHeightMapSamplingWidth_ValueChanged);
            // 
            // lblHeightMapSamplingWidth
            // 
            this.lblHeightMapSamplingWidth.AutoSize = true;
            this.lblHeightMapSamplingWidth.Location = new System.Drawing.Point(4, 158);
            this.lblHeightMapSamplingWidth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeightMapSamplingWidth.Name = "lblHeightMapSamplingWidth";
            this.lblHeightMapSamplingWidth.Size = new System.Drawing.Size(130, 13);
            this.lblHeightMapSamplingWidth.TabIndex = 51;
            this.lblHeightMapSamplingWidth.Text = "HeightMapSamplingWidth";
            // 
            // nudXMoveTiling
            // 
            this.nudXMoveTiling.DecimalPlaces = 1;
            this.nudXMoveTiling.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudXMoveTiling.Location = new System.Drawing.Point(284, 180);
            this.nudXMoveTiling.Margin = new System.Windows.Forms.Padding(2);
            this.nudXMoveTiling.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudXMoveTiling.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudXMoveTiling.Name = "nudXMoveTiling";
            this.nudXMoveTiling.Size = new System.Drawing.Size(90, 20);
            this.nudXMoveTiling.TabIndex = 54;
            this.nudXMoveTiling.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudXMoveTiling.ValueChanged += new System.EventHandler(this.nudXMoveTiling_ValueChanged);
            // 
            // lblxMoveTiling
            // 
            this.lblxMoveTiling.AutoSize = true;
            this.lblxMoveTiling.Location = new System.Drawing.Point(4, 181);
            this.lblxMoveTiling.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblxMoveTiling.Name = "lblxMoveTiling";
            this.lblxMoveTiling.Size = new System.Drawing.Size(64, 13);
            this.lblxMoveTiling.TabIndex = 53;
            this.lblxMoveTiling.Text = "xMoveTiling";
            // 
            // gbMapSettings
            // 
            this.gbMapSettings.Controls.Add(this.nudXMoveTiling);
            this.gbMapSettings.Controls.Add(this.lblGenerationOffset);
            this.gbMapSettings.Controls.Add(this.lblxMoveTiling);
            this.gbMapSettings.Controls.Add(this.nudGenOffset);
            this.gbMapSettings.Controls.Add(this.nudHeightMapSamplingWidth);
            this.gbMapSettings.Controls.Add(this.lblxCurvature);
            this.gbMapSettings.Controls.Add(this.lblHeightMapSamplingWidth);
            this.gbMapSettings.Controls.Add(this.nudXCurvature);
            this.gbMapSettings.Controls.Add(this.nudHeightMapMaxHeight);
            this.gbMapSettings.Controls.Add(this.lblxCurvSmooth);
            this.gbMapSettings.Controls.Add(this.lblHeightMapMaxHeight);
            this.gbMapSettings.Controls.Add(this.nudXCurvatureSmoothness);
            this.gbMapSettings.Controls.Add(this.nudHeightMapSpeed);
            this.gbMapSettings.Controls.Add(this.lblHeightMapZTiling);
            this.gbMapSettings.Controls.Add(this.lblHeightMapSpeed);
            this.gbMapSettings.Controls.Add(this.nudHeightMapTiling);
            this.gbMapSettings.Location = new System.Drawing.Point(9, 113);
            this.gbMapSettings.Margin = new System.Windows.Forms.Padding(2);
            this.gbMapSettings.Name = "gbMapSettings";
            this.gbMapSettings.Padding = new System.Windows.Forms.Padding(2);
            this.gbMapSettings.Size = new System.Drawing.Size(376, 201);
            this.gbMapSettings.TabIndex = 55;
            this.gbMapSettings.TabStop = false;
            this.gbMapSettings.Text = "Map Settings";
            // 
            // lblGroundNormal
            // 
            this.lblGroundNormal.AutoSize = true;
            this.lblGroundNormal.Location = new System.Drawing.Point(6, 90);
            this.lblGroundNormal.Name = "lblGroundNormal";
            this.lblGroundNormal.Size = new System.Drawing.Size(120, 13);
            this.lblGroundNormal.TabIndex = 57;
            this.lblGroundNormal.Text = "Ground Normal Texture:";
            // 
            // cbGroundNormal
            // 
            this.cbGroundNormal.FormattingEnabled = true;
            this.cbGroundNormal.Location = new System.Drawing.Point(132, 87);
            this.cbGroundNormal.Name = "cbGroundNormal";
            this.cbGroundNormal.Size = new System.Drawing.Size(153, 21);
            this.cbGroundNormal.TabIndex = 56;
            this.cbGroundNormal.Text = "NONE";
            this.cbGroundNormal.SelectedIndexChanged += new System.EventHandler(this.cbGroundNormal_SelectedIndexChanged);
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(291, 60);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(102, 23);
            this.btnOpenFolder.TabIndex = 58;
            this.btnOpenFolder.Text = "Open Folder";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.button1_Click);
            // 
            // EngineSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 325);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.lblGroundNormal);
            this.Controls.Add(this.cbGroundNormal);
            this.Controls.Add(this.lblGroundTex);
            this.Controls.Add(this.cbGround);
            this.Controls.Add(this.lblHorizonTex);
            this.Controls.Add(this.cbHorizon);
            this.Controls.Add(this.lblHm);
            this.Controls.Add(this.cbHms);
            this.Controls.Add(this.btnAddHeightmap);
            this.Controls.Add(this.cboxMapMode);
            this.Controls.Add(this.gbMapSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EngineSettings";
            this.Text = "EngineSettings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EngineSettings_closing);
            ((System.ComponentModel.ISupportInitialize)(this.nudGenOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXCurvature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXCurvatureSmoothness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeightMapTiling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeightMapSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeightMapMaxHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeightMapSamplingWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudXMoveTiling)).EndInit();
            this.gbMapSettings.ResumeLayout(false);
            this.gbMapSettings.PerformLayout();
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
        private System.Windows.Forms.Label lblGroundTex;
        private System.Windows.Forms.ComboBox cbGround;
        private System.Windows.Forms.Label lblGenerationOffset;
        private System.Windows.Forms.NumericUpDown nudGenOffset;
        private System.Windows.Forms.NumericUpDown nudXCurvature;
        private System.Windows.Forms.Label lblxCurvature;
        private System.Windows.Forms.NumericUpDown nudXCurvatureSmoothness;
        private System.Windows.Forms.Label lblxCurvSmooth;
        private System.Windows.Forms.NumericUpDown nudHeightMapTiling;
        private System.Windows.Forms.Label lblHeightMapZTiling;
        private System.Windows.Forms.NumericUpDown nudHeightMapSpeed;
        private System.Windows.Forms.Label lblHeightMapSpeed;
        private System.Windows.Forms.NumericUpDown nudHeightMapMaxHeight;
        private System.Windows.Forms.Label lblHeightMapMaxHeight;
        private System.Windows.Forms.NumericUpDown nudHeightMapSamplingWidth;
        private System.Windows.Forms.Label lblHeightMapSamplingWidth;
        private System.Windows.Forms.NumericUpDown nudXMoveTiling;
        private System.Windows.Forms.Label lblxMoveTiling;
        private System.Windows.Forms.GroupBox gbMapSettings;
        private System.Windows.Forms.Label lblGroundNormal;
        private System.Windows.Forms.ComboBox cbGroundNormal;
        private System.Windows.Forms.Button btnOpenFolder;
    }
}