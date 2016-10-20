using UnityEngine;
using System.Collections;

public class createTunnel : MonoBehaviour {

    public bool canGrow = false;
    public float growthRate = 0.1f;
    public float digspeed = 1.0f;
    public GameObject wall;

	// Use this for initialization
	void Start () {
        canGrow = true;
	}
	
	// Update is called once per frame
	void Update () {
        while (transform.localScale.x < 1 && canGrow)
        {
            StartCoroutine(WaitAndGrow(growthRate));
            canGrow = false;
        }
        if (transform.localScale.x >= 1 && canGrow)
        {
            if (wall != null)
            {
                Destroy(wall);
            }
            //stop the agent from moving
            canGrow = false;
        }
    }
    IEnumerator WaitAndGrow(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        transform.localScale += new Vector3(digspeed, 0, 0);
        canGrow = true;
    }
}
