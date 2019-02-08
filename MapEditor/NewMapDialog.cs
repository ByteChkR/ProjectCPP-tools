using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor
{
    public partial class NewMapDialog : Form
    {
        Editor editor;
        public NewMapDialog(Editor editor)
        {
            this.editor = editor;
            InitializeComponent();
            DialogResult = DialogResult.Abort;
        }

        private void tbMapName_TextChanged(object sender, EventArgs e)
        {
            if (!editor.FindAndExportPart(tbMapName.Text, (int)nudLaneCount.Value, (int)nudPartSize.Value, out List<string> a))
            {
                tbMapName.BackColor = Color.Green;
            }
            else
            {
                tbMapName.BackColor = Color.Red;
            }
        }

        void CheckParts()
        {
            lbAvailableScripts.Items.Clear();
            foreach (Part part in editor.GetPartsWithConfiguration((int)nudLaneCount.Value, (int)nudPartSize.Value))
            {
                lbAvailableScripts.Items.Add(part.name);
            }
        }

        private void nudPartSize_ValueChanged(object sender, EventArgs e)
        {
            CheckParts();
        }

        private void nudLaneCount_ValueChanged(object sender, EventArgs e)
        {
            CheckParts();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Map m = new Map((int)nudPartSize.Value, (int)nudLaneCount.Value);
            editor.LoadMap(m);
            ADL.Debug.LogGen(LoggingChannel.NEWMAPDIALOG_EDITOR | LoggingChannel.LOG, "Created new map " + tbMapName.Text);
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
