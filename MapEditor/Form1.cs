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
        string heightmap = "";
        string horizonMap = "";
        string groundMap = "";
        string groundNormalMap = "";
        bool isRaw = true;
        EngineSettings es;
        editorConfig ec;
        GameConsoleRedirector gcr = null;
        ADL.CustomCMD.CustomCMDForm adl;

        public frmEditor(bool enableLogging, string initMap = "")
        {

            InitializeComponent();

            AllowDrop = true;

            ReadConfig();



            Debug.ADLEnabled = false;
            if (enableLogging)
            {
                PipeStream ps = initADL();

                Debug.ADLEnabled = true;

                //CreateADLCustomCMDConfig();

                adl = (ADL.CustomCMD.CustomCMDForm)ADL.CustomCMD.CMDUtils.CreateCustomConsole(ps);

                adl.MaxConsoleLogCount = 5000; //Custom Changes to Console Window to delete the console output less often and
                adl.MaxLogCountPerBlock = 2500; //Set this higher when changing the max log count per frame
                adl.MaxLogCountPerFrame = 500; //fix the ADL warnings when overusing the ADL System.

                adl.FormClosing += new FormClosingEventHandler(ConsoleClosing);

                Debug.LogGen(LoggingChannel.LOG | LoggingChannel.MAIN_EDITOR, "Initialized Debug Logs.");
            }
            if (System.IO.Directory.Exists(_defaultPartFolder))
            {
                LoadParts(System.IO.Directory.GetFiles(_defaultPartFolder, "*.pxml"), out List<Part> parts);
                editor = new Editor(parts);
                InvalidateParts();
            }
            else
            {
                editor = new Editor(new List<Part>());
            }

            if (System.IO.File.Exists(initMap) && LoadMap(initMap, out Map m) && editor.LoadMap(m))
            {
                Debug.LogGen(LoggingChannel.LOG | LoggingChannel.GENERAL, "CLI Argument given:" + initMap);
                InvalidateMap(m);
            }
            else if (initMap != "")
            {
                Debug.LogGen(LoggingChannel.ERROR | LoggingChannel.GENERAL, "CLI Argument given:" + initMap + " not found or not a valid map file.");
            }

        }

        private void ConsoleClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !closeConsole;
            if (!closeConsole) adl.Hide();
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
                        {1024, System.Drawing.Color.Lime },
                        {2048, System.Drawing.Color.Red }
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
            for (int i = 0; i < lbParts.SelectedIndices.Count; i++)
            {
                if (editor.GetMap(out Map map) && editor.GetPartAt(lbParts.SelectedIndices[i], out Part part) && part.IsValid(map.LaneCount, map.PartSize) && editor.AddToMapByIndex(lbMapParts.SelectedIndex, lbParts.SelectedIndices[i]))
                {

                    InvalidateMap(map);
                }
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
                for (int i = lbMapParts.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    int idx = lbMapParts.SelectedIndices[i];
                    if (editor.RemoveFromMapByIndex(idx))
                    {

                    }

                }
                InvalidateMap(map, new int[0]);
                lbMapParts.Focus();
            }

        }

        public void InvalidateMap(Map map, int[] selectedIndices = null)
        {
            int max = lbMapParts.Items.Count;
            numericUpDown1.Value = (map.LaneSteps != null && map.LaneSteps.Length < 0) ? map.LaneSteps[0] : 3;
            int[] index = selectedIndices != null ? selectedIndices : lbMapParts.SelectedIndices.Cast<int>().ToArray();
            lbMapParts.Items.Clear();

            lbMapParts.Items.AddRange(map.PartSequence);
            if (lbMapParts.Items.Count >= max)
                foreach (int idx in index)
                {
                    lbMapParts.SetSelected(idx, true);
                }
        }

        private void BtnOpenPartFile_Click(object sender, EventArgs e)
        {
            if (ofdPart.ShowDialog() == DialogResult.OK)
            {
                string[] s = ofdPart.FileNames.Where(x => !x.StartsWith(System.IO.Path.GetFullPath(_defaultPartFolder))).ToArray();
                LoadParts(s, out List<Part> newParts);
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

            PartCreator pc = new PartCreator(pFinal, false, _biomeCount, _defaultPartFolder);
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
                    if (editor.GetMap(out Map map)) InvalidateMap(map);
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

            if (editor.GetMap(out Map map) && sfd.ShowDialog() == DialogResult.OK)
            {
                SaveMap(sfd.FileName, map);
            }
        }



        private void Button2_Click(object sender, EventArgs e)
        {
            if (editor.GetMap(out Map map) && sfdExport.ShowDialog() == DialogResult.OK)
            {
                List<string> exportString = editor.ExportMap();
                string dataPath = sfdExport.FileName.Substring(0, sfdExport.FileName.LastIndexOf('\\') + 1);
                string mapName = sfdExport.FileName.Substring(sfdExport.FileName.LastIndexOf('\\') + 1);

                WriteLuaWrapper(dataPath, mapName, mapName.Replace(".txt", ".lua"), heightmap, groundMap, groundNormalMap, horizonMap,
                    map.genOffset, map.xCurvature, map.xCurvatureSmoothness,
                    map.heightMapTiling, map.heightMapSpeed,
                    map.heightMapMaxHeight, map.heightMapSamplingWidth,
                    map.xMoveTiling, map.fogColorR, map.fogColorG, map.fogColorB);

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
                    map.LaneSteps = new int[map.LaneCount];
                    for (int i = 0; i < map.LaneCount; i++)
                    {
                        map.LaneSteps[i] = (int)numericUpDown1.Value;
                    }
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
                if (System.IO.File.Exists(file))
                    System.IO.File.Delete(file);
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
        bool LoadParts(string[] files, out List<Part> newParts)
        {
            newParts = new List<Part>();
            bool result = true;
            for (int i = 0; i < files.Length; i++)
            {
                if (LoadPart(files[i], out Part p))
                {
                    newParts.Add(p);
                }
                else
                {
                    result = false;
                }
            }

            Debug.LogGen<LoggingChannel>(LoggingChannel.LOG | LoggingChannel.MAIN_EDITOR, "Loaded " + newParts.Count + " new Parts from XML");
            if (!result) Debug.LogGen<LoggingChannel>(LoggingChannel.WARNING | LoggingChannel.MAIN_EDITOR, "Completed with errors");

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

            ec = editorConfig.GetStandard();
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
            string texPath = "";
            if (System.IO.File.Exists(ec.EnginePath))
            {
                _enginePath = ec.EnginePath;
                _engineWorkingDir = _enginePath.Substring(0, _enginePath.LastIndexOf('\\') + 1);
                if (System.IO.Directory.Exists(_engineWorkingDir + "mge\\textures\\")) texPath = _engineWorkingDir + "mge\\textures\\";

            }
            _defaultPartFolder = ec.DefaultPartsFolder;
            isRaw = ec.isRaw;
            es = new EngineSettings(texPath, ec);
            heightmap = es.GetHeight();
            horizonMap = es.GetHorizon();
            groundMap = es.GetGround();
            groundNormalMap = es.GetGroundNormal();
            InvalidateEnginePath();

        }

        void SaveConfig()
        {
            XmlSerializer xs = new XmlSerializer(typeof(editorConfig));

            editorConfig ec = es.GetConfig();
            ec.EnginePath = _enginePath;
            ec.DefaultPartsFolder = _defaultPartFolder;
            ec.biomeCount = _biomeCount;
            ec.isRaw = isRaw;

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
                int[] newIndices = new int[lbMapParts.SelectedIndices.Count];
                for (int i = 0; i < lbMapParts.SelectedIndices.Count; i++)
                {
                    int idx = lbMapParts.SelectedIndices[i];
                    if (editor.SwapParts(idx, idx - 1))
                        newIndices[i] = idx - 1;
                    else
                        newIndices[i] = idx;
                }
                InvalidateMap(map, newIndices);
            }

        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (editor.GetMap(out Map map))
            {
                int[] newIndices = new int[lbMapParts.SelectedIndices.Count];
                for (int i = lbMapParts.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    int idx = lbMapParts.SelectedIndices[i];
                    if (editor.SwapParts(idx, idx + 1))
                        newIndices[i] = idx + 1;
                    else
                        newIndices[i] = idx;
                }
                InvalidateMap(map, newIndices);

            }
        }

        private void grpBoxParts_Enter(object sender, EventArgs e)
        {

        }

        private void frmEditor_Drop(object sender, DragEventArgs e)
        {
            List<string> parts = new List<string>();
            string map = "";
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] path = (string[])e.Data.GetData(DataFormats.FileDrop, true);
                for (int i = 0; i < path.Length; i++)
                {
                    if (path[i].EndsWith(".pxml"))
                    {
                        parts.Add(path[i]);
                        Debug.LogGen(LoggingChannel.LOG | LoggingChannel.MAIN_EDITOR, "Drag Drop operation contains parts. Loading parts");

                    }
                    else if (map == "" && path[i].EndsWith(".mxml"))
                    {
                        map = path[i];
                        Debug.LogGen(LoggingChannel.LOG | LoggingChannel.MAIN_EDITOR, "Drag Drop operation contains one map. Loading Map");

                    }
                    else if (path[i].EndsWith(".mxml"))
                    {
                        Debug.LogGen(LoggingChannel.WARNING | LoggingChannel.MAIN_EDITOR, "Drag Drop operation contains more than one map. Only the first map gets loaded.");
                    }
                    else
                    {
                        Debug.LogGen(LoggingChannel.ERROR | LoggingChannel.MAIN_EDITOR, "Drag Drop operation contains one or more unknown file types. Skipping..");

                    }
                }

            }


            if (map != "" && LoadMap(map, out Map pmap) && editor.LoadMap(pmap))
            {
                Debug.LogGen(LoggingChannel.LOG | LoggingChannel.MAIN_EDITOR, "Map :" + map + " loaded");

                InvalidateMap(pmap);
            }
            if (parts.Count > 0 && LoadParts(parts.ToArray(), out List<Part> pparts))
            {
                foreach (Part part in pparts)
                {
                    editor.LoadPart(part);
                }
                InvalidateParts();
                if (editor.GetMap(out Map m)) InvalidateMap(m);
            }
        }

        private void frmEditor_DropEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (_enginePath == "")
            {
                if (ofdEngine.ShowDialog() == DialogResult.OK)
                {
                    _enginePath = ofdEngine.FileName;
                    _engineWorkingDir = _enginePath.Substring(0, _enginePath.LastIndexOf('\\') + 1);
                }
            }
            if (editor.GetMap(out Map map)) StartProcess();
            else Debug.LogGen(LoggingChannel.ERROR | LoggingChannel.MAIN_EDITOR, "No map loaded");

        }


        void StartProcess(int startIndex = 0)
        {

            if (_engine != null)
            {

                if (gcr != null) gcr.StopThreads();
                if (!_engine.HasExited) _engine.Kill();

                System.IO.File.Delete(_engine.StartInfo.WorkingDirectory + "mge\\maps\\temp.txt");
            }
            string startParams = "";
            if (cbEngineMode.SelectedIndex == -1 || cbEngineMode.SelectedIndex == 0)
            {
                startParams = " -forceWindow -res 900 600 -editor";
            }
            else if (cbEngineMode.SelectedIndex == 1)
            {
                startParams = " -windowMode 0 -res 1920 1080 -editor";
            }
            else if (cbEngineMode.SelectedIndex == 2)
            {
                startParams = " -forceWindow -res 900 600";
            }
            else if (cbEngineMode.SelectedIndex == 3)
            {
                startParams = " -windowMode 0 -res 1920 1080";
            }
            else if (cbEngineMode.SelectedIndex == 4)
            {
                startParams = " -s";
            }

            editor.GetMap(out Map map);
            Map m = map.SubMap(startIndex);
            List<string> tempMap = editor.ExportMap(m);
            string filename = "temp.txt";
            string datapath = _engineWorkingDir + "mge\\maps\\";

            SaveExport(tempMap, datapath + filename);

            _engine = new System.Diagnostics.Process();

            string s = System.IO.Path.GetFullPath(_enginePath);
            System.Diagnostics.ProcessStartInfo psi;


            if (!isRaw)
            {
                WriteLuaWrapper(datapath, filename, "temp.lua", heightmap, groundMap, groundNormalMap, horizonMap,
                    map.genOffset, map.xCurvature, map.xCurvatureSmoothness,
                    map.heightMapTiling, map.heightMapSpeed,
                    map.heightMapMaxHeight, map.heightMapSamplingWidth,
                    map.xMoveTiling, map.fogColorR, map.fogColorG, map.fogColorB);
                filename = "temp.lua";
            }
            string fullpath = System.IO.Path.GetFullPath(datapath);
            string startPars = " -l \"" + fullpath + filename + "\"" + startParams + " -enableCheats";
            Debug.LogGen(LoggingChannel.LOG, startPars);
            psi = new System.Diagnostics.ProcessStartInfo(s, startPars);

            psi.WorkingDirectory = _engineWorkingDir;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.UseShellExecute = false;

            _engine.StartInfo = psi;
            try
            {
                _engine.Start();
                gcr = GameConsoleRedirector.CreateRedirector(_engine.StandardOutput, _engine.StandardError, _engine);
                gcr.StartThreads();


            }
            catch (Exception)
            {
                MessageBox.Show("Error, could not run mge.exe at path " + _enginePath);
                Debug.LogGen(LoggingChannel.ERROR | LoggingChannel.GENERAL, "Error, could not run mge.exe at path " + _enginePath);
            }

        }

        void WriteLuaWrapper(string datapath, string mapName, string wrapperName, string heightMap, string groundTex, string groundNormal, string horizonTex, float genOffset, float xCurvature, float xCurvatureSmoothness, float heightMapTiling, float heightMapSpeed, float heightMapMaxHeight, float heightMapSamplingWidth, float xMoveTiling, float fogColorR, float fogColorG, float fogColorB)
        {
            List<string> wrapper = new List<string>();
            if (heightMap != "") wrapper.Add("heightTexture = \"" + heightMap + "\"");
            wrapper.Add("map = \"" + mapName + "\"");
            if (groundTex != "") wrapper.Add("ground = \"" + horizonTex + "\"");
            if (groundTex != "") wrapper.Add("mapGround = \"" + groundTex + "\"");
            if (groundTex != "") wrapper.Add("mapGroundNormal = \"" + groundNormal + "\"");
            wrapper.Add("genOffset = \"" + genOffset + "\"");
            wrapper.Add("xCurvature = \"" + xCurvature + "\"");
            wrapper.Add("xCurvatureSmoothness = \"" + xCurvatureSmoothness + "\"");
            wrapper.Add("heightMapTiling = \"" + heightMapTiling + "\"");
            wrapper.Add("heightMapSpeed = \"" + heightMapSpeed + "\"");
            wrapper.Add("heightMapMaxHeight = \"" + heightMapMaxHeight + "\"");
            wrapper.Add("heightMapSamplingWidth = \"" + heightMapSamplingWidth + "\"");
            wrapper.Add("xMoveTiling = \"" + xMoveTiling + "\"");
            wrapper.Add("fogColor = {[\"Red\"] = \"" + fogColorR.ToString().Replace(',', '.') + "\" , [\"Green\"] = \"" + fogColorG.ToString().Replace(',', '.') + "\" , [\"Blue\"] = \"" + fogColorB.ToString().Replace(',', '.') + "\"}");
            try
            {

                System.IO.TextWriter tr = new System.IO.StreamWriter(datapath + wrapperName, false);
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
                _engineWorkingDir = _enginePath.Substring(0, _enginePath.LastIndexOf('\\') + 1);
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


        bool closeConsole = false;
        void CloseADL()
        {
            closeConsole = true;

        }

        private void frmEditor_Closing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            CloseADL();

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
                System.IO.File.Copy(ofdHeightMap.FileName, _engineWorkingDir + "mge\\textures\\" + ofdHeightMap.FileName.Substring(ofdHeightMap.FileName.LastIndexOf('\\') + 1), true);



                InvalidateHeightmaps();
            }
        }

        void InvalidateEnginePath()
        {
            if (_enginePath.EndsWith("mge.exe") && System.IO.File.Exists(_enginePath))
            {
                btnPlay.Enabled = true;
                btnStartFromSelection.Enabled = true;
            }
            else
            {
                btnPlay.Enabled = false;
                btnStartFromSelection.Enabled = false;
            }
            InvalidateHeightmaps();
        }

        private void InvalidateHeightmaps()
        {
            if (System.IO.Directory.Exists(_engineWorkingDir + "\\mge\\textures\\"))
            {
                es.InvalidateCombos();

            }
            else
            {
                Debug.LogGen(LoggingChannel.ERROR | LoggingChannel.MAIN_EDITOR, "Could not load heightmaps. Folder mge/textures does not exist");
            }

        }



        private void frmEditor_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            adl.Hide(); //Quick hack to make the console appear behind this form.
            CheckForIllegalCrossThreadCalls = true;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Map m;
            if (editor.GetMap(out m))
                es.SetMap(m);
            if (es.ShowDialog() == DialogResult.OK)
            {
                heightmap = es.GetHeight();
                groundMap = es.GetGround();
                horizonMap = es.GetHorizon();
                groundNormalMap = es.GetGroundNormal();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (editor.GetMap(out Map map))
            {
                map.LaneSteps = new int[map.LaneCount];
                for (int i = 0; i < map.LaneCount; i++)
                {
                    map.LaneSteps[i] = (int)numericUpDown1.Value;
                }

            }
        }

        private void lbMapParts_DoubleClickLoseSelectedIndex(object sender, EventArgs e)
        {
            lbMapParts.SelectedIndex = -1;
        }

        private void lbParts_DoubleClickLoseSelectedIndex(object sender, EventArgs e)
        {
            lbParts.SelectedIndex = -1;
        }

        private void btnOpenConsole_Click(object sender, EventArgs e)
        {
            if (adl != null)
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                adl.Show();
                Control.CheckForIllegalCrossThreadCalls = true;
            }
        }

        private void btnRandomizeSelection_Click(object sender, EventArgs e)
        {
            if (editor.GetMap(out Map map))
            {

                List<string> selection = new List<string>();

                if (lbMapParts.SelectedIndices.Count > 0)
                {
                    foreach (int idx in lbMapParts.SelectedIndices)
                    {
                        selection.Add(lbMapParts.Items[idx].ToString());
                    }
                }
                else
                {
                    selection = lbMapParts.Items.Cast<string>().ToList();
                }

                selection.Shuffle();

                for (int i = 0; i < lbMapParts.SelectedIndices.Count; i++)
                {
                    map.PartSequence[lbMapParts.SelectedIndices[i]] = selection[i];
                }
                InvalidateMap(map);
            }
        }

        private void btnTmpExport_Click(object sender, EventArgs e)
        {
            if (editor.GetMap(out Map m))
            {
                Debug.LogGen(LoggingChannel.LOG, "Exporting to engine path as temp.lua.");
                Debug.LogGen(LoggingChannel.LOG, "To Reload while the game is running please press NUMPAD4");
                List<string> tempMap = editor.ExportMap(m);
                string filename = "temp.txt";
                string datapath = _engineWorkingDir + "mge\\maps\\";

                if (System.IO.File.Exists(datapath + filename)) System.IO.File.Delete(datapath + filename);
                SaveExport(tempMap, datapath + filename);

            }
        }
    }
}

