using UnityEngine;
using System.Collections;

public class createHole : MonoBehaviour {

    public float digspeed = 1.0f;
    public float growthRate = 0.2f;
    public bool canGrow;
    public GameObject floor;
    public GameObject digger;
    public Transform leftWall;
    public Transform rightWall;

    //public bool wl = false;
    //public bool wr = false;


    // Use this for initialization
    void Start () {
        canGrow = true;
        var agentScript = digger.transform.GetComponent<agent>();
        agentScript.Digging = true;

        //check to see if there is a hole wall to left or right
        Ray ray_right;
        ray_right = new Ray(transform.position + new Vector3(0, -0.125f, 0), new Vector3(1, 0, 0));

        Ray ray_left;
        ray_left = new Ray(transform.position + new Vector3(0, -0.125f, 0), new Vector3(-1, 0, 0));


        //check to right
        int layerMask = 1 << 12 ;

        RaycastHit hit;
        if (Physics.Raycast(ray_right.origin, ray_right.direction, out hit, 0.175f, layerMask))
        {
            //Debug.Log("Right ray cast hit something with tag:" + hit.collider.tag);
            //wr = true;
            if (hit.collider.tag == "hole")
            {
                var otherHole = hit.transform.GetComponentInChildren<createHole>();
                otherHole.leftWall.transform.gameObject.SetActive(false);
                rightWall.gameObject.SetActive(false);
            }
            if (hit.collider.tag == "wall_right")
            {
                rightWall.gameObject.SetActive(false);
            }
        }

        if (Physics.Raycast(ray_left.origin, ray_left.direction, out hit, 0.175f, layerMask))
        {
            //Debug.Log("Left ray cast hit something with tag:" + hit.collider.tag);
            //wl = true;
            if (hit.collider.tag == "hole")
            {
                var otherHole = hit.transform.GetComponentInChildren<createHole>();
                otherHole.rightWall.transform.gameObject.SetActive(false);
                leftWall.gameObject.SetActive(false);
            }
            if (hit.collider.tag == "wall_left")
            {
                leftWall.gameObject.SetActive(false);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        /*if (wl)
        {
            Debug.DrawLine(transform.position + new Vector3(0, -0.125f, 0), transform.position + new Vector3(-0.2f, -0.125f, 0), Color.blue);
        }
        if (wr)
        {
            Debug.DrawLine(transform.position + new Vector3(0, -0.125f, 0), transform.position + new Vector3(0.2f, -0.125f, 0), Color.red);
        }*/
        
        while (transform.localScale.y < 1 && canGrow)
        {
            StartCoroutine(WaitAndGrow(growthRate));
            canGrow = false;
        }
        if (transform.localScale.y >= 1 && canGrow)
        {
            if (floor != null)
            {
                Destroy(floor);
            }
            //stop the agent from moving
            var agentScript = digger.transform.GetComponent<agent>();
            agentScript.Digging = false;
            canGrow = false;
        }
    }

    IEnumerator WaitAndGrow(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        transform.localScale += new Vector3(0, digspeed, 0);
        canGrow = true;
    }
}
