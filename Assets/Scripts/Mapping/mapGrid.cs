using UnityEngine;
using System.Collections;

namespace mapping
{
    public class gridPiece
    {
        public Vector2 gPosition;
        public mapGrid.Contents gContents;
    }

    public class mapGrid : MonoBehaviour
    {
        public enum Contents
        {
            none,
            branch,
            trunk,
            pickup,
        };

        [SerializeField]
        private mapData mapData;

        [SerializeField]
        private GameObject branch;

        [SerializeField]
        private GameObject trunk;

        //grid
        private Contents[] gridContents;

        [SerializeField]
        private Vector2 gridSize;

        [SerializeField]
        private float gridSpacing = 0.3f;

        [SerializeField]
        private bool drawGrid = true;

        [SerializeField]
        private Color gridColor = new Color(0.2f, 0.2f, 0.2f, 1);

        private void AddGridLine(Vector3 StartPosition, Vector3 EndPosition)
        {
            GameObject newLine = new GameObject();
            newLine.name = "gridLine";
            newLine.transform.parent = gameObject.transform;
            LineRenderer line = newLine.AddComponent<LineRenderer>();

            line.material = new Material(Shader.Find("Particles/Additive"));
            line.SetColors(gridColor, gridColor);

            line.SetVertexCount(2);
            line.SetWidth(0.02f, 0.02f);
            line.SetPosition(0, StartPosition);
            line.SetPosition(1, EndPosition);
        }

        void Start()
        {
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

            //populate grid from level file
            if (mapData)
            {
                //load the data from file
                if(mapData.ReadMapData())
                {
                    //Debug.Log("Found map data.");
                    for (int i = 0; i < mapData.gridData.Count; i++)
                    {
                        Vector2 mPosition = mapData.gridData[i].gPosition;
                        Contents mContents = mapData.gridData[i].gContents;

                        gridContents[i] = mContents;

                        //instatiate prefab
                        GameObject NewObject = null;

                        if (mContents == Contents.branch)
                        {
                            NewObject = Instantiate(branch, new Vector3(gridSpacing * mPosition.x, gridSpacing * mPosition.y, 0), Quaternion.identity) as GameObject;
                        }
                        else if (mContents == Contents.trunk)
                        {
                            NewObject = Instantiate(trunk, new Vector3(gridSpacing * mPosition.x, gridSpacing * mPosition.y, 0), Quaternion.identity) as GameObject;
                        }

                        //set properties of object
                        if (NewObject != null)
                        {
                            NewObject.GetComponent<mapPropInfo>().propID = i;
                            NewObject.GetComponent<mapPropInfo>().propPosition = mPosition;
                        }
                    }
                }
                else
                {
                    Debug.Log("No map data found.");
                }


                //test save file
                //mapData.WriteMapData();
                //mapData.ReadMapData();
            }
        }

        // Update is called once per frame
        void Update()
        {


        }
    }
}


