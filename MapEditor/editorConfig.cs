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
        public string HeightMap;
        public int biomeCount;


        public static editorConfig GetStandard()
        {
            editorConfig ec = new editorConfig();
            ec.EnginePath = "";
            ec.DefaultPartsFolder = ".\\parts\\";
            ec.HeightMap = "";
            ec.biomeCount = 1;
            return ec;
        }
    }
}
