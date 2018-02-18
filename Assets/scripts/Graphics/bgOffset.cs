using UnityEngine;
using System.Collections;

public class bgOffset : MonoBehaviour
{
    public Camera GameCamera;
    public float offsetValue = 0.5f;
    public float offsetValueY = 1.1f;

    void Start ()
    {
        GameCamera = Camera.main;
    }

	void LateUpdate ()
    {
        transform.position = new Vector3 (GameCamera.transform.position.x * offsetValue, GameCamera.transform.position.y * -offsetValueY, transform.position.z);
	}
}
