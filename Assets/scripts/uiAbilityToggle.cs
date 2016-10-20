using UnityEngine;
using System.Collections;

public class uiAbilityToggle : MonoBehaviour {

    private bool ability = false;

    void Start ()
    {
        var cr = gameObject.GetComponent<CanvasRenderer>();
        cr.SetAlpha(0.0f);
        ability = true;
    }

    public void toggleAbility()
    {
        if (ability)
        {
            var cr = gameObject.GetComponent<CanvasRenderer>();
            cr.SetAlpha(255.0f);
            Debug.Log("Setting alpha to 255");
            ability = false;
        }
        else
        {
            var cr = gameObject.GetComponent<CanvasRenderer>();
            cr.SetAlpha(0.0f);
            Debug.Log("Setting alpha to 0");
            ability = true;
        }
    }
}
