using System;
using System.Collections.Generic;
using System.Linq;
using ADL;
using ADL.Configs;
using ADL.Streams;

namespace MapEditor
{
    public class Editor
    {
        private List<Part> parts = new List<Part>();
        private Map _currentMap = null;

        public Editor(List<Part> initparts)
        {

            foreach (Part part in initparts)
            {
                LoadPart(part);
            }
        }


        #region IO

        #region PartIO
        public bool LoadPart(Part file)
        {
            bool ok = file.SelfCheck();
            parts.Add(file);
            parts.OrderBy(x => x.name);
            if (ok) Debug.LogGen<LoggingChannel>(LoggingChannel.LOG | LoggingChannel.MAIN_EDITOR, "Loaded " + file);
            else
            {
                Debug.LogGen<LoggingChannel>(LoggingChannel.WARNING | LoggingChannel.MAIN_EDITOR, "Could not load " + file);
                return false;
            }
            return true;
        }

        public bool GetParts(out List<Part> part)
        {
            part = parts;
            return true;
        }

        public bool SwapParts(int one, int two)
        {
            return _currentMap.SwapParts(one, two);
        }

        public bool GetPartAt(int index, out Part part)
        {
            if (index != -1 && index < parts.Count && index >= 0)
            {
                part = parts[index];
                return true;
            }
            Debug.LogGen<LoggingChannel>(LoggingChannel.WARNING | LoggingChannel.MAIN_EDITOR, "No Part selected");
            part = new Part();
            return false;
        }

        public bool FindPart(string name, int laneCount, int partSize, out Part part)
        {
            for (int i = 0; i < parts.Count; i++)
            {
                if (parts[i].name == name && parts[i].laneCount == laneCount && parts[i].Divisible(partSize))
                {
                    part = parts[i];
                    return true;
                }
            }
            part = new Part();
            return false;
        }

        public bool FindAndExportPart(string name, int laneCount, int partSize, out List<string> export, out List<string> biomeIDs, bool debug = true)
        {
            if (FindPart(name, laneCount, partSize, out Part partz) && ExportPart(partz, partSize, out export, out biomeIDs))
            {
                return true;

            }
            else
            {
                export = Part.Dummy(laneCount, partSize);
                biomeIDs = new List<string>() { "0" };
                return false;
            }



        }

        public bool ExportPart(Part p, int targetSize, out List<string> export, out List<string> biomeIDs, bool debug = true)
        {
            biomeIDs = new List<string>();
            if (p.DivisionCount(targetSize) != 1)
            {
                if (debug) Debug.LogGen(LoggingChannel.LOG | LoggingChannel.MAIN_EDITOR, "Dividing part into" + p.partLength / targetSize + " Sub Parts");
                List<List<string>> part = p.ExportDivided(targetSize);
                export = new List<string>();

                for (int j = 0; j < part.Count; j++)
                {
                    if (j != 0) export.Add("");
                    export.AddRange(part[j]);
                    biomeIDs.Add(p.biomeID.ToString());
                }
            }
            else
            {

                biomeIDs.Add(p.biomeID.ToString());
                export = p.ToEditFormat();
            }
            return true;
        }

        #endregion

        #region MapIO

        public List<string> ExportMap(Map m)
        {
            Debug.LogGen(LoggingChannel.LOG | LoggingChannel.MAIN_EDITOR, "Compiling Map..");
            Debug.LogGen(LoggingChannel.LOG | LoggingChannel.MAIN_EDITOR, "Constructing Header..");
            List<string> exportString = new List<string>
            {
                m.RandomizePartOrder.ToString(),
                "",
                m.PartSize.ToString(),
                "",
                m.LaneCount.ToString()
            };
            for (int i = 0; i < m.LaneSteps.Length; i++)
            {
                exportString.Add(m.LaneSteps[i].ToString());
            }

            Debug.LogGen(LoggingChannel.LOG | LoggingChannel.MAIN_EDITOR, "Constructing Header.. DONE!");
            Debug.LogGen(LoggingChannel.LOG | LoggingChannel.MAIN_EDITOR, "Constructing Parts..");

            int totalPartCount = GetTotalParts(m);

            exportString.Add("");
            exportString.Add(totalPartCount.ToString());
            exportString.Add("");

            int biomeIndex = exportString.Count;
            Debug.LogGen(LoggingChannel.LOG | LoggingChannel.MAIN_EDITOR, "Biome Index ->" + biomeIndex);

            Debug.LogGen(LoggingChannel.LOG | LoggingChannel.MAIN_EDITOR, "Compiling " + totalPartCount + " Parts");
            List<string> biomes = new List<string>();

            for (int i = 0; i < m.PartSequence.Length; i++)
            {

                exportString.Add("");

                if (!FindAndExportPart(m.PartSequence[i], m.LaneCount, m.PartSize, out List<string> col, out List<string> bids))
                    Debug.LogGen(LoggingChannel.WARNING | LoggingChannel.MAIN_EDITOR, "Tried to load part with lane & part count that could not be found in the loaded parts" + _currentMap.PartSequence[i] + " LC: " + _currentMap.LaneCount + " PC: " + _currentMap.PartSize);
                biomes.AddRange(bids);
                exportString.AddRange(col);
            }
            exportString.Add("");
            Debug.LogGen(LoggingChannel.LOG | LoggingChannel.MAIN_EDITOR, "Constructing Parts.. DONE!");
            Debug.LogGen(LoggingChannel.LOG | LoggingChannel.MAIN_EDITOR, "Constructing Biomes..");



            for (int i = biomes.Count - 1; i >= 0; i--)
            {
                exportString.Insert(biomeIndex, biomes[i]);
            }

            Debug.LogGen(LoggingChannel.LOG | LoggingChannel.MAIN_EDITOR, "Constructing Biomes.. DONE!");

            Debug.LogGen(LoggingChannel.LOG | LoggingChannel.MAIN_EDITOR, "Compiling Map.. DONE!");



            return exportString;
        }

        public int GetTotalParts(Map m)
        {
            int part = 0;
            for (int i = 0; i < m.PartSequence.Length; i++)
            {
                if (FindPart(m.PartSequence[i], m.LaneCount, m.PartSize, out Part prt))
                {
                    part += prt.DivisionCount(m.PartSize);
                }
            }
            return part;
        }

        public List<string> ExportMap()
        {
            return ExportMap(_currentMap);
        }

        public bool GetMap(out Map map)
        {
            if (_currentMap == null)
            {
                //Debug.LogGen(LoggingChannel.WARNING | LoggingChannel.MAIN_EDITOR, "Editor tried to access map that has not been crated yet");
                map = null;
                return false;
            }
            map = _currentMap;
            return true;
        }

        public bool LoadMap(Map map)
        {

            Debug.LogGen(LoggingChannel.MAIN_EDITOR | LoggingChannel.LOG,
                        "Loading Map..");

            if (map != null)
            {
                Debug.LogGen(LoggingChannel.MAIN_EDITOR | LoggingChannel.LOG,
                        "Performing selfcheck on Map..");
                if (!map.SelfCheck())
                {
                    Debug.LogGen(LoggingChannel.MAIN_EDITOR | LoggingChannel.WARNING,
                        "Map Self Check Failed. Trying to load map.");
                }
                for (int i = 0; i < map.PartSequence.Length; i++)
                {
                    if (!FindPart(map.PartSequence[i], map.LaneCount, map.PartSize, out Part part))
                    {
                        Debug.LogGen(LoggingChannel.MAIN_EDITOR | LoggingChannel.WARNING, "Could not find correct part for item(part will be zero filled) : " + map.PartSequence[i] +
                            "\nCheck Lane Count and Part Size in the object.");
                    }

                }
                _currentMap = map;
                Debug.LogGen(LoggingChannel.MAIN_EDITOR | LoggingChannel.LOG, "MapLoaded.");
                return true;
            }
            Debug.LogGen(LoggingChannel.MAIN_EDITOR | LoggingChannel.ERROR, "Map has no value.");
            return false;
        }

        #endregion

        #endregion

        public bool AddToMapByIndex(int indexInMap, int indexOfPart)
        {

            if (_currentMap != null && indexOfPart >= 0 && indexOfPart < parts.Count)
            {
                _currentMap.AddPartAt(indexInMap, parts[indexOfPart]);

                return true;
            }
            Debug.LogGen(LoggingChannel.MAIN_EDITOR | LoggingChannel.ERROR, "Could not add to map.");
            return false;
        }

        public bool RemoveFromMapByIndex(int indexInMap)
        {
            if (_currentMap != null && indexInMap < _currentMap.PartSequence.Length && indexInMap >= 0)
            {
                _currentMap.RemovePartAt(indexInMap);
                return true;
            }
            Debug.LogGen(LoggingChannel.MAIN_EDITOR | LoggingChannel.ERROR, "Invalid Action. Map was not created or selected index(" + indexInMap + ") is out of bounds");
            return false;
        }

        public List<Part> GetPartsWithConfiguration(int laneCount, int partSize)
        {
            return parts.Where(x => x.laneCount == laneCount && x.partLength == partSize).ToList();
        }

        public bool ContainsPart(string name, out Part result, int laneCount = -1, int partSize = -1)
        {
            foreach (Part part in parts)
            {
                if (part.name == name && (part.partLength == partSize || partSize == -1) && (part.laneCount == laneCount || laneCount == -1))
                {
                    result = part;
                    return true;
                }
            }
            result = null;
            return false;
        }
    }
}
