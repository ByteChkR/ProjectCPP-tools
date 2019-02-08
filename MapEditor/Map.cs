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
        public bool Randomize
        {
            get
            {
                return RandomizePartOrder == 1;
            }
            set
            {
                if (value) RandomizePartOrder = 1;
                else RandomizePartOrder = 0;
            }
        }


        public Map():this(0,0){}
        public Map(int partSize, int laneCount)
        {
            PartSequence = new string[0];
            PartSize = partSize;
            LaneCount = laneCount;
            RandomizePartOrder = 0;
            LaneSteps = new int[LaneCount];
        }

        public bool SelfCheck()
        {
            if (LaneSteps.Length != LaneCount) return false;
            return true;
        }

        public void SwapParts(int one, int two)
        {
            if(one >=0 &&one<PartSequence.Length && two >= 0 &&two<PartSequence.Length && one != two)
            {

                string partone = PartSequence[one];
                PartSequence[one] = PartSequence[two];
                PartSequence[two] = partone;
            }
        }

        public void AddPartAt(int index, Part partToAdd)
        {
            if (index > PartSequence.Length - 1) index = PartSequence.Length - 1;
            if (index == -1) index = 0;
            if (!partToAdd.SelfCheck()) return;
            List<string> tmp = PartSequence.ToList();
            tmp.Insert(index, partToAdd.name);
            PartSequence = tmp.ToArray();
        }

        public void RemovePartAt(int index)
        {
            if (index == -1 || index < PartSequence.Length - 1) return;
            List<string> tmp = PartSequence.ToList();
            tmp.RemoveAt(index);
            PartSequence = tmp.ToArray();
        }


    }
}
