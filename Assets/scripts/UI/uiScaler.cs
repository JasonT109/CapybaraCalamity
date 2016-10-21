using UnityEngine;
using System.Collections;

public class uiScaler : MonoBehaviour {

    public float scaleFactor = 1.0f;
    public float scaleSpeed = 1.0f;
    public Vector2 originalSize;
    public RectTransform meRect;
    public bool scaleMe = false;

	// Use this for initialization
	void Start ()
    {
        meRect = this.GetComponent<RectTransform>();
        originalSize = meRect.sizeDelta;
    }

    // Update is called once per frame
    void Update()
    {
        if (scaleFactor == 1.0f)
        {
            scaleMe = false;
        }
        if (scaleMe)
        {
            scaleFactor = Mathf.Lerp(scaleFactor, 1.0f, Time.deltaTime * scaleSpeed);
            meRect.sizeDelta = Vector2.Scale(new Vector2(originalSize.x, originalSize.y), new Vector2(scaleFactor, scaleFactor));
        }
    }

    public void scaleUI(float scaleF)
    {
        scaleMe = true;
        scaleFactor = scaleF;
        //set the ui size on this frame
        meRect.sizeDelta = Vector2.Scale(new Vector2(originalSize.x, originalSize.y), new Vector2(scaleFactor, scaleFactor));
    }
}
