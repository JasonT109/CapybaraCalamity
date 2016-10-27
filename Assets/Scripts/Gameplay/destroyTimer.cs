using UnityEngine;
using System.Collections;

public class destroyTimer : MonoBehaviour
{
    public float DestroyTime = 1f;
    private float _Timer = 0f;

	void Update ()
    {
        _Timer += Time.deltaTime;
        if (_Timer < DestroyTime)
            return;

        Destroy(gameObject);
	}
}
