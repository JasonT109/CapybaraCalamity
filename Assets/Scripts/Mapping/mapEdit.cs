using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TouchScript.Layers;
using TouchScript.Gestures;
using TouchScript.Gestures.TransformGestures;
using TouchScript.Hit;

namespace mapping
{
    public class mapEdit : MonoBehaviour
    {
        public mapGrid Grid;
        public GameObject SpawnVFX;
        public InputField NameInput;
        public Text NameText;
        public float MoveTolerance = 2;
        private float MoveDelta;

        [NonSerialized]
        public mapGrid.Contents ActiveProp = mapGrid.Contents.none;
        [NonSerialized]
        public string GridContents = "Nothing";

        private PressGesture _PressGesture;
        private ReleaseGesture _ReleaseGesture;
        private TransformGesture _TransformGesture;
        private Vector3 _GridPressPoint = Vector3.zero;
        private Vector3 _GridReleasePoint = Vector3.zero;
        private float _GridSpacing;
        private gridTile _SelectedPiece;

        private void OnEnable()
        {
            _PressGesture = GetComponent<PressGesture>();
            _PressGesture.Pressed += PressHandler;

            _ReleaseGesture = GetComponent<ReleaseGesture>();
            _ReleaseGesture.Released += ReleaseHandler;

            _TransformGesture = GetComponent<TransformGesture>();
            _TransformGesture.Transformed += TransformHandler;
        }

        private void OnDisable()
        {
            _PressGesture.Pressed -= PressHandler;
            _ReleaseGesture.Released -= ReleaseHandler;
            _TransformGesture.Transformed -= TransformHandler;
        }

        private void PressHandler(object sender, EventArgs e)
        {
            var gesture = sender as PressGesture;
            HitData hit = gesture.GetScreenPositionHitData();

            //gesture.GetTargetHitResult(out hit);

            _GridPressPoint = Grid.transform.InverseTransformPoint(hit.Point);
            _GridPressPoint += new Vector3(_GridSpacing * 0.5f, _GridSpacing * 0.5f,0);
            _GridPressPoint = new Vector3(
                Mathf.Floor(_GridPressPoint.x * _GridSpacing),
                Mathf.Floor(_GridPressPoint.y * _GridSpacing),
                0);

            MoveDelta = 0;
            //Debug.Log("Clicked grid at: " + _GridPressPoint);
        }

        private void ReleaseHandler(object sender, EventArgs e)
        {
            var gesture = sender as ReleaseGesture;
            HitData hit = gesture.GetScreenPositionHitData();

            _GridReleasePoint = Grid.transform.InverseTransformPoint(hit.Point);
            _GridReleasePoint += new Vector3(_GridSpacing * 0.5f, _GridSpacing * 0.5f, 0);
            _GridReleasePoint = new Vector3(
                Mathf.Floor(_GridPressPoint.x * _GridSpacing),
                Mathf.Floor(_GridPressPoint.y * _GridSpacing),
                0);

            if (_GridReleasePoint.x < 0 || _GridReleasePoint.y < 0 || _GridReleasePoint.x >= Grid.gridSize.x || _GridReleasePoint.y >= Grid.gridSize.y)
                return;

            if (MoveDelta < MoveTolerance) //_GridReleasePoint == _GridPressPoint
            {
                _SelectedPiece = mapData.GetGridTileFromPosition(new Vector2(_GridReleasePoint.x, _GridReleasePoint.y));
                if (_SelectedPiece != null)
                    GridContents = _SelectedPiece.gContents.ToString();
                else
                    GridContents = "Nothing";

                Instantiate(SpawnVFX, hit.Point, Quaternion.identity);

                gridTile NewTile = new gridTile
                {
                    gContents = ActiveProp,
                    gPosition = (new Vector2(_GridPressPoint.x, _GridPressPoint.y))
                };
                AddNewTile(NewTile);
                //Debug.Log("Valid click release on grid at: " + _GridReleasePoint + " and contains " + _GridContents);
            }
        }

        private void TransformHandler(object sender, EventArgs e)
        {
            var gesture = sender as TransformGesture;
            MoveDelta += gesture.DeltaPosition.magnitude;

            //_GridPressPoint = new Vector3(-1, -1, -1);
        }

        /// <summary>
        /// Set the active prop for placement in level
        /// </summary>
        /// <param name="PropEnumValue"></param>
        public void SetActiveProp(int PropEnumValue)
        {
            ActiveProp = (mapGrid.Contents)PropEnumValue;
        }

        public void GetMapName()
        {
            string NewMapName = "newMapName";
            
            //pause game


            //get map name from user input

            SetMapName(NewMapName);

        }

        /// <summary>
        /// Set the map file name
        /// </summary>
        /// <param name="_MapName"></param>
        private void SetMapName(string _MapName)
        {
            mapData.mapName = _MapName;
        }

        /// <summary>
        /// Create a new map.
        /// </summary>
        public void CreateNewMap()
        {

        }

        /// <summary>
        /// Save the current map
        /// </summary>
        public void SaveMap()
        {
            //TODO
            //confirm map save
            mapData.WriteMapData();
        }

        /// <summary>
        /// Load a new map.
        /// </summary>
        /// <param name="ConfirmMapLoad"></param>
        public void LoadMap(bool ConfirmMapLoad = false)
        {
            RemoveAllTiles();
            mapData.ReadMapData();
        }

        /// <summary>
        /// Add a new tile to the map data and scene
        /// </summary>
        /// <param name="_NewGridTile"></param>
        public void AddNewTile(gridTile _NewGridTile)
        {
            if (_NewGridTile == null)
                return;

            //Get contents of existing tile
            gridTile ExistingTile = mapData.GetGridTileFromPosition(_NewGridTile.gPosition);

            //If trying to clear an empty tile
            if (_NewGridTile.gContents == mapGrid.Contents.none && ExistingTile.gContents == mapGrid.Contents.none)
                return;

            //Tool is set to clear tile and tile has contents
            if (_NewGridTile.gContents == mapGrid.Contents.none)
            {
                if (ExistingTile.gContents != mapGrid.Contents.none && ExistingTile.gContents != mapGrid.Contents.reserved)
                {
                    //Create list of tiles to remove
                    List<gridTile> TilesToRemove = new List<gridTile>();

                    Debug.Log("Size of this object = " + ExistingTile.gSize);
                    //If our object is bigger than 1x1
                    if (ExistingTile.gSize.x > 1 || ExistingTile.gSize.y > 1)
                    {
                        Debug.Log("removing large object");
                        for (int x = 0; x < ExistingTile.gSize.x; x++)
                        {
                            for (int y = 0; y < ExistingTile.gSize.y; y++)
                            {
                                gridTile ThisTile = mapData.GetGridTileFromPosition(new Vector2(ExistingTile.gPosition.x + x, ExistingTile.gPosition.y + y));
                                Debug.Log("Adding tile top remove: " + ThisTile.gContents);
                                TilesToRemove.Add(ThisTile);
                            }
                        }
                    }
                    else
                    {
                        TilesToRemove.Add(ExistingTile);
                    }

                    //Remove each tile in this list
                    foreach (gridTile T in TilesToRemove)
                    {
                        RemoveTile(T);
                    }
                    return;
                }
                return;
            }

            GameObject ObjectToPlace = Grid.PlaceableObjects[(int)_NewGridTile.gContents - 1];
            int xTiles = (int)ObjectToPlace.GetComponent<mapPropInfo>().propSize.x;
            int yTiles = (int)ObjectToPlace.GetComponent<mapPropInfo>().propSize.y;
            int numTilesToCheck = xTiles * yTiles;
            gridTile[] tilesToCheck = new gridTile[numTilesToCheck];

            int i = 0;
            for (int x = 0; x < xTiles; x++)
            {
                for (int y = 0; y < yTiles; y++)
                {
                    tilesToCheck[i] = new gridTile();
                    tilesToCheck[i].gPosition = new Vector2(_NewGridTile.gPosition.x + x, _NewGridTile.gPosition.y + y);
                    i++;
                }
            }

            if (!CheckTilesAreValid(tilesToCheck))
            {
                Debug.Log("Invalid tile for this prop.");
                return;
            }

            //same as existing piece
            if (ExistingTile.gContents == _NewGridTile.gContents)
                return;

            //tool is set to different tile than existing tile
            if (ExistingTile.gContents != _NewGridTile.gContents)
                RemoveTile(ExistingTile);

            //if tool is not set to none, place the new tile
            if (_NewGridTile.gContents != mapGrid.Contents.none)
            {
                //instatiate prefab
                GameObject NewObject = null;

                NewObject = Instantiate(Grid.PlaceableObjects[(int)_NewGridTile.gContents - 1], new Vector3(_GridSpacing * _NewGridTile.gPosition.x, _GridSpacing * _NewGridTile.gPosition.y, 0), Quaternion.identity) as GameObject;

                //set properties of object
                if (NewObject != null)
                {
                    //Store size of our new prop in the tile data
                    _NewGridTile.gSize = NewObject.GetComponent<mapPropInfo>().propSize;

                    //Get our unique id
                    NewObject.GetComponent<mapPropInfo>().propID = mapData.AddGridTile(_NewGridTile);

                    //Store our position
                    NewObject.GetComponent<mapPropInfo>().propPosition = _NewGridTile.gPosition;

                    //Add the object to the map data
                    mapData.gridData[mapData.gridData.Count - 1].gObject = NewObject;

                    //If prop size x,y is greater than 1, set other tiles to reserved
                    if (xTiles > 1 || yTiles > 1)
                    {
                        for (int x = 0; x < xTiles; x++)
                        {
                            for (int y = 0; y < yTiles; y++)
                            {
                                if (x == 0 && y == 0)
                                {
                                    //Debug.Log("Row = " + x + " Column = " + y + " < Skipping");
                                }
                                else
                                {
                                    //Debug.Log("Row = " + x + " Column = " + y);
                                    //Create a tile for this reserved position
                                    gridTile ReservedTile = new gridTile();

                                    //Set contents to reserved
                                    ReservedTile.gContents = mapGrid.Contents.reserved;

                                    //Set position
                                    ReservedTile.gPosition = new Vector2(_NewGridTile.gPosition.x + x, _NewGridTile.gPosition.y + y);

                                    //Add tile to map data
                                    int NewPropID = mapData.AddGridTile(ReservedTile);
                                    Debug.Log("New prop id = " + NewPropID);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Removes the specified tile from the map data and scene
        /// </summary>
        /// <param name="PieceToRemove"></param>
        public void RemoveTile(gridTile PieceToRemove)
        {
            Destroy(PieceToRemove.gObject);
            mapData.RemoveGridTile(PieceToRemove);
        }

        /// <summary>
        /// Remove all the tiles that make this map.
        /// </summary>
        public void RemoveAllTiles()
        {
            foreach (gridTile G in mapData.gridData)
                RemoveTile(G);
        }

        public bool CheckTilesAreValid(gridTile[] GridTiles)
        {
            foreach (gridTile G in GridTiles)
            {
                gridTile ThisTile = mapData.GetGridTileFromPosition(G.gPosition);
                Debug.Log("This tile contains " + ThisTile.gContents);
                if (ThisTile.gContents != mapGrid.Contents.none || G.gPosition.x < 0 || G.gPosition.y < 0 || G.gPosition.x > Grid.gridSize.x || G.gPosition.y > Grid.gridSize.y)
                    return false;

            }
            return true;
        }

        void Start()
        {
            _GridSpacing = Grid.GetComponent<mapGrid>().gridSpacing;
            if (NameInput != null)
                NameInput.gameObject.SetActive(false);
        }
    }
}