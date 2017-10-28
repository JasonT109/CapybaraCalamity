using UnityEngine;
using System.Collections;

namespace mapping
{
    [System.Serializable]
    public class mapLoadData
    {
        public int PositionX;
        public int PositionY;
        public int Content;

        public static mapLoadData CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<mapLoadData>(jsonString);
        }
    }
}
