using UnityEngine;
using System.Collections;

public class TriggerNextStep : MonoBehaviour
{
    void OnTriggerEnter(Collider ColliderObject)
    {
        GameObject c = ColliderObject.gameObject;

        if (c.tag == "agent")
        {
            c.GetComponent<agent>()._BuildingStep = false;
        }
    }
}
