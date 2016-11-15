using UnityEngine;
using System.Collections;

public class ColliderTrigger : MonoBehaviour
{
    public Collider[] CollidersToIgnore;

    void OnTriggerEnter(Collider ColliderObject)
    {
        GameObject c = ColliderObject.gameObject;

        if (c.tag == "agent")
        {
            foreach (Collider col in CollidersToIgnore)
                c.GetComponent<agent>().IgnoredColliders.Add(col);
        }
    }


    void OnTriggerExit(Collider ColliderObject)
    {
        GameObject c = ColliderObject.gameObject;

        if (c.tag == "agent")
        {
            foreach (Collider col in CollidersToIgnore)
            {
                Physics.IgnoreCollision(ColliderObject, col, false);
                c.GetComponent<agent>().IgnoredColliders.Remove(col);
            }
        }
    }
}
