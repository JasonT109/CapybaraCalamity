using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace mapping
{
    public class mapPropInfo : MonoBehaviour
    {
        public int propID = -1;
        public Vector2 propPosition = new Vector2(-1,-1);
        public Vector2 propSize = new Vector2(1, 1);

        private gridTile _ThisTile;

        public void UpdateTileMeshes()
        {
            if (_ThisTile != null)
            {
                if (_ThisTile.gContents == mapGrid.Contents.branch)
                {
                    if (_ThisTile.gObject != null)
                    {
                        _ThisTile.gObject.GetComponent<mapPropBranch>().NeighbourTypes = mapData.GetContentsNeighbours(_ThisTile);
                        _ThisTile.gObject.GetComponent<mapPropBranch>().SetTileMeshes();
                    }
                }
            }
        }

        private void UpdateNeighbours()
        {
            //get all neighbours
            List<gridTile> Neighbours = mapData.GetTileNeighbours(_ThisTile);

            //let each tile decide what meshes it needs to display
            foreach (gridTile N in Neighbours)
            {
                if (N.gObject != null)
                    N.gObject.GetComponent<mapPropInfo>().UpdateTileMeshes();
            }

            if(_ThisTile != null)
                UpdateTileMeshes();
        }

        void Start()
        {
            _ThisTile = mapData.GetGridTileFromPosition(propPosition);

            UpdateNeighbours();
        }

        void OnDestroy()
        {
            UpdateNeighbours();
        }
    }
}

