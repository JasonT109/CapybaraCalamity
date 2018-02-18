using UnityEngine;
using System.IO;
using System.Collections.Generic;

namespace mapping
{
    public static class mapData
    {
        public static string mapName = "newMap1";
        //public Vector2 gridSize;
        public static List<gridTile> gridData = new List<gridTile>();

        private static string path = "Assets/Resources/";

        ///load data from file, returns true if map data found
        public static bool ReadMapData()
        {
            //clear previous data
            gridData.Clear();

            StreamReader reader = new StreamReader(path + mapName + ".json", true);

            if (reader != null)
            {
                while (reader.Peek() >= 0)
                {
                    //get info from json file
                    
                    string line = reader.ReadLine();
                    //Debug.Log("Line:" + line);
                    mapLoadData InputData = mapLoadData.CreateFromJSON(line);
                    //Debug.Log("Read data from file:" + InputData.Content);

                    //add to new gridPiece
                    gridTile InputPiece = new gridTile();
                    InputPiece.gPosition.x = InputData.PositionX;
                    InputPiece.gPosition.y = InputData.PositionY;
                    InputPiece.gSize.x = InputData.SizeX;
                    InputPiece.gSize.y = InputData.SizeY;

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
        public static void WriteMapData()
        {
            if (mapName != "")
            {
                StreamWriter writer = new StreamWriter(path + mapName + ".json", false);

                for (int i = 0; i < gridData.Count; i++)
                {
                    mapSaveData OutputData = new mapSaveData();
                    OutputData.PositionX = (int)gridData[i].gPosition.x;
                    OutputData.PositionY = (int)gridData[i].gPosition.y;
                    OutputData.SizeX = (int)gridData[i].gSize.x;
                    OutputData.SizeY = (int)gridData[i].gSize.y;
                    OutputData.Content = (int)gridData[i].gContents;
                    string Output = OutputData.SaveToString();
                    writer.WriteLine(Output);
                }

                writer.Close();
            }
        }

        public static int AddGridTile(gridTile InputPiece)
        {
            if (InputPiece.gContents == mapGrid.Contents.none)
                gridData.Remove(InputPiece);
            else
                gridData.Add(InputPiece);

            return gridData.Count;
        }

        public static void RemoveGridTile(gridTile InputPiece)
        {
            gridData.Remove(InputPiece);
        }

        public static gridTile GetGridTileFromPosition(Vector2 _GridPosition)
        {
            gridTile ReturnTile = new gridTile();
            for (int i = 0; i < gridData.Count; i++)
            {
                if (gridData[i].gPosition == _GridPosition)
                    ReturnTile = gridData[i];
            }

            return ReturnTile;
        }

        public static List<gridTile> GetTileNeighbours(gridTile _ThisTile)
        {
            List<gridTile> Neighbours = new List<gridTile>();

            gridTile N = new gridTile();

            Vector2[] Positions = new Vector2[]
            {
                new Vector2(_ThisTile.gPosition.x - 1, _ThisTile.gPosition.y),
                new Vector2(_ThisTile.gPosition.x + 1, _ThisTile.gPosition.y),
                new Vector2(_ThisTile.gPosition.x, _ThisTile.gPosition.y - 1),
                new Vector2(_ThisTile.gPosition.x, _ThisTile.gPosition.y + 1)
            };

            
            for (int i = 0; i < Positions.Length; i++)
            {
                N = GetGridTileFromPosition(Positions[i]);
                if (N.gContents != mapGrid.Contents.none)
                {
                    Neighbours.Add(N);
                }
            }

            return Neighbours;
        }

        public static List<mapGrid.Contents> GetContentsNeighbours(gridTile _ThisTile)
        {
            List<mapGrid.Contents> Contents = new List<mapGrid.Contents>();

            gridTile N = new gridTile();

            Vector2[] Positions = new Vector2[]
            {
                new Vector2(_ThisTile.gPosition.x - 1, _ThisTile.gPosition.y),
                new Vector2(_ThisTile.gPosition.x + 1, _ThisTile.gPosition.y),
                new Vector2(_ThisTile.gPosition.x, _ThisTile.gPosition.y - 1),
                new Vector2(_ThisTile.gPosition.x, _ThisTile.gPosition.y + 1)
            };

            for (int i = 0; i < Positions.Length; i++)
            {
                N = GetGridTileFromPosition(Positions[i]);
                Contents.Add(N.gContents);
            }

            return Contents;
        }

        /// <summary>
        /// Remove an idividual tile from the map data
        /// </summary>
        /// <param name="TargetTile"></param>
        /// <returns></returns>
        public static GameObject GetGridObject(gridTile TargetTile)
        {
            GameObject GridObject = TargetTile.gObject;

            return GridObject;
        }
    }
}
