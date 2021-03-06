﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADL;
using System.Windows.Forms;

namespace MapEditor
{
    public partial class PartCreator : Form
    {
        Part _part;

        int _laneCount;
        int _partLength;
        bool _edit;
        string _saveLocation;
        public PartCreator(Part part, bool edit, int biomeCount, string editSaveLocation)
        {
            _part = part;
            _edit = edit;
            _saveLocation = editSaveLocation;
            InitializeComponent();

            nudBiomeID.Maximum = biomeCount - 1;
            Text = part.name;
            string text = "";
            if (part.part != null) part.ToEditFormat().ForEach(x => text += x + '\n');
            richTextBox1.Text = text.TrimEnd();
            nudBiomeID.Value = part.biomeID;
            DialogResult = DialogResult.Cancel;

            if (_edit)
            {
                tbPartName.Enabled = false;
                tbPartName.Text = part.name;
            }
            else
            {

                tbPartName.Enabled = true;
                tbPartName.Text = part.name;
            }
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            CheckData(out _part.part, out string err);
            lblLaneCount.Text = "Lane Count: " + _laneCount;
            lblPartSize.Text = "Part Size: " + _partLength;
            lblCompileStatus.Text = err;
        }

        private bool CheckData(out int[][] data, out string errorMessage)
        {
            _partLength = -1;
            _laneCount = -1;
            errorMessage = "Sucess";
            string[] lanes = richTextBox1.Text.Split('\n');
            data = new int[lanes.Length][];
            _laneCount = lanes.Length;
            for (int i = 0; i < lanes.Length; i++)
            {
                string lane = lanes[i];


                string[] segments = lane.Split(' ');
                data[i] = new int[segments.Length];
                if (_partLength == -1) _partLength = segments.Length;
                else if (_partLength != segments.Length)
                {
                    errorMessage = "Not all lanes same length->BAD";
                    return false;
                }
                for (int j = 0; j < segments.Length; j++)
                {
                    if (!int.TryParse(segments[j], out int value))
                    {
                        errorMessage = " Not an integer at col " + i;
                        return false;
                    }
                    else
                        data[i][j] = value;
                }

            }
            return true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            if (CheckData(out _part.part, out string err) && (_edit || ValidateName(out _part.name)))
            {

                System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(Part));
                _part.partLength = _partLength;
                _part.laneCount = _laneCount;
                _part.biomeID = (int)nudBiomeID.Value;
                //_part.name = tbPartName.Text;
                System.IO.Stream s = null;
                try
                {
                    s = System.IO.File.Open(_saveLocation + _part.name, System.IO.FileMode.Create);
                    xs.Serialize(s, _part);
                    s.Close();
                }
                catch (Exception)
                {
                    if (s != null) s.Close();
                    Debug.LogGen(LoggingChannel.PARTCREATOR_EDITOR | LoggingChannel.ERROR, err);
                }



                this.DialogResult = DialogResult.OK;
                this.Close();
                Debug.LogGen(LoggingChannel.PARTCREATOR_EDITOR | LoggingChannel.LOG, "Created Part:" + _part.name);
                return;



            }
            else
            {
                Debug.LogGen(LoggingChannel.PARTCREATOR_EDITOR | LoggingChannel.ERROR, "Error in the Part Data:" + err);
                MessageBox.Show("Error in the Part Data");
            }
        }

        public Part GetPart()
        {
            return _part;
        }

        private void sfd_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tbPartName_TextChanged(object sender, EventArgs e)
        {
            tbPartName.BackColor = ValidateName(out string s) ? Color.Green : Color.Red;
        }

        bool ValidateName(out string fileName)
        {
            string name = tbPartName.Text;
            name += ".###";
            name = name.Replace(".pxml", "");
            name = name.Replace(".###", ".pxml");
            fileName = name;
            return !System.IO.File.Exists(_saveLocation + name);
        }
    }
}
