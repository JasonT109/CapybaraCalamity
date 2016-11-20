using UnityEngine;
using System.Collections;

public class uiScaler : MonoBehaviour {

    public float scaleFactor = 1.0f;
    public float scaleSpeed = 1.0f;
    private Vector2 _OriginalSize;
    private RectTransform _Rect;
    private bool _ScaleMe = false;

	// Use this for initialization
	void Start ()
    {
        _Rect = gameObject.GetComponent<RectTransform>();
        _OriginalSize = _Rect.sizeDelta;
    }

    // Update is called once per frame
    void Update()
    {
        if (scaleFactor == 1.0f)
        {
            _ScaleMe = false;
        }
        if (_ScaleMe)
        {
            scaleFactor = Mathf.Lerp(scaleFactor, 1.0f, Time.deltaTime * scaleSpeed);
            _Rect.sizeDelta = Vector2.Scale(new Vector2(_OriginalSize.x, _OriginalSize.y), new Vector2(scaleFactor, scaleFactor));
        }
    }

    public void scaleUI(float scaleF)
    {
        _ScaleMe = true;
        scaleFactor = scaleF;
        //set the ui size on this frame
        _Rect.sizeDelta = Vector2.Scale(new Vector2(_OriginalSize.x, _OriginalSize.y), new Vector2(scaleFactor, scaleFactor));
    }
}
