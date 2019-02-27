namespace MapEditor
{
    partial class NewMapDialog
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
            this.tbMapName = new System.Windows.Forms.TextBox();
            this.lblMapName = new System.Windows.Forms.Label();
            this.nudPartSize = new System.Windows.Forms.NumericUpDown();
            this.lblPartSize = new System.Windows.Forms.Label();
            this.lblLaneCount = new System.Windows.Forms.Label();
            this.nudLaneCount = new System.Windows.Forms.NumericUpDown();
            this.lbAvailableScripts = new System.Windows.Forms.ListBox();
            this.btnCreate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudPartSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLaneCount)).BeginInit();
            this.SuspendLayout();
            // 
            // tbMapName
            // 
            this.tbMapName.Location = new System.Drawing.Point(107, 15);
            this.tbMapName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbMapName.Name = "tbMapName";
            this.tbMapName.Size = new System.Drawing.Size(255, 22);
            this.tbMapName.TabIndex = 0;
            this.tbMapName.TextChanged += new System.EventHandler(this.tbMapName_TextChanged);
            // 
            // lblMapName
            // 
            this.lblMapName.AutoSize = true;
            this.lblMapName.Location = new System.Drawing.Point(16, 18);
            this.lblMapName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMapName.Name = "lblMapName";
            this.lblMapName.Size = new System.Drawing.Size(45, 17);
            this.lblMapName.TabIndex = 1;
            this.lblMapName.Text = "Name";
            // 
            // nudPartSize
            // 
            this.nudPartSize.Location = new System.Drawing.Point(107, 47);
            this.nudPartSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudPartSize.Name = "nudPartSize";
            this.nudPartSize.Size = new System.Drawing.Size(256, 22);
            this.nudPartSize.TabIndex = 2;
            this.nudPartSize.ValueChanged += new System.EventHandler(this.nudPartSize_ValueChanged);
            // 
            // lblPartSize
            // 
            this.lblPartSize.AutoSize = true;
            this.lblPartSize.Location = new System.Drawing.Point(16, 49);
            this.lblPartSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPartSize.Name = "lblPartSize";
            this.lblPartSize.Size = new System.Drawing.Size(65, 17);
            this.lblPartSize.TabIndex = 3;
            this.lblPartSize.Text = "Part Size";
            // 
            // lblLaneCount
            // 
            this.lblLaneCount.AutoSize = true;
            this.lblLaneCount.Location = new System.Drawing.Point(16, 81);
            this.lblLaneCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLaneCount.Name = "lblLaneCount";
            this.lblLaneCount.Size = new System.Drawing.Size(81, 17);
            this.lblLaneCount.TabIndex = 4;
            this.lblLaneCount.Text = "Lane Count";
            // 
            // nudLaneCount
            // 
            this.nudLaneCount.Location = new System.Drawing.Point(107, 79);
            this.nudLaneCount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudLaneCount.Name = "nudLaneCount";
            this.nudLaneCount.Size = new System.Drawing.Size(256, 22);
            this.nudLaneCount.TabIndex = 5;
            this.nudLaneCount.ValueChanged += new System.EventHandler(this.nudLaneCount_ValueChanged);
            // 
            // lbAvailableScripts
            // 
            this.lbAvailableScripts.FormattingEnabled = true;
            this.lbAvailableScripts.ItemHeight = 16;
            this.lbAvailableScripts.Location = new System.Drawing.Point(16, 130);
            this.lbAvailableScripts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbAvailableScripts.Name = "lbAvailableScripts";
            this.lbAvailableScripts.Size = new System.Drawing.Size(345, 180);
            this.lbAvailableScripts.TabIndex = 6;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(16, 320);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(347, 28);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "Create";
           // this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // NewMapDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(379, 359);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lbAvailableScripts);
            this.Controls.Add(this.nudLaneCount);
            this.Controls.Add(this.lblLaneCount);
            this.Controls.Add(this.lblPartSize);
            this.Controls.Add(this.nudPartSize);
            this.Controls.Add(this.lblMapName);
            this.Controls.Add(this.tbMapName);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "NewMapDialog";
            this.Text = "Create a new Map";
            ((System.ComponentModel.ISupportInitialize)(this.nudPartSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLaneCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMapName;
        private System.Windows.Forms.Label lblMapName;
        private System.Windows.Forms.NumericUpDown nudPartSize;
        private System.Windows.Forms.Label lblPartSize;
        private System.Windows.Forms.Label lblLaneCount;
        private System.Windows.Forms.NumericUpDown nudLaneCount;
        private System.Windows.Forms.ListBox lbAvailableScripts;
        private System.Windows.Forms.Button btnCreate;
    }
}