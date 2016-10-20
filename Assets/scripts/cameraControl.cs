using UnityEngine;
using System;
using System.Collections;
using TouchScript.Layers;
using TouchScript.Gestures;
using TouchScript.Hit;

public class cameraControl : MonoBehaviour
{
    public float Speed = 0.1F;
    public Vector3 CameraMinTranslate = new Vector3(-2, -2, -5);
    public Vector3 CameraMaxTranslate = new Vector3(2, 2, 5);
    public LayerMask CameraLayerMask;
    public LayerMask DefaultLayerMask;

    private Vector3 _MouseDelta;
    private Vector3 _LastPosition;
    private Vector3 _CameraPosition;
    private Camera _MainCamera;
    private TransformGesture _TransformGesture;
    private PressGesture _PressGesture;
    private ReleaseGesture _ReleaseGesture;
    private Vector3 _CurrentHit;
    private Vector3 _PreviousHit;
    private int _Touches;
    private float _ScaleDelta;
    private bool _Transforming;
    private Vector3 _TouchDelta;

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
        _Transforming = true;
        _MainCamera.GetComponent<CameraLayer>().LayerMask = CameraLayerMask;
    }

    private void ReleaseHandler(object sender, EventArgs e)
    {
        _Transforming = false;
        _PreviousHit = Vector3.zero;
        _CurrentHit = Vector3.zero;
        _TouchDelta = Vector3.zero;
        _MainCamera.GetComponent<CameraLayer>().LayerMask = DefaultLayerMask;
    }

    private void TransformHandler(object sender, EventArgs e)
    {
        var gesture = sender as TransformGesture;
        TouchHit hit;
        gesture.GetTargetHitResult(out hit);

        _Touches = gesture.NumTouches;
        _CurrentHit = hit.Point;

        if (_Touches == 2)
            _ScaleDelta = Mathf.Clamp(gesture.DeltaScale, 0.9f, 1.1f);
        else
            _ScaleDelta = 1f;
    }

    void Start()
    {
        _MainCamera = Camera.main;
        _MainCamera.GetComponent<CameraLayer>().LayerMask = DefaultLayerMask;
    }

    void Update()
    {
        if (_Transforming)
        {
            if (_PreviousHit == Vector3.zero)
                { _PreviousHit = _CurrentHit; return; }

            _TouchDelta = new Vector3(_PreviousHit.x - _CurrentHit.x, _PreviousHit.y - _CurrentHit.y, 0) * Speed;

            _PreviousHit = _CurrentHit;

            _MainCamera.transform.localPosition += new Vector3(_TouchDelta.x, _TouchDelta.y, 0);

            float Zoom = _MainCamera.transform.localPosition.z * _ScaleDelta;

            _MainCamera.transform.localPosition = new Vector3(
                Mathf.Clamp(_MainCamera.transform.localPosition.x, CameraMinTranslate.x, CameraMaxTranslate.x), 
                Mathf.Clamp(_MainCamera.transform.localPosition.y, CameraMinTranslate.y, CameraMaxTranslate.y),
                Mathf.Clamp(Zoom, CameraMinTranslate.z, CameraMaxTranslate.z));
        }
    }
}