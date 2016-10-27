using UnityEngine;
using System.Collections;

public class createTunnel : MonoBehaviour {

    public bool canGrow = false;
    public float growthRate = 0.1f;
    public float digspeed = 1.0f;
    public GameObject Wall;
    public GameObject Scaler;

	// Use this for initialization
	void Start () {
        canGrow = true;
	}
	
	// Update is called once per frame
	void Update () {
        while (Scaler.transform.localScale.x < 1 && canGrow)
        {
            StartCoroutine(WaitAndGrow(growthRate));
            canGrow = false;
        }
        if (Scaler.transform.localScale.x >= 1 && canGrow)
        {
            if (Wall != null)
            {
                Destroy(Wall);
            }
            //stop the agent from moving
            canGrow = false;
        }
    }
    IEnumerator WaitAndGrow(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Scaler.transform.localScale += new Vector3(digspeed, 0, 0);
        canGrow = true;
    }
}
