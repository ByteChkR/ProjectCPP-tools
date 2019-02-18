using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor
{
    [Serializable]
    public class Map
    {
        public int PartSize;
        public int LaneCount;
        public int RandomizePartOrder;
        public int[] LaneSteps;
        public string[] PartSequence;

        public float genOffset;
        public float xCurvature;
        public float xCurvatureSmoothness;
        public float heightMapTiling;
        public float heightMapSpeed;
        public float heightMapMaxHeight;
        public float heightMapSamplingWidth;
        public float xMoveTiling;

        public bool GetRandomize()
        {

                return RandomizePartOrder == 1;

                

        }

        public void SetRandomize(bool value)
        {
            if (value) RandomizePartOrder = 1;
            else RandomizePartOrder = 0;
        }


        public Map():this(0,0){}
        public Map(int partSize, int laneCount)
        {
            PartSequence = new string[0];
            PartSize = partSize;
            LaneCount = laneCount;
            RandomizePartOrder = 0;
            LaneSteps = new int[LaneCount];
            genOffset = 75;
            xCurvature = 50;
            xCurvatureSmoothness = 2;
            heightMapTiling = 1;
            heightMapSamplingWidth = 8;
            heightMapSpeed = 0;
            heightMapMaxHeight = 10;
            xMoveTiling = 100;
        }

        public bool SelfCheck()
        {
            if (LaneSteps.Length != LaneCount) return false;
            return true;
        }

        public Map SubMap(int startIndex)
        {
            Map m = new Map(PartSize, LaneCount);
            m.LaneSteps = LaneSteps;
            m.RandomizePartOrder = RandomizePartOrder;
            m.PartSequence = new string[PartSequence.Length - startIndex];
            for (int i = 0; i < m.PartSequence.Length; i++)
            {
                m.PartSequence[i] = PartSequence[startIndex + i];
            }
            return m;
        }

        public bool SwapParts(int one, int two)
        {
            if(one >=0 &&one<PartSequence.Length && two >= 0 &&two<PartSequence.Length && one != two)
            {

                string partone = PartSequence[one];
                PartSequence[one] = PartSequence[two];
                PartSequence[two] = partone;
                return true;
            }
            return false;
        }

        public void AddPartAt(int index, Part partToAdd)
        {
            if (index > PartSequence.Length - 1) index = PartSequence.Length - 1;
            if (!partToAdd.SelfCheck()) return;
            List<string> tmp = PartSequence.ToList();
            if (index < 0)
                tmp.Add(partToAdd.name);
            else
                tmp.Insert(index, partToAdd.name);
            PartSequence = tmp.ToArray();
        }

        public void RemovePartAt(int index)
        {
            if (index == -1 || index > PartSequence.Length - 1) return;
            List<string> tmp = PartSequence.ToList();
            tmp.RemoveAt(index);
            PartSequence = tmp.ToArray();
        }


    }
}
