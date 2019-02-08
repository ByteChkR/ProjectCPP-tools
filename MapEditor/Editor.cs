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

        public bool FindAndExportPart(string name, int laneCount, int partSize, out List<string> export, bool debug = true)
        {
            for (int i = 0; i < parts.Count; i++)
            {
                if (parts[i].name == name && parts[i].laneCount == laneCount && parts[i].Divisible(partSize))
                {
                    if (partSize == parts[i].partLength)
                        export = parts[i].ToEditFormat();
                    else
                    {
                        if(debug)Debug.LogGen(LoggingChannel.LOG | LoggingChannel.MAIN_EDITOR, "Dividing part into" + parts[i].partLength / partSize + " Sub Parts");
                        List<List<string>> part = parts[i].ExportDivided(partSize);
                        export = new List<string>();

                        for (int j = 0; j < part.Count; j++)
                        {
                            if(debug)Debug.LogGen(LoggingChannel.LOG | LoggingChannel.MAIN_EDITOR, "Compiling sub-part " + j);
                            if (j != 0) export.Add("");
                            export.AddRange(part[j]);
                        }
                    }
                    return true;
                }
            }
            export = Part.Dummy(laneCount, partSize);
            return false;
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

            exportString.Add("");
            exportString.Add(m.PartSequence.Length.ToString());


            for (int i = 0; i < m.PartSequence.Length; i++)
            {
                Debug.LogGen(LoggingChannel.LOG | LoggingChannel.MAIN_EDITOR, "Compiling Part " + i);
                exportString.Add("");
                if (!FindAndExportPart(m.PartSequence[i], m.LaneCount, m.PartSize, out List<string> col))
                    Debug.LogGen(LoggingChannel.WARNING | LoggingChannel.MAIN_EDITOR, "Tried to load part with lane & part count that could not be found in the loaded parts" + _currentMap.PartSequence[i] + " LC: " + _currentMap.LaneCount + " PC: " + _currentMap.PartSize);

                exportString.AddRange(col);
            }
            exportString.Add("");
            Debug.LogGen(LoggingChannel.LOG | LoggingChannel.MAIN_EDITOR, "Constructing Parts.. DONE!");
            Debug.LogGen(LoggingChannel.LOG | LoggingChannel.MAIN_EDITOR, "Compiling Map.. DONE!");
            return exportString;
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
                        "Adding Map..");

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
                    if (!FindAndExportPart(map.PartSequence[i], map.LaneCount, map.PartSize, out List<string> export))
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
