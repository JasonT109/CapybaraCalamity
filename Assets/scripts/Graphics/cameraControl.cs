using UnityEngine;
using System;
using System.Collections;
using TouchScript.Layers;
using TouchScript.Gestures;
using TouchScript.Hit;

public class cameraControl : MonoBehaviour
{
    public float Speed = 0.1F;
    public float MaxTouchDelta = 0.2f;
    public Vector3 CameraMinTranslate = new Vector3(-2, -2, -5);
    public Vector3 CameraMaxTranslate = new Vector3(2, 2, 5);
    public LayerMask CameraLayerMask;
    public LayerMask DefaultLayerMask;

    private Camera _MainCamera;
    private TransformGesture _TransformGesture;
    private PressGesture _PressGesture;
    private ReleaseGesture _ReleaseGesture;
    private int _Touches;
    public float _ScaleDelta = 1;
    public float MouseZoomSpeed = 2f;
    public Vector3 screenPos;

    private void OnEnable()
    {
        _PressGesture = GetComponent<PressGesture>();
        _PressGesture.Pressed += PressHandler;

        _ReleaseGesture = GetComponent<ReleaseGesture>();
        _ReleaseGesture.Released += ReleaseHandler;

        _TransformGesture = GetComponent<TransformGesture>();
        _TransformGesture.Transformed += TransformHandler;
    }

    private void OnDisable()
    {
        _PressGesture.Pressed -= PressHandler;
        _ReleaseGesture.Released -= ReleaseHandler;
        _TransformGesture.Transformed -= TransformHandler;
    }

    private void PressHandler(object sender, EventArgs e)
    {
        _MainCamera.GetComponent<CameraLayer>().LayerMask = CameraLayerMask;
    }

    private void ReleaseHandler(object sender, EventArgs e)
    {
        _MainCamera.GetComponent<CameraLayer>().LayerMask = DefaultLayerMask;
    }

    private void TransformHandler(object sender, EventArgs e)
    {
        var gesture = sender as TransformGesture;
        TouchHit hit;
        gesture.GetTargetHitResult(out hit);

        _Touches = gesture.NumTouches;

        _MainCamera.transform.localPosition -= new Vector3(gesture.DeltaPosition.x, gesture.DeltaPosition.y, 0);

        if (_Touches == 2)
            _ScaleDelta = Mathf.Clamp(gesture.DeltaScale, 0.9f, 1.1f);
        else
            _ScaleDelta = 1f;

        float Zoom = _MainCamera.transform.localPosition.z * _ScaleDelta;

        _MainCamera.transform.localPosition = new Vector3(
            Mathf.Clamp(_MainCamera.transform.localPosition.x, CameraMinTranslate.x, CameraMaxTranslate.x),
            Mathf.Clamp(_MainCamera.transform.localPosition.y, CameraMinTranslate.y, CameraMaxTranslate.y),
            Mathf.Clamp(Zoom, CameraMinTranslate.z, CameraMaxTranslate.z));

    }

    void Start()
    {
        _MainCamera = Camera.main;
        _MainCamera.GetComponent<CameraLayer>().LayerMask = DefaultLayerMask;
    }

    void Update()
    {
        float ScrollDelta = Input.GetAxis("Mouse ScrollWheel");
        if (ScrollDelta > 0f)
        {
            _ScaleDelta = 1 - ScrollDelta;
            _MainCamera.transform.localPosition = new Vector3(
                _MainCamera.transform.localPosition.x, 
                _MainCamera.transform.localPosition.y,
                Mathf.Clamp(_MainCamera.transform.localPosition.z + MouseZoomSpeed, CameraMinTranslate.z, CameraMaxTranslate.z));
        }
        else if (ScrollDelta < 0f)
        {
            _ScaleDelta = 1 + ScrollDelta;
            _MainCamera.transform.localPosition = new Vector3(
                _MainCamera.transform.localPosition.x,
                _MainCamera.transform.localPosition.y,
                Mathf.Clamp(_MainCamera.transform.localPosition.z - MouseZoomSpeed, CameraMinTranslate.z, CameraMaxTranslate.z));
        }
    }
}