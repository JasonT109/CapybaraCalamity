using UnityEngine;
using System;
using System.Collections;

namespace mapping
{
    public class gridTile
    {
        public Vector2 gPosition;
        public Vector2 gSize;
        public mapGrid.Contents gContents;
        public GameObject gObject;
    }

    public class mapGrid : MonoBehaviour
    {
        public enum Contents
        {
            none,
            branch,
            trunk,
            spawner,
            nest,
            pickup,
            decoration,
            junction,
            reserved
        };

        public GameObject BranchPrefab;
        public GameObject TrunkPrefab;
        public GameObject SpawnerPrefab;
        public GameObject NestPrefab;
        public GameObject PickupPrefab;
        public GameObject DecorationPrefab;
        public GameObject JunctionPrefab;

        [NonSerialized]
        public GameObject[] PlaceableObjects;

        //grid
        private Contents[] gridContents;

        public Vector2 gridSize;

        public float gridSpacing = 0.3f;

        [SerializeField]
        private bool drawGrid = true;

        [SerializeField]
        private Color gridColor = new Color(0.2f, 0.2f, 0.2f, 1);

        private void AddGridLine(Vector3 StartPosition, Vector3 EndPosition)
        {
            GameObject newLine = new GameObject
            {
                name = "gridLine"
            };
            newLine.transform.parent = gameObject.transform;
            LineRenderer line = newLine.AddComponent<LineRenderer>();

            line.material = new Material(Shader.Find("Particles/Additive"));
            //line.SetColors(gridColor, gridColor);
            line.startColor = gridColor;
            line.endColor = gridColor;

            //line.SetVertexCount(2);
            line.positionCount = 2;
            //line.SetWidth(0.02f, 0.02f);
            line.startWidth = 0.02f;
            line.endWidth = 0.02f;
            line.SetPosition(0, StartPosition);
            line.SetPosition(1, EndPosition);
        }

        void Start()
        {
            PlaceableObjects = new GameObject[]{BranchPrefab, TrunkPrefab, SpawnerPrefab, NestPrefab, PickupPrefab, DecorationPrefab, JunctionPrefab};

            if (drawGrid)
            {
                for (int y = 0; y <= gridSize.y; y++)
                {
                    AddGridLine(new Vector3(0 - (gridSpacing * 0.5f), y * gridSpacing - (gridSpacing * 0.5f), 0), new Vector3(gridSize.x * gridSpacing - (gridSpacing * 0.5f), y * gridSpacing - (gridSpacing * 0.5f), 0));
                }

                for (int x = 0; x <= gridSize.x; x++)
                {
                    AddGridLine(new Vector3((x * gridSpacing) - (gridSpacing * 0.5f), 0 - (gridSpacing * 0.5f), 0), new Vector3((x * gridSpacing) - (gridSpacing * 0.5f), gridSize.y * gridSpacing - (gridSpacing * 0.5f), 0));
                }
            }

            //initialise the grid
            gridContents = new Contents[(int)(gridSize.x * gridSize.y)];

            //load the data from file
            if(mapData.ReadMapData())
            {
                //Debug.Log("Found map data.");
                for (int i = 0; i < mapData.gridData.Count; i++)
                {
                    Vector2 mPosition = mapData.gridData[i].gPosition;
                    Contents mContents = mapData.gridData[i].gContents;

                    if (mContents != Contents.reserved)
                    {
                        gridContents[i] = mContents;

                        //instatiate prefab
                        GameObject NewObject = null;

                        NewObject = Instantiate(PlaceableObjects[(int)mContents - 1], new Vector3(gridSpacing * mPosition.x, gridSpacing * mPosition.y, 0), Quaternion.identity) as GameObject;

                        //add the spawned object to the map data
                        mapData.gridData[i].gObject = NewObject;

                        //set properties of object
                        if (NewObject != null)
                        {
                            NewObject.GetComponent<mapPropInfo>().propID = i;
                            NewObject.GetComponent<mapPropInfo>().propPosition = mPosition;
                        }
                    }

                }
            }
            else
            {
                Debug.Log("No map data found.");
            }
        }
    }
}


