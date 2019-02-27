
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
            this.btnOpenConsole = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.cbRandomizeParts = new System.Windows.Forms.CheckBox();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnStartFromSelection = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.ofdEngine = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.ofdHeightMap = new System.Windows.Forms.OpenFileDialog();
            this.grpBoxParts.SuspendLayout();
            this.grpBoxMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLaneCount
            // 
            this.lblLaneCount.AutoSize = true;
            this.lblLaneCount.Location = new System.Drawing.Point(440, 31);
            this.lblLaneCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLaneCount.Name = "lblLaneCount";
            this.lblLaneCount.Size = new System.Drawing.Size(94, 20);
            this.lblLaneCount.TabIndex = 2;
            this.lblLaneCount.Text = "Lane Spacing:";
            // 
            // lblMapParts
            // 
            this.lblMapParts.AutoSize = true;
            this.lblMapParts.Location = new System.Drawing.Point(13, 69);
            this.lblMapParts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMapParts.Name = "lblMapParts";
            this.lblMapParts.Size = new System.Drawing.Size(92, 20);
            this.lblMapParts.TabIndex = 6;
            this.lblMapParts.Text = "Parts(in map):";
            // 
            // lbMapParts
            // 
            this.lbMapParts.AllowDrop = true;
            this.lbMapParts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbMapParts.FormattingEnabled = true;
            this.lbMapParts.Location = new System.Drawing.Point(16, 105);
            this.lbMapParts.Margin = new System.Windows.Forms.Padding(4);
            this.lbMapParts.Name = "lbMapParts";
            this.lbMapParts.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbMapParts.Size = new System.Drawing.Size(599, 472);
            this.lbMapParts.TabIndex = 7;
            this.lbMapParts.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.MapDrawItems);
            this.lbMapParts.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmEditor_Drop);
            this.lbMapParts.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmEditor_DropEnter);
            this.lbMapParts.DoubleClick += new System.EventHandler(this.lbMapParts_DoubleClickLoseSelectedIndex);
            // 
            // lbParts
            // 
            this.lbParts.AllowDrop = true;
            this.lbParts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbParts.FormattingEnabled = true;
            this.lbParts.Location = new System.Drawing.Point(28, 89);
            this.lbParts.Margin = new System.Windows.Forms.Padding(4);
            this.lbParts.Name = "lbParts";
            this.lbParts.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbParts.Size = new System.Drawing.Size(443, 446);
            this.lbParts.TabIndex = 8;
            this.lbParts.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.PartsDrawItems);
            this.lbParts.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmEditor_Drop);
            this.lbParts.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmEditor_DropEnter);
            this.lbParts.DoubleClick += new System.EventHandler(this.lbParts_DoubleClickLoseSelectedIndex);
            // 
            // lblPartsAvaliable
            // 
            this.lblPartsAvaliable.AutoSize = true;
            this.lblPartsAvaliable.Location = new System.Drawing.Point(24, 69);
            this.lblPartsAvaliable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPartsAvaliable.Name = "lblPartsAvaliable";
            this.lblPartsAvaliable.Size = new System.Drawing.Size(101, 20);
            this.lblPartsAvaliable.TabIndex = 9;
            this.lblPartsAvaliable.Text = "Parts Avaliable:";
            // 
            // btnOpenPartFile
            // 
            this.btnOpenPartFile.Location = new System.Drawing.Point(177, 23);
            this.btnOpenPartFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenPartFile.Name = "btnOpenPartFile";
            this.btnOpenPartFile.Size = new System.Drawing.Size(141, 30);
            this.btnOpenPartFile.TabIndex = 10;
            this.btnOpenPartFile.Text = "Open Part";
           // this.btnOpenPartFile.UseSelectable = true;
            this.btnOpenPartFile.Click += new System.EventHandler(this.BtnOpenPartFile_Click);
            // 
            // btnRemoveFromMap
            // 
            this.btnRemoveFromMap.Location = new System.Drawing.Point(116, 69);
            this.btnRemoveFromMap.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveFromMap.Name = "btnRemoveFromMap";
            this.btnRemoveFromMap.Size = new System.Drawing.Size(41, 30);
            this.btnRemoveFromMap.TabIndex = 12;
            this.btnRemoveFromMap.Text = "X";
           // this.btnRemoveFromMap.UseSelectable = true;
            this.btnRemoveFromMap.Click += new System.EventHandler(this.BtnRemoveFromMap_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(660, 338);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 30);
            this.button1.TabIndex = 13;
            this.button1.Text = "<<";
            //this.button1.UseSelectable = true;
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
            this.btneditPart.Location = new System.Drawing.Point(327, 23);
            this.btneditPart.Margin = new System.Windows.Forms.Padding(4);
            this.btneditPart.Name = "btneditPart";
            this.btneditPart.Size = new System.Drawing.Size(145, 30);
            this.btneditPart.TabIndex = 14;
            this.btneditPart.Text = "Edit Part";
           // this.btneditPart.UseSelectable = true;
            this.btneditPart.Click += new System.EventHandler(this.BtneditPart_Click);
            // 
            // btnCreatePart
            // 
            this.btnCreatePart.Location = new System.Drawing.Point(28, 23);
            this.btnCreatePart.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreatePart.Name = "btnCreatePart";
            this.btnCreatePart.Size = new System.Drawing.Size(141, 30);
            this.btnCreatePart.TabIndex = 11;
            this.btnCreatePart.Text = "Create Part";
           // this.btnCreatePart.UseSelectable = true;
            this.btnCreatePart.Click += new System.EventHandler(this.BtnCreatePart_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(332, 23);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 30);
            this.button2.TabIndex = 15;
            this.button2.Text = "Export Map";
            //this.button2.UseSelectable = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(224, 23);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 30);
            this.button3.TabIndex = 16;
            this.button3.Text = "Save Map";
           // this.button3.UseSelectable = true;
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
            this.btnLoadMap.Location = new System.Drawing.Point(116, 23);
            this.btnLoadMap.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadMap.Name = "btnLoadMap";
            this.btnLoadMap.Size = new System.Drawing.Size(100, 30);
            this.btnLoadMap.TabIndex = 17;
            this.btnLoadMap.Text = "Load Map";
            //this.btnLoadMap.UseSelectable = true;
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
            this.btnNewMap.Location = new System.Drawing.Point(8, 23);
            this.btnNewMap.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewMap.Name = "btnNewMap";
            this.btnNewMap.Size = new System.Drawing.Size(100, 30);
            this.btnNewMap.TabIndex = 18;
            this.btnNewMap.Text = "New Map";
            //this.btnNewMap.UseSelectable = true;
            this.btnNewMap.Click += new System.EventHandler(this.btnNewMap_Click);
            // 
            // grpBoxParts
            // 
            this.grpBoxParts.Controls.Add(this.btnCreatePart);
            this.grpBoxParts.Controls.Add(this.btnOpenPartFile);
            this.grpBoxParts.Controls.Add(this.btneditPart);
            this.grpBoxParts.Controls.Add(this.lblPartsAvaliable);
            this.grpBoxParts.Controls.Add(this.lbParts);
            this.grpBoxParts.Location = new System.Drawing.Point(709, 84);
            this.grpBoxParts.Margin = new System.Windows.Forms.Padding(4);
            this.grpBoxParts.Name = "grpBoxParts";
            this.grpBoxParts.Padding = new System.Windows.Forms.Padding(4);
            this.grpBoxParts.Size = new System.Drawing.Size(481, 562);
            this.grpBoxParts.TabIndex = 19;
            this.grpBoxParts.TabStop = false;
            this.grpBoxParts.Text = "Parts:";
            this.grpBoxParts.Enter += new System.EventHandler(this.grpBoxParts_Enter);
            // 
            // grpBoxMap
            // 
            this.grpBoxMap.Controls.Add(this.btnOpenConsole);
            this.grpBoxMap.Controls.Add(this.numericUpDown1);
            this.grpBoxMap.Controls.Add(this.cbRandomizeParts);
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
            this.grpBoxMap.Location = new System.Drawing.Point(16, 15);
            this.grpBoxMap.Margin = new System.Windows.Forms.Padding(4);
            this.grpBoxMap.Name = "grpBoxMap";
            this.grpBoxMap.Padding = new System.Windows.Forms.Padding(4);
            this.grpBoxMap.Size = new System.Drawing.Size(624, 631);
            this.grpBoxMap.TabIndex = 20;
            this.grpBoxMap.TabStop = false;
            this.grpBoxMap.Text = "Map:";
            // 
            // btnOpenConsole
            // 
            this.btnOpenConsole.Location = new System.Drawing.Point(499, 597);
            this.btnOpenConsole.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenConsole.Name = "btnOpenConsole";
            this.btnOpenConsole.Size = new System.Drawing.Size(117, 28);
            this.btnOpenConsole.TabIndex = 25;
            this.btnOpenConsole.Text = "Open Console";
           // this.btnOpenConsole.UseSelectable = true;
            this.btnOpenConsole.Click += new System.EventHandler(this.btnOpenConsole_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(551, 27);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(65, 22);
            this.numericUpDown1.TabIndex = 24;
            this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // cbRandomizeParts
            // 
            this.cbRandomizeParts.AutoSize = true;
            this.cbRandomizeParts.Location = new System.Drawing.Point(17, 597);
            this.cbRandomizeParts.Margin = new System.Windows.Forms.Padding(4);
            this.cbRandomizeParts.Name = "cbRandomizeParts";
            this.cbRandomizeParts.Size = new System.Drawing.Size(207, 17);
            this.cbRandomizeParts.TabIndex = 23;
            this.cbRandomizeParts.Text = "Randomize Part Order on Load";
           // this.cbRandomizeParts.UseSelectable = true;
            this.cbRandomizeParts.CheckedChanged += new System.EventHandler(this.cbRandomizeParts_CheckedChanged);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(215, 69);
            this.btnMoveDown.Margin = new System.Windows.Forms.Padding(4);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(41, 30);
            this.btnMoveDown.TabIndex = 20;
            this.btnMoveDown.Text = "🡇";
           // this.btnMoveDown.UseSelectable = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(165, 69);
            this.btnUp.Margin = new System.Windows.Forms.Padding(4);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(41, 30);
            this.btnUp.TabIndex = 19;
            this.btnUp.Text = "🡅";
            //this.btnUp.UseSelectable = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnStartFromSelection
            // 
            this.btnStartFromSelection.Location = new System.Drawing.Point(151, 23);
            this.btnStartFromSelection.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartFromSelection.Name = "btnStartFromSelection";
            this.btnStartFromSelection.Size = new System.Drawing.Size(145, 30);
            this.btnStartFromSelection.TabIndex = 24;
            this.btnStartFromSelection.Text = "Start from Selection";
           // this.btnStartFromSelection.UseSelectable = true;
            this.btnStartFromSelection.Click += new System.EventHandler(this.btnStartFromSelection_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(8, 23);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(77, 30);
            this.button5.TabIndex = 22;
            this.button5.Text = "Set .exe";
            //this.button5.UseSelectable = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(93, 23);
            this.btnPlay.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(49, 30);
            this.btnPlay.TabIndex = 21;
            this.btnPlay.Text = "Play";
           // this.btnPlay.UseSelectable = true;
            this.btnPlay.Click += new System.EventHandler(this.button4_Click);
            // 
            // ofdEngine
            // 
            this.ofdEngine.DefaultExt = "exe";
            this.ofdEngine.FileName = "mge";
            this.ofdEngine.Filter = "Engine Executable|*.exe";
            this.ofdEngine.Multiselect = true;
            this.ofdEngine.Title = "Open XML Part File";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.btnStartFromSelection);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.btnPlay);
            this.groupBox1.Location = new System.Drawing.Point(709, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(481, 65);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Engine Controls";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(299, 25);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(173, 28);
            this.button4.TabIndex = 27;
            this.button4.Text = "Set Engine Settings";
           // this.button4.UseSelectable = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // ofdHeightMap
            // 
            this.ofdHeightMap.FileName = "Open Heightmap";
            // 
            // frmEditor
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1207, 661);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpBoxMap);
            this.Controls.Add(this.grpBoxParts);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditor";
            this.Text = "Map Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditor_Closing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEditor_Closed);
            this.Load += new System.EventHandler(this.frmEditor_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmEditor_Drop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmEditor_DropEnter);
            this.grpBoxParts.ResumeLayout(false);
            this.grpBoxParts.PerformLayout();
            this.grpBoxMap.ResumeLayout(false);
            this.grpBoxMap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLaneCount;
        //private System.Windows.Forms.Label lblLaneCount;
        private System.Windows.Forms.Label lblMapParts;
        //private System.Windows.Forms.ListView lbMapParts;
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
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.OpenFileDialog ofdEngine;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox cbRandomizeParts;
        private System.Windows.Forms.Button btnStartFromSelection;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog ofdHeightMap;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnOpenConsole;
    }
}

