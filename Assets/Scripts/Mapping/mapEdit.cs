using UnityEngine;
using System;
using System.Collections;
using TouchScript.Layers;
using TouchScript.Gestures;
using TouchScript.Hit;

namespace mapping
{
    public class mapEdit : MonoBehaviour
    {
        public mapGrid Grid;
        public GameObject SpawnVFX;

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
        private mapData _MapData;
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
            TouchHit hit;
            gesture.GetTargetHitResult(out hit);
            
            _GridPressPoint = Grid.transform.InverseTransformPoint(hit.Point);
            _GridPressPoint += new Vector3(_GridSpacing * 0.5f, _GridSpacing * 0.5f,0);
            _GridPressPoint = new Vector3(
                Mathf.Floor(_GridPressPoint.x * _GridSpacing),
                Mathf.Floor(_GridPressPoint.y * _GridSpacing),
                0);
            //Debug.Log("Clicked grid at: " + _GridPressPoint);
        }

        private void ReleaseHandler(object sender, EventArgs e)
        {
            var gesture = sender as ReleaseGesture;
            TouchHit hit;
            gesture.GetTargetHitResult(out hit);

            _GridReleasePoint = Grid.transform.InverseTransformPoint(hit.Point);
            _GridReleasePoint += new Vector3(_GridSpacing * 0.5f, _GridSpacing * 0.5f, 0);
            _GridReleasePoint = new Vector3(
                Mathf.Floor(_GridPressPoint.x * _GridSpacing),
                Mathf.Floor(_GridPressPoint.y * _GridSpacing),
                0);

            if (_GridReleasePoint.x < 0 || _GridReleasePoint.y < 0 || _GridReleasePoint.x >= Grid.gridSize.x || _GridReleasePoint.y >= Grid.gridSize.y)
                return;

            if (_GridReleasePoint == _GridPressPoint)
            {
                _SelectedPiece = _MapData.GetGridTileFromPosition(new Vector2(_GridReleasePoint.x, _GridReleasePoint.y));
                if (_SelectedPiece != null)
                    GridContents = _SelectedPiece.gContents.ToString();
                else
                    GridContents = "Nothing";

                Instantiate(SpawnVFX, hit.Point, Quaternion.identity);

                gridTile NewTile = new gridTile();
                NewTile.gContents = ActiveProp;
                NewTile.gPosition = (new Vector2(_GridPressPoint.x, _GridPressPoint.y));
                AddNewPiece(NewTile);
                //Debug.Log("Valid click release on grid at: " + _GridReleasePoint + " and contains " + _GridContents);
            }
        }

        private void TransformHandler(object sender, EventArgs e)
        {
            _GridPressPoint = new Vector3(-1, -1, -1);
        }

        /// <summary>
        /// Set the active prop for placement in level
        /// </summary>
        /// <param name="PropEnumValue"></param>
        public void SetActiveProp(int PropEnumValue)
        {
            ActiveProp = (mapGrid.Contents)PropEnumValue;
            Debug.Log("Active prop is now " + ActiveProp);
        }

        /// <summary>
        /// Set the map file name
        /// </summary>
        /// <param name="_MapName"></param>
        public void SetMapName(string _MapName)
        {
            _MapData.mapName = _MapName;
        }

        /// <summary>
        /// Creare a new map.
        /// </summary>
        /// <param name="ConfirmNewMap"></param>
        public void CreateNewMap(bool ConfirmNewMap = false)
        {

        }

        public void SaveMap(bool ConfirmMapSave = false)
        {
            //TODO
            //confirm map save
            _MapData.WriteMapData();
        }

        /// <summary>
        /// Load a new map.
        /// </summary>
        /// <param name="ConfirmMapLoad"></param>
        public void LoadMap(bool ConfirmMapLoad = false)
        {
            RemoveAllTiles();
            _MapData.ReadMapData();
        }

        public void AddNewPiece(gridTile _NewGridTile)
        {
            if (_NewGridTile == null)
                return;

            gridTile ExistingTile = _MapData.GetGridTileFromPosition(_NewGridTile.gPosition);

            //same as existing piece
            if (ExistingTile.gContents == _NewGridTile.gContents)
                return;

            //tool is set to clear tile and tile has contents
            if (_NewGridTile.gContents == mapGrid.Contents.none && ExistingTile.gContents != mapGrid.Contents.none)
            {
                RemoveTile(ExistingTile);
                return;
            }

            //tool is set to different tile than existing tile
            if (ExistingTile.gContents != _NewGridTile.gContents)
                RemoveTile(ExistingTile);

            //if tool is not set to none, place the new tile
            if (_NewGridTile.gContents != mapGrid.Contents.none)
            {
                //instatiate prefab
                GameObject NewObject = null;

                if (_NewGridTile.gContents == mapGrid.Contents.branch)
                    NewObject = Instantiate(Grid.branch, new Vector3(_GridSpacing * _NewGridTile.gPosition.x, _GridSpacing * _NewGridTile.gPosition.y, 0), Quaternion.identity) as GameObject;
                else if (_NewGridTile.gContents == mapGrid.Contents.trunk)
                    NewObject = Instantiate(Grid.trunk, new Vector3(_GridSpacing * _NewGridTile.gPosition.x, _GridSpacing * _NewGridTile.gPosition.y, 0), Quaternion.identity) as GameObject;

                //set properties of object
                if (NewObject != null)
                {
                    NewObject.GetComponent<mapPropInfo>().propID = _MapData.AddGridTile(_NewGridTile);
                    NewObject.GetComponent<mapPropInfo>().propPosition = _NewGridTile.gPosition;
                    //add the object to the map data
                    _MapData.gridData[_MapData.gridData.Count - 1].gObject = NewObject;
                }
            }
        }

        public void RemoveTile(gridTile PieceToRemove)
        {
            Destroy(PieceToRemove.gObject);
            _MapData.RemoveGridTile(PieceToRemove);
        }

        /// <summary>
        /// Remove an idividual tile from the map data
        /// </summary>
        /// <param name="TargetPiece"></param>
        /// <returns></returns>
        public GameObject GetGridObject(gridTile TargetPiece)
        {
            GameObject GridObject = null;

            return GridObject;
        }

        /// <summary>
        /// Remove all the pieces that make this map.
        /// </summary>
        public void RemoveAllTiles()
        {
            foreach (gridTile G in _MapData.gridData)
                RemoveTile(G);
        }

        void Start()
        {
            _GridSpacing = Grid.GetComponent<mapGrid>().gridSpacing;
            _MapData = Grid.GetComponent<mapGrid>().mapData;
        }
    }
}
