using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADL;

namespace MapEditor
{
    public partial class EngineSettings : Form
    {
        List<string> files = new List<string>();
        string folderPath = "";
        editorConfig ec;
        Map m = null;
        public EngineSettings(string folderPath, editorConfig config, Map map = null)
        {
            Shown += EngineSettings_Shown;
            this.folderPath = folderPath;
            ec = config;
            InitializeComponent();
            InvalidateCombos();
            if (map == null)
            {
                gbMapSettings.Enabled = false;
                btnFogColor.Enabled = false;
            }
            else
            {
                gbMapSettings.Enabled = true;
                btnFogColor.Enabled = true;
                InvalidateMapSettings();
            }
            m = map;
            cboxMapMode.SelectedIndex = ec.isRaw ? 0 : 1;
        }

        private void EngineSettings_Shown(object sender, EventArgs e)
        {
            if (m == null)
            {
                gbMapSettings.Enabled = false;
                btnFogColor.Enabled = false;
            }
            else
            {
                gbMapSettings.Enabled = true;
                btnFogColor.Enabled = true;
                InvalidateMapSettings();
            }
        }

        public void SetMap(Map map)
        {

            m = map;
            if (m == null) gbMapSettings.Enabled = false;
            else
            {
                gbMapSettings.Enabled = true;
                InvalidateMapSettings();
            }
        }

        void InvalidateMapSettings()
        {
            nudXMoveTiling.Value = (decimal)m.xMoveTiling;
            nudHeightMapSamplingWidth.Value = (decimal)m.heightMapSamplingWidth;
            nudHeightMapMaxHeight.Value = (decimal)m.heightMapMaxHeight;
            nudHeightMapSpeed.Value = (decimal)m.heightMapSpeed;
            nudHeightMapTiling.Value = (decimal)m.heightMapTiling;
            nudXCurvatureSmoothness.Value = (decimal)m.xCurvatureSmoothness;
            nudXCurvature.Value = (decimal)m.xCurvature;
            nudGenOffset.Value = (decimal)m.genOffset;
            panelColorPreview.BackColor = Color.FromArgb((int)(m.fogColorR * 255), (int)(m.fogColorG * 255), (int)(m.fogColorB * 255));

        }
        public void InvalidateCombos()
        {
            if (!System.IO.Directory.Exists(folderPath)) return;

            files = System.IO.Directory.GetFiles(folderPath).ToList();
            cbHms.Items.Clear();
            cbHorizon.Items.Clear();
            cbGround.Items.Clear();
            cbGroundNormal.Items.Clear();

            cbHms.Items.Add("NONE");
            cbHorizon.Items.Add("NONE");
            cbGround.Items.Add("NONE");
            cbGroundNormal.Items.Add("NONE");
            foreach (string f in files)
            {
                string file = f.Substring(f.LastIndexOf("\\") + 1);
                cbHms.Items.Add(file);
                cbHorizon.Items.Add(file);
                cbGround.Items.Add(file);
                cbGroundNormal.Items.Add(file);
            }

            if (cbHms.Items.Count > ec.HeightMap) cbHms.SelectedIndex = ec.HeightMap;
            if (cbGround.Items.Count > ec.GroundMap) cbGround.SelectedIndex = ec.GroundMap;
            if (cbHorizon.Items.Count > ec.HorizonMap) cbHorizon.SelectedIndex = ec.HorizonMap;
            if (cbGroundNormal.Items.Count > ec.GroundNormalMap) cbGroundNormal.SelectedIndex = ec.GroundNormalMap;

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

        public string GetGroundNormal()
        {
            if (ec.GroundNormalMap == 0 || cbHms.Items.Count >= ec.GroundNormalMap) return "";
            return cbGroundNormal.Items[ec.GroundNormalMap].ToString();
        }

        public string GetHeight()
        {
            if (ec.HeightMap == 0 || cbHms.Items.Count <= ec.HeightMap) return "";
            return cbHms.Items[ec.HeightMap].ToString();
        }
        public string GetGround()
        {
            if (ec.GroundMap == 0 || cbHms.Items.Count <= ec.GroundMap) return "";
            return cbGround.Items[ec.GroundMap].ToString();
        }
        public string GetHorizon()
        {
            if (ec.HorizonMap == 0 || cbHms.Items.Count <= ec.HorizonMap) return "";
            return cbHorizon.Items[ec.HorizonMap].ToString();
        }

        private void cboxMapMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ec.isRaw = cboxMapMode.SelectedIndex == 0;
        }

        private void nudGenOffset_ValueChanged(object sender, EventArgs e)
        {
            m.genOffset = (float)nudGenOffset.Value;
        }

        private void nudXCurvature_ValueChanged(object sender, EventArgs e)
        {
            m.xCurvature = (float)nudXCurvature.Value;
        }

        private void nudXCurvatureSmoothness_ValueChanged(object sender, EventArgs e)
        {

            m.xCurvatureSmoothness = (float)nudXCurvatureSmoothness.Value;
        }

        private void nudHeightMapTiling_ValueChanged(object sender, EventArgs e)
        {
            m.heightMapTiling = (float)nudHeightMapTiling.Value;
        }

        private void nudHeightMapSpeed_ValueChanged(object sender, EventArgs e)
        {

            m.heightMapSpeed = (float)nudHeightMapSpeed.Value;
        }

        private void nudHeightMapMaxHeight_ValueChanged(object sender, EventArgs e)
        {

            m.heightMapMaxHeight = (float)nudHeightMapMaxHeight.Value;
        }

        private void nudHeightMapSamplingWidth_ValueChanged(object sender, EventArgs e)
        {

            m.heightMapSamplingWidth = (float)nudHeightMapSamplingWidth.Value;
        }

        private void nudXMoveTiling_ValueChanged(object sender, EventArgs e)
        {

            m.xMoveTiling = (float)nudXMoveTiling.Value;
        }



        private void btnAddHeightmap_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process p = new System.Diagnostics.Process();
            //p.StartInfo = new System.Diagnostics.ProcessStartInfo(Environment.SystemDirectory+ "\\explorer.exe", @folderPath);
            //p.StartInfo.RedirectStandardError = true;
            //p.StartInfo.UseShellExecute = false;
            //p.StartInfo.ErrorDialog = true;
            //if(!p.Start())
            //{
            //    Debug.LogGen(LoggingChannel.ERROR, p.StandardError.ReadToEnd());
            //}
            //while (!p.HasExited) { }
            InvalidateCombos();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(folderPath);
        }

        private void cbGroundNormal_SelectedIndexChanged(object sender, EventArgs e)
        {
            ec.GroundNormalMap = cbGroundNormal.SelectedIndex;
        }

        private void btnFogColor_Click(object sender, EventArgs e)
        {
            Cyotek.Windows.Forms.ColorPickerDialog cw = new Cyotek.Windows.Forms.ColorPickerDialog();
            cw.Color = Color.FromArgb((int)(m.fogColorR * 255), (int)(m.fogColorG * 255), (int)(m.fogColorB * 255));
            if (cw.ShowDialog() == DialogResult.OK)
            {
                m.fogColorB = cw.Color.B / 255f;
                m.fogColorG = cw.Color.G / 255f;
                m.fogColorR = cw.Color.R / 255f;
            }
            panelColorPreview.BackColor = cw.Color;
        }
    }
}
