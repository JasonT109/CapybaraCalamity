using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mapping
{
    public class mapPropBranch : MonoBehaviour
    {
        public Mesh Branch;
        public Mesh Trunk;
        public Mesh BranchJunctionCentre;
        public Mesh BranchJuntionLeft;
        public Mesh BranchJuntionRight;

        public List<mapGrid.Contents> NeighbourTypes = new List<mapGrid.Contents>(); //left, right, bottom, top

        public void SetTileMeshes()
        {
            bool Left = NeighbourTypes[0] == mapGrid.Contents.branch;
            bool Right = NeighbourTypes[1] == mapGrid.Contents.branch;
            bool Below = NeighbourTypes[2] == mapGrid.Contents.branch;
            bool Above = NeighbourTypes[3] == mapGrid.Contents.branch;

            //nothing above or below
            if ((Left || Right) && !(Below || Above))
                gameObject.GetComponent<MeshFilter>().mesh = Branch;

            //nothing left or right
            else if (!(Left || Right) && (Below || Above))
                gameObject.GetComponent<MeshFilter>().mesh = Trunk;

            //something to side and above
            else if ((Left || Right) && (Below || Above))
                gameObject.GetComponent<MeshFilter>().mesh = BranchJunctionCentre;
            
        }
    }
}
