using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MapEditor
{
    [Serializable]
    public class Part
    {
        public string name;
        public int partLength;
        public int laneCount;
        public int[][] part;


        public override string ToString()
        {
            return name;
        }

        public bool Divisible(int targetSize)
        {
            return partLength % targetSize == 0 && partLength != 0;
        }

        public List<List<string>> ExportDivided(int targetSize)
        {
            if (!Divisible(targetSize)) return new List<List<string>>();

            List<List<string>> ret = new List<List<string>>();
            string sep = "";
            for (int x = 0; x < partLength / targetSize; x++)
            {
                ret.Add(new List<string>());
                for (int i = 0; i < laneCount; i++)
                {
                    ret[x].Add("");
                    for (int j = 0; j < targetSize; j++)
                    {
                        sep = (j == partLength - 1) ? "" : " ";
                        ret[x][i] += part[i][j] + sep;
                    }
                }
            }
            return ret;

        }

        public static Part Copy(Part other)
        {

            Part p = new Part();
            p.laneCount = other.laneCount;
            p.name = other.name + "(COPY)";
            p.partLength = other.partLength;
            p.part = new int[p.laneCount][];
            for (int i = 0; i < p.laneCount; i++)
            {
                p.part[i] = new int[p.partLength];
                for (int j = 0; j < p.part[i].Length; j++)
                {
                    p.part[i][j] = other.part[i][j];
                }
            }
            return p;
        }

        public bool SelfCheck()
        {
            if (part == null) return false;
            if (part.Length != laneCount) return false;
            for (int i = 0; i < part.Length; i++)
            {
                if (part[i].Length != partLength) return false;
            }
            return true;

        }

        public bool IsValid(int laneCount, int partLength)
        {
            return laneCount == this.laneCount && Divisible(partLength);
        }

        public static List<string> Dummy(int lanes, int size)
        {
            Part p = new Part
            {
                laneCount = lanes,
                partLength = size
            };
            p.part = new int[p.laneCount][];
            for (int i = 0; i < p.part.Length; i++)
            {
                p.part[i] = new int[p.partLength];
            }
            return p.ToEditFormat();
        }

        public List<string> ToEditFormat()
        {
            List<string> ret = new List<string>();
            string sep = "";
            for (int i = 0; i < laneCount; i++)
            {
                ret.Add("");
                for (int j = 0; j < partLength; j++)
                {
                    sep = (j == partLength - 1) ? "" : " ";
                    ret[i] += part[i][j] + sep;
                }
            }
            return ret;
        }


    }
}
