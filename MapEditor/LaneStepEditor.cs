using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using ADL;
using System.Windows.Forms;

namespace MapEditor
{
    public partial class LaneStepEditor : Form
    {
        int _laneCount;
        int[] row;
        public LaneStepEditor(int laneCount, int[] row)
        {
            if (laneCount <= 0) laneCount = 1;
            _laneCount = laneCount;
            this.row = row;
            InitializeComponent();

            for (int i = 0; i < laneCount; i++)
            {
                DataGridViewTextBoxColumn dgvc = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Lane " + i + " Step:",
                    ValueType = typeof(int),


                };

                dgv.Columns.Add(dgvc);
            }
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgv);
            for (int i = 0; i < row.Length; i++)
            {
                r.Cells[i].Value = row[i];
            }

            dgv.Rows.Add(r);

        }

        private void LaneStepEditor_Closing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (row == null) row = new int[_laneCount];
            for (int i = 0; i < _laneCount; i++)
            {
                DataGridViewCell dgvc = dgv.Rows[0].Cells[i];

                if (!int.TryParse(dgvc.Value.ToString(), out row[i]))
                {
                    Debug.LogGen(LoggingChannel.LANESTEP_EDITOR | LoggingChannel.ERROR, "Error, one value is not a number");
                    MessageBox.Show("Error, one value is not a number");
                    e.Cancel = true;
                    return;
                }
            }
        }

        public int[] GetRow()
        {
            return row;
        }
    }
}
