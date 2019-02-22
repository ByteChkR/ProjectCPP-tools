namespace MapEditor
{
    partial class PartCreator
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblLaneCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPartSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCompileStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.nudBiomeID = new System.Windows.Forms.NumericUpDown();
            this.lblBiomeID = new MetroFramework.Controls.MetroLabel();
            this.tbPartName = new System.Windows.Forms.TextBox();
            this.lblPartName = new MetroFramework.Controls.MetroLabel();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBiomeID)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(869, 206);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.RichTextBox1_TextChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblLaneCount,
            this.lblPartSize,
            this.lblCompileStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 208);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(869, 25);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblLaneCount
            // 
            this.lblLaneCount.Name = "lblLaneCount";
            this.lblLaneCount.Size = new System.Drawing.Size(79, 20);
            this.lblLaneCount.Text = "LaneCount";
            // 
            // lblPartSize
            // 
            this.lblPartSize.Name = "lblPartSize";
            this.lblPartSize.Size = new System.Drawing.Size(64, 20);
            this.lblPartSize.Text = "PartSize:";
            // 
            // lblCompileStatus
            // 
            this.lblCompileStatus.Name = "lblCompileStatus";
            this.lblCompileStatus.Size = new System.Drawing.Size(49, 20);
            this.lblCompileStatus.Text = "Status";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(737, 206);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 26);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // sfd
            // 
            this.sfd.DefaultExt = "pxml";
            this.sfd.FileName = "part";
            this.sfd.Filter = "XML Part File|*.pxml";
            this.sfd.Title = "Save Part XML File";
            // 
            // nudBiomeID
            // 
            this.nudBiomeID.Location = new System.Drawing.Point(667, 207);
            this.nudBiomeID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudBiomeID.Name = "nudBiomeID";
            this.nudBiomeID.Size = new System.Drawing.Size(63, 22);
            this.nudBiomeID.TabIndex = 3;
            this.nudBiomeID.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // lblBiomeID
            // 
            this.lblBiomeID.AutoSize = true;
            this.lblBiomeID.Location = new System.Drawing.Point(588, 210);
            this.lblBiomeID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBiomeID.Name = "lblBiomeID";
            this.lblBiomeID.Size = new System.Drawing.Size(68, 20);
            this.lblBiomeID.TabIndex = 4;
            this.lblBiomeID.Text = "Biome ID:";
            // 
            // tbPartName
            // 
            this.tbPartName.Location = new System.Drawing.Point(371, 208);
            this.tbPartName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbPartName.Name = "tbPartName";
            this.tbPartName.Size = new System.Drawing.Size(208, 22);
            this.tbPartName.TabIndex = 5;
            this.tbPartName.TextChanged += new System.EventHandler(this.tbPartName_TextChanged);
            // 
            // lblPartName
            // 
            this.lblPartName.AutoSize = true;
            this.lblPartName.Location = new System.Drawing.Point(312, 212);
            this.lblPartName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPartName.Name = "lblPartName";
            this.lblPartName.Size = new System.Drawing.Size(50, 20);
            this.lblPartName.TabIndex = 6;
            this.lblPartName.Text = "Name:";
            // 
            // PartCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(869, 233);
            this.Controls.Add(this.lblPartName);
            this.Controls.Add(this.tbPartName);
            this.Controls.Add(this.lblBiomeID);
            this.Controls.Add(this.nudBiomeID);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PartCreator";
            this.Text = "PartCreator";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBiomeID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblLaneCount;
        private System.Windows.Forms.ToolStripStatusLabel lblPartSize;
        private MetroFramework.Controls.MetroButton btnSave;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.ToolStripStatusLabel lblCompileStatus;
        private System.Windows.Forms.NumericUpDown nudBiomeID;
        private MetroFramework.Controls.MetroLabel lblBiomeID;
        private System.Windows.Forms.TextBox tbPartName;
        private MetroFramework.Controls.MetroLabel lblPartName;
    }
}