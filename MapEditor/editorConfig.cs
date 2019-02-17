using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace MapEditor
{
    [Serializable]
    public class editorConfig
    {
        public string EnginePath;
        public string DefaultPartsFolder;
        public int HeightMap;
        public int GroundMap;
        public int HorizonMap;
        public int biomeCount;
        public bool isRaw;



        public static editorConfig GetStandard()
        {
            editorConfig ec = new editorConfig();
            ec.EnginePath = "";
            ec.DefaultPartsFolder = ".\\parts\\";
            ec.HeightMap = 0;
            ec.biomeCount = 1;
            ec.HorizonMap = 0;
            ec.GroundMap = 0;
            ec.isRaw = true;
            return ec;
        }
    }
}
