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
    public partial class EngineSettings : Form
    {
        List<string> files = new List<string>();
        string folderPath = "";
        editorConfig ec;
        public EngineSettings(string folderPath, editorConfig config)
        {
            this.folderPath = folderPath;
            ec = config;
            InitializeComponent();
        }

        public void InvalidateCombos()
        {
            if (!System.IO.Directory.Exists(folderPath)) return;

            files = System.IO.Directory.GetFiles(folderPath).ToList();
            cbHms.Items.Clear();
            cbHorizon.Items.Clear();
            cbGround.Items.Clear();

            cbHms.Items.Add("NONE");
            cbHorizon.Items.Add("NONE");
            cbGround.Items.Add("NONE");

            foreach (string f in files)
            {
                string file = f.Substring(f.LastIndexOf("\\") + 1);
                   cbHms.Items.Add(file);
                cbHorizon.Items.Add(file);
                cbGround.Items.Add(file);
            }

            if (cbHms.Items.Count > ec.HeightMap) cbHms.SelectedIndex = ec.HeightMap;
            if (cbGround.Items.Count > ec.GroundMap) cbGround.SelectedIndex = ec.GroundMap;
            if (cbHorizon.Items.Count > ec.HorizonMap) cbHorizon.SelectedIndex = ec.HorizonMap;

        }

        private void cbHms_SelectedIndexChanged(object sender, EventArgs e)
        {
            ec.HeightMap = cbHms.SelectedIndex;
        }

        private void EngineSettings_closing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cbHorizon_SelectedIndexChanged(object sender, EventArgs e)
        {
            ec.HorizonMap = cbHorizon.SelectedIndex;
        }

        private void cbGround_SelectedIndexChanged(object sender, EventArgs e)
        {
            ec.GroundMap = cbGround.SelectedIndex;
        }

        public editorConfig GetConfig()
        {
            return ec;
        }

        public string GetHeight()
        {
            if (ec.HeightMap == 0) return "";
            return  cbHms.Items[ec.HeightMap].ToString();
        }
        public string GetGround()
        {
            if (ec.GroundMap == 0) return "";
            return cbGround.Items[ec.GroundMap].ToString();
        }
        public string GetHorizon()
        {
            if (ec.HorizonMap == 0) return "";
            return cbHorizon.Items[ec.HorizonMap].ToString();
        }

        private void cboxMapMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ec.isRaw = cboxMapMode.SelectedIndex == 0;
        }
    }
}
