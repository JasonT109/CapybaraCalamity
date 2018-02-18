using UnityEngine;
using System.Collections;

namespace mapping
{
    public class mapSaveData
    {
        public int PositionX;
        public int PositionY;
        public int SizeX;
        public int SizeY;
        public int Content;

        public string SaveToString()
        {
            return JsonUtility.ToJson(this);
        }
    }
}
