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
            this.btnSave = new System.Windows.Forms.Button();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.nudBiomeID = new System.Windows.Forms.NumericUpDown();
            this.lblBiomeID = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBiomeID)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(652, 189);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.RichTextBox1_TextChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblLaneCount,
            this.lblPartSize,
            this.lblCompileStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 167);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(652, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblLaneCount
            // 
            this.lblLaneCount.Name = "lblLaneCount";
            this.lblLaneCount.Size = new System.Drawing.Size(65, 17);
            this.lblLaneCount.Text = "LaneCount";
            // 
            // lblPartSize
            // 
            this.lblPartSize.Name = "lblPartSize";
            this.lblPartSize.Size = new System.Drawing.Size(51, 17);
            this.lblPartSize.Text = "PartSize:";
            // 
            // lblCompileStatus
            // 
            this.lblCompileStatus.Name = "lblCompileStatus";
            this.lblCompileStatus.Size = new System.Drawing.Size(39, 17);
            this.lblCompileStatus.Text = "Status";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(553, 167);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 21);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
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
            this.nudBiomeID.Location = new System.Drawing.Point(500, 168);
            this.nudBiomeID.Name = "nudBiomeID";
            this.nudBiomeID.Size = new System.Drawing.Size(47, 20);
            this.nudBiomeID.TabIndex = 3;
            this.nudBiomeID.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // lblBiomeID
            // 
            this.lblBiomeID.AutoSize = true;
            this.lblBiomeID.Location = new System.Drawing.Point(441, 171);
            this.lblBiomeID.Name = "lblBiomeID";
            this.lblBiomeID.Size = new System.Drawing.Size(53, 13);
            this.lblBiomeID.TabIndex = 4;
            this.lblBiomeID.Text = "Biome ID:";
            // 
            // PartCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 189);
            this.Controls.Add(this.lblBiomeID);
            this.Controls.Add(this.nudBiomeID);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
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
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.ToolStripStatusLabel lblCompileStatus;
        private System.Windows.Forms.NumericUpDown nudBiomeID;
        private System.Windows.Forms.Label lblBiomeID;
    }
}