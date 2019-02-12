using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using ADL;
using ADL.Streams;
using ADL.Configs;
namespace MapEditor
{
    public partial class frmEditor : Form
    {
        System.Diagnostics.Process _engine;
        string _enginePath = "";
        string _engineWorkingDir = "";
        string _defaultPartFolder = "";
        int _biomeCount = 1;
        public Editor editor;
        Form adl;

        public frmEditor(bool enableLogging)
        {

            InitializeComponent();

            

            ReadConfig();


            Debug.ADLEnabled = false;
            if (enableLogging)
            {
                PipeStream ps = initADL();

                Debug.ADLEnabled = true;

                //CreateADLCustomCMDConfig();

                adl = ADL.CustomCMD.CMDUtils.CreateCustomConsole(ps);
                
                Debug.LogGen(LoggingChannel.LOG | LoggingChannel.MAIN_EDITOR, "Initialized Debug Logs.");
            }
            if (System.IO.Directory.Exists(_defaultPartFolder))
            {
                LoadParts(System.IO.Directory.GetFiles(_defaultPartFolder, "*.pxml"), out Part[] parts);
                editor = new Editor(parts.ToList());
                InvalidateParts();
            }


        }

        #region DebugLogging
        private static void CreateADLCustomCMDConfig()
        {

            SerializableDictionary<int, SerializableColor> colorCoding =
                new SerializableDictionary<int, SerializableColor>(
                    new Dictionary<int, SerializableColor>()
                    {
                        {8, System.Drawing.Color.Red }, //Every errror message should be drawn in red.
                        {4, System.Drawing.Color.Orange }, //Every warning is painted in orange
                        {2, System.Drawing.Color.Magenta },
                        {16, System.Drawing.Color.Green },
                    });
            ADLCustomConsoleConfig config = ADLCustomConsoleConfig.Standard;
            config.FontSize = 13;
            config.FrameTime = 45;
            config.ColorCoding = colorCoding;
            ADL.CustomCMD.CMDUtils.SaveConfig(config);
        }

        PipeStream initADL()
        {
            Debug.LoadConfig();
            Debug.SendWarnings = true;
            Debug.SendUpdateMessageOnFirstLog = true;

            Debug.PrefixLookupMode = PrefixLookupSettings.ADDPREFIXIFAVAILABLE |
                                    PrefixLookupSettings.DECONSTRUCTMASKTOFIND; //If you have int.minvalue to int.maxvalue channels this is not really advisable. (Config files can be bloated by baked prefixes thus getting a huge size.)

            PipeStream ps = new PipeStream();

            LogStream ls = new LogStream(
                ps,
                new BitMask<LoggingChannel>(true),
                MatchType.MATCH_ONE,
                true);

            Debug.AddOutputStream(ls);



            return ps;
        }
        #endregion




        private void Button1_Click(object sender, EventArgs e)
        {

            if (editor.GetMap(out Map map) && editor.GetPartAt(lbParts.SelectedIndex, out Part part) && part.IsValid(map.LaneCount, map.PartSize) && editor.AddToMapByIndex(lbMapParts.SelectedIndex, lbParts.SelectedIndex))
            {

                InvalidateMap(map);
            }
        }

        private void AddToMapByIndex(int indexInMap, int indexOfPart)
        {
            if (editor.AddToMapByIndex(indexInMap, indexOfPart))
            {
                if (editor.GetMap(out Map m))
                    InvalidateMap(m);
            }

        }

        private void BtnRemoveFromMap_Click(object sender, EventArgs e)
        {
            if (editor.GetMap(out Map map))
            {
                if (editor.RemoveFromMapByIndex(lbMapParts.SelectedIndex))
                {

                    InvalidateMap(map);
                }
            }
            lbMapParts.Focus();
        }

        public void InvalidateMap(Map map)
        {
            int index = lbMapParts.SelectedIndex;
            lbMapParts.Items.Clear();

            lbMapParts.Items.AddRange(map.PartSequence);
            if (lbMapParts.Items.Count > index) lbMapParts.SelectedIndex = index;
        }

        private void BtnOpenPartFile_Click(object sender, EventArgs e)
        {
            if (ofdPart.ShowDialog() == DialogResult.OK)
            {
                LoadParts(ofdPart.FileNames, out Part[] newParts);
                foreach (Part part in newParts)
                {
                    editor.LoadPart(part);
                }
                InvalidateParts();
                if (editor.GetMap(out Map map)) InvalidateMap(map);
            }
        }



        void InvalidateParts()
        {
            int index = lbParts.SelectedIndex;
            lbParts.Items.Clear();
            editor.GetParts(out List<Part> parts);
            foreach (Part part in parts)
            {
                lbParts.Items.Add(part.ToString());
            }
            if (lbParts.Items.Count > index) lbParts.SelectedIndex = index;

        }

        void MapDrawItems(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;
            e.DrawBackground();
            Graphics g = e.Graphics;
            Brush available = Brushes.Black;
            Brush unavailable = Brushes.Red;

            if (editor.GetMap(out Map map))
                if (editor.FindPart(lbMapParts.Items[e.Index].ToString(), map.LaneCount, map.PartSize, out Part part))
                {

                    e.Graphics.DrawString(lbMapParts.Items[e.Index].ToString(), e.Font, available, e.Bounds, StringFormat.GenericDefault);
                }
                else
                {
                    e.Graphics.DrawString(lbMapParts.Items[e.Index].ToString(), e.Font, unavailable, e.Bounds, StringFormat.GenericDefault);

                }
            else
            {
                e.Graphics.DrawString(lbMapParts.Items[e.Index].ToString(), e.Font, unavailable, e.Bounds, StringFormat.GenericDefault);

            }
            e.DrawFocusRectangle();
        }

        void PartsDrawItems(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;
            e.DrawBackground();
            Graphics g = e.Graphics;
            Brush available = Brushes.Black;
            Brush unavailable = Brushes.Red;

            if (editor.GetMap(out Map map))
                if (editor.FindPart(lbParts.Items[e.Index].ToString(), map.LaneCount, map.PartSize, out Part part))
                {

                    e.Graphics.DrawString(lbParts.Items[e.Index].ToString(), e.Font, available, e.Bounds, StringFormat.GenericDefault);
                }
                else
                {
                    e.Graphics.DrawString(lbParts.Items[e.Index].ToString(), e.Font, unavailable, e.Bounds, StringFormat.GenericDefault);

                }
            else
            {
                e.Graphics.DrawString(lbParts.Items[e.Index].ToString(), e.Font, unavailable, e.Bounds, StringFormat.GenericDefault);

            }
            e.DrawFocusRectangle();
        }

        private void BtnCreatePart_Click(object sender, EventArgs e)
        {
            Part pFinal;
            if (editor.GetPartAt(lbParts.SelectedIndex, out Part p))
            {
                pFinal = Part.Copy(p);
            }
            else pFinal = new Part();

            PartCreator pc = new PartCreator(pFinal, false, _biomeCount, "");
            if (pc.ShowDialog() == DialogResult.OK)
            {
                editor.LoadPart(pc.GetPart());
                InvalidateParts();
                if (editor.GetMap(out Map map)) InvalidateMap(map);
            }

        }

        private void BtneditPart_Click(object sender, EventArgs e)
        {
            if (lbParts.SelectedIndex == -1) return;
            if (editor.GetPartAt(lbParts.SelectedIndex, out Part part))
            {
                PartCreator pc = new PartCreator(part, true, _biomeCount, _defaultPartFolder);
                if (pc.ShowDialog() == DialogResult.OK)
                {
                    InvalidateParts();
                }
            }
        }

        private void BtnEditLaneStep_Click(object sender, EventArgs e)
        {

            if (editor.GetMap(out Map map))
            {
                LaneStepEditor lse = new LaneStepEditor(map.LaneCount, map.LaneSteps);
                if (lse.ShowDialog() == DialogResult.OK)
                {
                    map.LaneSteps = lse.GetRow();
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {


            if (sfd.ShowDialog() == DialogResult.OK && editor.GetMap(out Map map))
            {
                SaveMap(sfd.FileName, map);
            }
        }



        private void Button2_Click(object sender, EventArgs e)
        {
            if (editor.GetMap(out Map map) && sfdExport.ShowDialog() == DialogResult.OK)
            {
                List<string> exportString = editor.ExportMap();

            
                SaveExport(exportString, sfdExport.FileName);
            }
        }


        private void btnLoadMap_Click(object sender, EventArgs e)
        {
            if (ofdMap.ShowDialog() == DialogResult.OK && LoadMap(ofdMap.FileName, out Map m))
            {

                editor.LoadMap(m);
                InvalidateMap(m);
                InvalidateParts();
            }
        }

        private void btnNewMap_Click(object sender, EventArgs e)
        {
            NewMapDialog nmd = new NewMapDialog(editor);
            if (nmd.ShowDialog() == DialogResult.OK)
            {
                if (editor.GetMap(out Map map))
                {
                    InvalidateParts();
                    InvalidateMap(map);

                }
            }
        }

        #region IO

        #region MapIO
        bool LoadMap(string file, out Map map)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Map));

            map = null;

            System.IO.Stream s = null;
            try
            {
                s = System.IO.File.OpenRead(file);
                map = (Map)xs.Deserialize(s);
                s.Close();
                return true;
            }
            catch (Exception)
            {
                if (s != null) s.Close();
                Debug.LogGen(LoggingChannel.MAIN_EDITOR | LoggingChannel.WINDOWS_FORM | LoggingChannel.ERROR, "Error. Could not read " + file);
                return false;
            }
        }


        void SaveExport(List<string> data, string fileName)
        {
            System.IO.TextWriter tw = null;
            try
            {
                tw = new System.IO.StreamWriter(fileName);
                for (int i = 0; i < data.Count; i++)
                {
                    tw.WriteLine(data[i]);
                }
                tw.Close();
            }
            catch (Exception)
            {
                if (tw != null) tw.Close();
                Debug.LogGen(LoggingChannel.ERROR | LoggingChannel.MAIN_EDITOR | LoggingChannel.WINDOWS_FORM, "Error. Could not write to " + fileName);
            }
        }

        public bool SaveMap(string file, Map map)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Map));
            System.IO.Stream s = null;
            try
            {
                s = System.IO.File.OpenWrite(file);
                xs.Serialize(s, map);
                s.Close();
                Debug.LogGen(LoggingChannel.LOG | LoggingChannel.MAIN_EDITOR | LoggingChannel.WINDOWS_FORM, "Saved map to " + file);
                return true;
            }
            catch (Exception)
            {
                if (s != null) s.Close();
                Debug.LogGen(LoggingChannel.MAIN_EDITOR | LoggingChannel.WINDOWS_FORM | LoggingChannel.ERROR, "Error. Could not write to " + file);
                return false;
            }
        }

        #endregion

        #region PartIO
        bool LoadParts(string[] files, out Part[] newParts)
        {
            newParts = new Part[files.Length];
            bool result = true;
            for (int i = 0; i < files.Length; i++)
            {
                result = result && LoadPart(files[i], out newParts[i]);
            }
            if (result) Debug.LogGen<LoggingChannel>(LoggingChannel.LOG | LoggingChannel.MAIN_EDITOR, "Loaded " + newParts.Length + " new Parts from XML");
            else Debug.LogGen<LoggingChannel>(LoggingChannel.WARNING | LoggingChannel.MAIN_EDITOR, "Completed with errors");

            return result;
        }

        bool LoadPart(string file, out Part part)
        {

            XmlSerializer xs = new XmlSerializer(typeof(Part));

            System.IO.Stream s = null;
            try
            {
                s = System.IO.File.OpenRead(file);
                part = (Part)xs.Deserialize(s);
                s.Close();
            }
            catch (Exception)
            {
                if (s != null) s.Close();
                Debug.LogGen<LoggingChannel>(LoggingChannel.WARNING | LoggingChannel.MAIN_EDITOR, "Error. Could not read " + file);
                part = new Part();
                return false;

            }
            return true;
        }
        #endregion

        #region ConfigIO

        void ReadConfig()
        {

            editorConfig ec = editorConfig.GetStandard();
            XmlSerializer xs = new XmlSerializer(typeof(editorConfig));
            System.IO.Stream s = null;
            try
            {
                s = System.IO.File.OpenRead(".\\config.xml");
                ec = (editorConfig)xs.Deserialize(s);
                s.Close();
            }
            catch (Exception)
            {
                if (s != null) s.Close();
                Debug.LogGen<LoggingChannel>(LoggingChannel.WARNING | LoggingChannel.MAIN_EDITOR, "Error. Could not read config file. using default");



            }
            if (ec.biomeCount > 0) _biomeCount = ec.biomeCount;
            _enginePath = ec.EnginePath;
            if(_enginePath != "")_engineWorkingDir = _enginePath.Substring(0,_enginePath.LastIndexOf('\\')+1);
            _defaultPartFolder = ec.DefaultPartsFolder;
            InvalidateEnginePath();
            if (cbHms.Items.Count > ec.HeightMap) cbHms.SelectedIndex = ec.HeightMap;
        }

        void SaveConfig()
        {
            XmlSerializer xs = new XmlSerializer(typeof(editorConfig));
            editorConfig ec = new editorConfig()
            {
                EnginePath = _enginePath,
                DefaultPartsFolder = _defaultPartFolder,
                biomeCount = _biomeCount,
                HeightMap = cbHms.SelectedIndex
            };
            System.IO.TextWriter tw = null;
            try
            {
                tw = new System.IO.StreamWriter(".\\config.xml");
                xs.Serialize(tw, ec);
                tw.Close();
            }
            catch (Exception)
            {
                if (tw != null) tw.Close();
                Debug.LogGen(LoggingChannel.ERROR | LoggingChannel.MAIN_EDITOR | LoggingChannel.WINDOWS_FORM, "Error. Could not write to config file");
            }
        }

        #endregion

        #endregion

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (editor.GetMap(out Map map))
            {
                if (editor.SwapParts(lbMapParts.SelectedIndex, lbMapParts.SelectedIndex - 1))
                {

                    InvalidateMap(map);
                    lbMapParts.SelectedIndex--;
                }
            }

        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (editor.GetMap(out Map map))
            {
                if (editor.SwapParts(lbMapParts.SelectedIndex, lbMapParts.SelectedIndex + 1))
                {

                    InvalidateMap(map);
                    lbMapParts.SelectedIndex++;
                }
            }
        }

        private void grpBoxParts_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (_enginePath == "")
            {
                if (ofdEngine.ShowDialog() == DialogResult.OK)
                {
                    _enginePath = ofdEngine.FileName;
                    _engineWorkingDir = _enginePath.Substring(0, _enginePath.LastIndexOf('\\')+1);
                }
            }
            if (editor.GetMap(out Map map)) StartProcess();
            else Debug.LogGen(LoggingChannel.ERROR | LoggingChannel.MAIN_EDITOR, "No map loaded");

        }


        void StartProcess(int startIndex = 0)
        {

            if (_engine != null)
            {

                if (!_engine.HasExited) _engine.Kill();

                System.IO.File.Delete(_engine.StartInfo.WorkingDirectory + "mge\\maps\\temp.txt");
            }
            // string relFilepath = GetRelativePath(System.IO.Path.GetFullPath(".\\temp.txt"), _enginePath.Substring(0, _enginePath.LastIndexOf('\\')));
            editor.GetMap(out Map map);
            Map m = map.SubMap(startIndex);
            List<string> tempMap = editor.ExportMap(m);
            string filename = "temp.txt";
            string datapath = _engineWorkingDir + "mge\\maps\\";

            SaveExport(tempMap, datapath + filename);

            _engine = new System.Diagnostics.Process();

            string s = System.IO.Path.GetFullPath(_enginePath);
            System.Diagnostics.ProcessStartInfo psi;
            if (cboxMapMode.SelectedItem.ToString() != "Raw")
            {
                WriteLuaWrapper(datapath, filename, "temp.lua", cbHms.Items[cbHms.SelectedIndex].ToString());
                psi = new System.Diagnostics.ProcessStartInfo(s, "temp.lua");
            }
            else
                psi = new System.Diagnostics.ProcessStartInfo(s, "temp.txt r");

            psi.WorkingDirectory = _engineWorkingDir;
            _engine.StartInfo = psi;
            _engine.Start();


        }

        void WriteLuaWrapper(string datapath, string mapName, string wrapperName, string heightMap)
        {
            List<string> wrapper = new List<string>();
            if (heightMap != "") wrapper.Add("heightTexture = \"" + heightMap + "\"");
            wrapper.Add("map = \"" + mapName + "\"");
            try
            {

                System.IO.TextWriter tr = new System.IO.StreamWriter(datapath + wrapperName);
                for (int i = 0; i < wrapper.Count; i++)
                {
                    tr.WriteLine(wrapper[i]);
                }
                tr.Close();
            }
            catch (Exception)
            {
                Debug.LogGen(LoggingChannel.ERROR | LoggingChannel.MAIN_EDITOR, "Creating lua wrapper failed.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (ofdEngine.ShowDialog() == DialogResult.OK)
            {
                _enginePath = ofdEngine.FileName;
                _engineWorkingDir = _enginePath.Substring(0, _enginePath.LastIndexOf('\\')+1);
                InvalidateEnginePath();
            }
        }

        private void cbRandomizeParts_CheckedChanged(object sender, EventArgs e)
        {
            if (editor.GetMap(out Map map))
            {
                map.SetRandomize(cbRandomizeParts.Checked);
            }
        }

        private void frmEditor_Closing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (!editor.GetMap(out Map map)) return;
            DialogResult res = MessageBox.Show("Unsaved work is about to be lost. Are u sure u want to exit?", "Exit?", MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
                e.Cancel = true;
        }

        private void frmEditor_Closed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            SaveConfig();
            Application.Exit();
        }



        private void btnStartFromSelection_Click(object sender, EventArgs e)
        {
            if (editor.GetMap(out Map map))
            {

                int index = lbMapParts.SelectedIndex;
                if (lbMapParts.SelectedIndex == -1) index = 0;
                StartProcess(index);

            }
            else Debug.LogGen(LoggingChannel.ERROR | LoggingChannel.MAIN_EDITOR, "No map loaded");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (ofdHeightMap.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.Copy(ofdHeightMap.FileName, _engineWorkingDir+ "mge\\textures\\" + ofdHeightMap.FileName.Substring(ofdHeightMap.FileName.LastIndexOf('\\') + 1), true);



                InvalidateHeightmaps();
            }
        }

        void InvalidateEnginePath()
        {
            if (_enginePath.EndsWith("mge.exe") && System.IO.File.Exists(_enginePath))
            {
                btnAddHeightmap.Enabled = true;
                btnPlay.Enabled = true;
                btnStartFromSelection.Enabled = true;
            }
            else
            {
                btnAddHeightmap.Enabled = false;
                btnPlay.Enabled = false;
                btnStartFromSelection.Enabled = false;
            }
            InvalidateHeightmaps();
        }

        private void InvalidateHeightmaps()
        {
            if (System.IO.Directory.Exists(_engineWorkingDir + "\\mge\\textures\\"))
            {
                cbHms.Items.Clear();
                cbHms.Items.Add("NONE");
                foreach (string file in System.IO.Directory.GetFiles(_engineWorkingDir + "\\mge\\textures\\"))
                {
                    cbHms.Items.Add(file.Substring(file.LastIndexOf('\\') + 1));
                }
            }
            else
            {
                Debug.LogGen(LoggingChannel.ERROR | LoggingChannel.MAIN_EDITOR, "Could not load heightmaps. Folder mge/textures does not exist");
            }
            
        }

        private void grpBoxMap_Enter(object sender, EventArgs e)
        {

        }

        private void frmEditor_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            adl.SendToBack(); //Quick hack to make the console appear behind this form.
            CheckForIllegalCrossThreadCalls = true;
        }
    }
}

