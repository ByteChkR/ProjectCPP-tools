namespace MapEditor
{
    partial class frmEditor
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
            this.lblLaneCount = new System.Windows.Forms.Label();
            this.btnEditLaneStep = new System.Windows.Forms.Button();
            this.lblMapParts = new System.Windows.Forms.Label();
            this.lbMapParts = new System.Windows.Forms.ListBox();
            this.lbParts = new System.Windows.Forms.ListBox();
            this.lblPartsAvaliable = new System.Windows.Forms.Label();
            this.btnOpenPartFile = new System.Windows.Forms.Button();
            this.btnRemoveFromMap = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ofdPart = new System.Windows.Forms.OpenFileDialog();
            this.btneditPart = new System.Windows.Forms.Button();
            this.btnCreatePart = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.sfdExport = new System.Windows.Forms.SaveFileDialog();
            this.btnLoadMap = new System.Windows.Forms.Button();
            this.ofdMap = new System.Windows.Forms.OpenFileDialog();
            this.btnNewMap = new System.Windows.Forms.Button();
            this.grpBoxParts = new System.Windows.Forms.GroupBox();
            this.grpBoxMap = new System.Windows.Forms.GroupBox();
            this.btnStartFromSelection = new System.Windows.Forms.Button();
            this.cbRandomizeParts = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.ofdEngine = new System.Windows.Forms.OpenFileDialog();
            this.grpBoxParts.SuspendLayout();
            this.grpBoxMap.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLaneCount
            // 
            this.lblLaneCount.AutoSize = true;
            this.lblLaneCount.Location = new System.Drawing.Point(330, 25);
            this.lblLaneCount.Name = "lblLaneCount";
            this.lblLaneCount.Size = new System.Drawing.Size(76, 13);
            this.lblLaneCount.TabIndex = 2;
            this.lblLaneCount.Text = "Lane Spacing:";
            // 
            // btnEditLaneStep
            // 
            this.btnEditLaneStep.Location = new System.Drawing.Point(412, 21);
            this.btnEditLaneStep.Name = "btnEditLaneStep";
            this.btnEditLaneStep.Size = new System.Drawing.Size(50, 20);
            this.btnEditLaneStep.TabIndex = 4;
            this.btnEditLaneStep.Text = "edit";
            this.btnEditLaneStep.UseVisualStyleBackColor = true;
            this.btnEditLaneStep.Click += new System.EventHandler(this.BtnEditLaneStep_Click);
            // 
            // lblMapParts
            // 
            this.lblMapParts.AutoSize = true;
            this.lblMapParts.Location = new System.Drawing.Point(10, 56);
            this.lblMapParts.Name = "lblMapParts";
            this.lblMapParts.Size = new System.Drawing.Size(71, 13);
            this.lblMapParts.TabIndex = 6;
            this.lblMapParts.Text = "Parts(in map):";
            // 
            // lbMapParts
            // 
            this.lbMapParts.FormattingEnabled = true;
            this.lbMapParts.Location = new System.Drawing.Point(12, 85);
            this.lbMapParts.Name = "lbMapParts";
            this.lbMapParts.Size = new System.Drawing.Size(450, 394);
            this.lbMapParts.TabIndex = 7;
           // 
            // lbParts
            // 
            this.lbParts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbParts.FormattingEnabled = true;
            this.lbParts.Location = new System.Drawing.Point(21, 72);
            this.lbParts.Name = "lbParts";
            this.lbParts.Size = new System.Drawing.Size(333, 433);
            this.lbParts.TabIndex = 8;
            this.lbParts.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.PartsDrawItems);
            // 
            // lblPartsAvaliable
            // 
            this.lblPartsAvaliable.AutoSize = true;
            this.lblPartsAvaliable.Location = new System.Drawing.Point(18, 56);
            this.lblPartsAvaliable.Name = "lblPartsAvaliable";
            this.lblPartsAvaliable.Size = new System.Drawing.Size(80, 13);
            this.lblPartsAvaliable.TabIndex = 9;
            this.lblPartsAvaliable.Text = "Parts Avaliable:";
            // 
            // btnOpenPartFile
            // 
            this.btnOpenPartFile.Location = new System.Drawing.Point(133, 19);
            this.btnOpenPartFile.Name = "btnOpenPartFile";
            this.btnOpenPartFile.Size = new System.Drawing.Size(106, 24);
            this.btnOpenPartFile.TabIndex = 10;
            this.btnOpenPartFile.Text = "Open Part";
            this.btnOpenPartFile.UseVisualStyleBackColor = true;
            this.btnOpenPartFile.Click += new System.EventHandler(this.BtnOpenPartFile_Click);
            // 
            // btnRemoveFromMap
            // 
            this.btnRemoveFromMap.Location = new System.Drawing.Point(87, 56);
            this.btnRemoveFromMap.Name = "btnRemoveFromMap";
            this.btnRemoveFromMap.Size = new System.Drawing.Size(31, 24);
            this.btnRemoveFromMap.TabIndex = 12;
            this.btnRemoveFromMap.Text = "X";
            this.btnRemoveFromMap.UseVisualStyleBackColor = true;
            this.btnRemoveFromMap.Click += new System.EventHandler(this.BtnRemoveFromMap_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(495, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 24);
            this.button1.TabIndex = 13;
            this.button1.Text = "<<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ofdPart
            // 
            this.ofdPart.DefaultExt = "pxml";
            this.ofdPart.FileName = "part";
            this.ofdPart.Filter = "XML Part File|*.pxml";
            this.ofdPart.Multiselect = true;
            this.ofdPart.Title = "Open XML Part File";
            // 
            // btneditPart
            // 
            this.btneditPart.Location = new System.Drawing.Point(245, 19);
            this.btneditPart.Name = "btneditPart";
            this.btneditPart.Size = new System.Drawing.Size(109, 24);
            this.btneditPart.TabIndex = 14;
            this.btneditPart.Text = "Edit Part";
            this.btneditPart.UseVisualStyleBackColor = true;
            this.btneditPart.Click += new System.EventHandler(this.BtneditPart_Click);
            // 
            // btnCreatePart
            // 
            this.btnCreatePart.Location = new System.Drawing.Point(21, 19);
            this.btnCreatePart.Name = "btnCreatePart";
            this.btnCreatePart.Size = new System.Drawing.Size(106, 24);
            this.btnCreatePart.TabIndex = 11;
            this.btnCreatePart.Text = "Create Part";
            this.btnCreatePart.UseVisualStyleBackColor = true;
            this.btnCreatePart.Click += new System.EventHandler(this.BtnCreatePart_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(249, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 24);
            this.button2.TabIndex = 15;
            this.button2.Text = "Export Map";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(168, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 24);
            this.button3.TabIndex = 16;
            this.button3.Text = "Save Map";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // sfd
            // 
            this.sfd.DefaultExt = "mxml";
            this.sfd.FileName = "map";
            this.sfd.Filter = "XML Map File|*.mxml";
            this.sfd.Title = "Save Map as XML";
            // 
            // sfdExport
            // 
            this.sfdExport.DefaultExt = "txt";
            this.sfdExport.FileName = "map";
            this.sfdExport.Filter = "EngineMap|*.txt";
            this.sfdExport.Title = "Save Map as Engine Map";
            // 
            // btnLoadMap
            // 
            this.btnLoadMap.Location = new System.Drawing.Point(87, 19);
            this.btnLoadMap.Name = "btnLoadMap";
            this.btnLoadMap.Size = new System.Drawing.Size(75, 24);
            this.btnLoadMap.TabIndex = 17;
            this.btnLoadMap.Text = "Load Map";
            this.btnLoadMap.UseVisualStyleBackColor = true;
            this.btnLoadMap.Click += new System.EventHandler(this.btnLoadMap_Click);
            // 
            // ofdMap
            // 
            this.ofdMap.DefaultExt = "mxml";
            this.ofdMap.FileName = "map";
            this.ofdMap.Filter = "XML Map File|*.mxml";
            this.ofdMap.Title = "Open XML Map File";
            // 
            // btnNewMap
            // 
            this.btnNewMap.Location = new System.Drawing.Point(6, 19);
            this.btnNewMap.Name = "btnNewMap";
            this.btnNewMap.Size = new System.Drawing.Size(75, 24);
            this.btnNewMap.TabIndex = 18;
            this.btnNewMap.Text = "New Map";
            this.btnNewMap.UseVisualStyleBackColor = true;
            this.btnNewMap.Click += new System.EventHandler(this.btnNewMap_Click);
            // 
            // grpBoxParts
            // 
            this.grpBoxParts.Controls.Add(this.btnCreatePart);
            this.grpBoxParts.Controls.Add(this.btnOpenPartFile);
            this.grpBoxParts.Controls.Add(this.btneditPart);
            this.grpBoxParts.Controls.Add(this.lblPartsAvaliable);
            this.grpBoxParts.Controls.Add(this.lbParts);
            this.grpBoxParts.Location = new System.Drawing.Point(532, 12);
            this.grpBoxParts.Name = "grpBoxParts";
            this.grpBoxParts.Size = new System.Drawing.Size(361, 513);
            this.grpBoxParts.TabIndex = 19;
            this.grpBoxParts.TabStop = false;
            this.grpBoxParts.Text = "Parts:";
            this.grpBoxParts.Enter += new System.EventHandler(this.grpBoxParts_Enter);
            // 
            // grpBoxMap
            // 
            this.grpBoxMap.Controls.Add(this.btnStartFromSelection);
            this.grpBoxMap.Controls.Add(this.cbRandomizeParts);
            this.grpBoxMap.Controls.Add(this.button5);
            this.grpBoxMap.Controls.Add(this.button4);
            this.grpBoxMap.Controls.Add(this.btnMoveDown);
            this.grpBoxMap.Controls.Add(this.btnUp);
            this.grpBoxMap.Controls.Add(this.btnRemoveFromMap);
            this.grpBoxMap.Controls.Add(this.lblMapParts);
            this.grpBoxMap.Controls.Add(this.lbMapParts);
            this.grpBoxMap.Controls.Add(this.btnNewMap);
            this.grpBoxMap.Controls.Add(this.btnLoadMap);
            this.grpBoxMap.Controls.Add(this.button3);
            this.grpBoxMap.Controls.Add(this.button2);
            this.grpBoxMap.Controls.Add(this.lblLaneCount);
            this.grpBoxMap.Controls.Add(this.btnEditLaneStep);
            this.grpBoxMap.Location = new System.Drawing.Point(12, 12);
            this.grpBoxMap.Name = "grpBoxMap";
            this.grpBoxMap.Size = new System.Drawing.Size(468, 513);
            this.grpBoxMap.TabIndex = 20;
            this.grpBoxMap.TabStop = false;
            this.grpBoxMap.Text = "Map:";
            // 
            // btnStartFromSelection
            // 
            this.btnStartFromSelection.Location = new System.Drawing.Point(353, 55);
            this.btnStartFromSelection.Name = "btnStartFromSelection";
            this.btnStartFromSelection.Size = new System.Drawing.Size(109, 24);
            this.btnStartFromSelection.TabIndex = 24;
            this.btnStartFromSelection.Text = "Start from Selection";
            this.btnStartFromSelection.UseVisualStyleBackColor = true;
            this.btnStartFromSelection.Click += new System.EventHandler(this.btnStartFromSelection_Click);
            // 
            // cbRandomizeParts
            // 
            this.cbRandomizeParts.AutoSize = true;
            this.cbRandomizeParts.Location = new System.Drawing.Point(13, 485);
            this.cbRandomizeParts.Name = "cbRandomizeParts";
            this.cbRandomizeParts.Size = new System.Drawing.Size(172, 17);
            this.cbRandomizeParts.TabIndex = 23;
            this.cbRandomizeParts.Text = "Randomize Part Order on Load";
            this.cbRandomizeParts.UseVisualStyleBackColor = true;
            this.cbRandomizeParts.CheckedChanged += new System.EventHandler(this.cbRandomizeParts_CheckedChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(246, 56);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(58, 24);
            this.button5.TabIndex = 22;
            this.button5.Text = "Set .exe";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(310, 55);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(37, 24);
            this.button4.TabIndex = 21;
            this.button4.Text = "Play";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(161, 56);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(31, 24);
            this.btnMoveDown.TabIndex = 20;
            this.btnMoveDown.Text = "🡇";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(124, 56);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(31, 24);
            this.btnUp.TabIndex = 19;
            this.btnUp.Text = "🡅";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // ofdEngine
            // 
            this.ofdEngine.DefaultExt = "exe";
            this.ofdEngine.FileName = "mge";
            this.ofdEngine.Filter = "Engine Executable|*.exe";
            this.ofdEngine.Multiselect = true;
            this.ofdEngine.Title = "Open XML Part File";
            // 
            // frmEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 537);
            this.Controls.Add(this.grpBoxMap);
            this.Controls.Add(this.grpBoxParts);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmEditor";
            this.Text = "Map Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditor_Closing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEditor_Closed);
            this.grpBoxParts.ResumeLayout(false);
            this.grpBoxParts.PerformLayout();
            this.grpBoxMap.ResumeLayout(false);
            this.grpBoxMap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblLaneCount;
        private System.Windows.Forms.Button btnEditLaneStep;
        private System.Windows.Forms.Label lblMapParts;
        private System.Windows.Forms.ListBox lbMapParts;
        private System.Windows.Forms.ListBox lbParts;
        private System.Windows.Forms.Label lblPartsAvaliable;
        private System.Windows.Forms.Button btnOpenPartFile;
        private System.Windows.Forms.Button btnRemoveFromMap;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog ofdPart;
        private System.Windows.Forms.Button btneditPart;
        private System.Windows.Forms.Button btnCreatePart;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.SaveFileDialog sfdExport;
        private System.Windows.Forms.Button btnLoadMap;
        private System.Windows.Forms.OpenFileDialog ofdMap;
        private System.Windows.Forms.Button btnNewMap;
        private System.Windows.Forms.GroupBox grpBoxParts;
        private System.Windows.Forms.GroupBox grpBoxMap;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.OpenFileDialog ofdEngine;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox cbRandomizeParts;
        private System.Windows.Forms.Button btnStartFromSelection;
    }
}

