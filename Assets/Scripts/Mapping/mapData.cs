using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace mapping
{
    public class mapData : MonoBehaviour
    {
        public string mapName = "newMap1";
        public Vector2 gridSize;
        public List<gridPiece> gridData = new List<gridPiece>();

        private string path = "Assets/Resources/";

        ///load data from file, returns true if map data found
        public bool ReadMapData()
        {
            StreamReader reader = new StreamReader(path + mapName + ".json", true);

            if (reader != null)
            {
                while (reader.Peek() >= 0)
                {
                    //get info from json file
                    
                    string line = reader.ReadLine();
                    Debug.Log("Line:" + line);
                    mapLoadData InputData = mapLoadData.CreateFromJSON(line);
                    Debug.Log("Read data from file:" + InputData.Content);

                    //add to new gridPiece
                    gridPiece InputPiece = new gridPiece();
                    InputPiece.gPosition.x = InputData.PositionX;
                    InputPiece.gPosition.y = InputData.PositionY;
                    InputPiece.gContents = (mapGrid.Contents)InputData.Content;
                    gridData.Add(InputPiece);
                }
                reader.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        ///save data to file
        public void WriteMapData()
        {
            if (mapName != "")
            {
                StreamWriter writer = new StreamWriter(path + mapName + ".json", true);

                for (int i = 0; i < gridData.Count; i++)
                {
                    mapSaveData OutputData = new mapSaveData();
                    OutputData.PositionX = (int)gridData[i].gPosition.x;
                    OutputData.PositionY = (int)gridData[i].gPosition.y;
                    OutputData.Content = (int)gridData[i].gContents;
                    string Output = OutputData.SaveToString();
                    writer.WriteLine(Output);
                }

                writer.Close();
            }
        }

        void Start()
        {
        }
    }
}
