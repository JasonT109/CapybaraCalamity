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
        private float gridSpacing = 0.02f;

        void Start()
        {
            //initialise the grid
            gridContents = new Contents[(int)(gridSize.x * gridSize.y)];

            //populate grid from level file
            if (mapData)
            {
                //load the data from file
                if(mapData.ReadMapData())
                {
                    Debug.Log("Found map data.");
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


