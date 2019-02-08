﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using ADL;
using ADL.Streams;
using ADL.Configs;
namespace MapEditor
{
    public partial class frmEditor : Form
    {



        public Editor editor;

        public frmEditor(bool enableLogging)
        {
            InitializeComponent();

            Debug.ADLEnabled = false;
            if (enableLogging)
            {
                PipeStream ps = initADL();

                Debug.ADLEnabled = true;

                CreateADLCustomCMDConfig();

                System.Windows.Forms.Form f =
                ADL.CustomCMD.CMDUtils.CreateCustomConsole(ps);
                Debug.LogGen(LoggingChannel.LOG | LoggingChannel.MAIN_EDITOR, "Initialized Debug Logs.");
            }

            LoadParts(System.IO.Directory.GetFiles(".\\parts", "*.pxml"), out Part[] parts);
            editor = new Editor(parts.ToList());
            InvalidateParts();

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
            config.FrameTime = 50;
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
            editor.GetPartAt(lbParts.SelectedIndex, out Part part);
            if (editor.GetMap(out Map map) && part.IsValid(map.LaneCount, map.PartSize) && editor.AddToMapByIndex(lbMapParts.SelectedIndex, lbParts.SelectedIndex))
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
            if (editor.RemoveFromMapByIndex(lbMapParts.SelectedIndex))
            {
                if (editor.GetMap(out Map map))
                {
                    InvalidateMap(map);
                }
            }

        }

        public void InvalidateMap(Map map)
        {
            lbMapParts.Items.Clear();

            lbMapParts.Items.AddRange(map.PartSequence);
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
            }
        }



        void InvalidateParts()
        {

            lbParts.Items.Clear();
            editor.GetParts(out List<Part> parts);
            foreach (Part part in parts)
            {
                lbParts.Items.Add(part.ToString());
            }

        }

        void PartsDrawItems(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1) return;
            e.DrawBackground();
            Graphics g = e.Graphics;
            Brush available = Brushes.Black;
            Brush unavailable = Brushes.Red;

            if (editor.GetMap(out Map map))
                if (editor.FindAndExportPart(lbParts.Items[e.Index].ToString(), map.LaneCount, map.PartSize, out List<string> export))
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
            PartCreator pc = new PartCreator(new Part());
            if (pc.ShowDialog() == DialogResult.OK)
            {
                editor.LoadPart(pc.GetPart());
                InvalidateParts();
            }

        }

        private void BtneditPart_Click(object sender, EventArgs e)
        {
            if (lbParts.SelectedIndex == -1) return;
            if (editor.GetPartAt(lbParts.SelectedIndex, out Part part))
            {
                PartCreator pc = new PartCreator(part);
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
            List<string> exportString = editor.ExportMap();

            if (sfdExport.ShowDialog() == DialogResult.OK)
            {
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

        #endregion

        private void btnUp_Click(object sender, EventArgs e)
        {
            if(editor.GetMap(out Map map))
            {
                editor.SwapParts(lbMapParts.SelectedIndex, lbMapParts.SelectedIndex - 1);
                InvalidateMap(map);
            }
            
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if (editor.GetMap(out Map map))
            {
                editor.SwapParts(lbMapParts.SelectedIndex, lbMapParts.SelectedIndex + 1);
                InvalidateMap(map);
            }
        }

        private void grpBoxParts_Enter(object sender, EventArgs e)
        {

        }
    }
}

