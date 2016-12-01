using UnityEngine;
using System;
using System.Collections;
using TouchScript.Gestures;
using TouchScript.Hit;

public class MapCamera : MonoBehaviour
{
    public float Speed = 0.1F;
    public float MaxTouchDelta = 0.2f;
    public Vector3 CameraMinTranslate = new Vector3(-2, -2, -5);
    public Vector3 CameraMaxTranslate = new Vector3(2, 2, 5);
    public Vector3 CameraMinRotate = new Vector3(10, -10, 0);
    public Vector3 CameraMaxRotate = new Vector3(60, 10, 0);
    public Transform MapRoot;

    private Camera _MainCamera;
    private TransformGesture _TransformGesture;
    private Vector3 _CurrentHit;
    private Vector3 _PreviousHit;
    private int _Touches;
    private float _ScaleDelta = 1f;
    private bool _Transforming;
    public Vector3 _TouchDelta;
    private Vector3 _PreviousDelta = Vector3.zero;
    private Vector3 _ViewAngle = Vector3.zero;

    private void OnEnable()
    {
        _TransformGesture = GetComponent<TransformGesture>();
        _TransformGesture.Transformed += TransformHandler;
    }

    private void OnDisable()
    {
        _TransformGesture.Transformed -= TransformHandler;
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
    }

    void Start ()
    {
        _MainCamera = Camera.main;
    }

    void Update()
    {
        if (_PreviousHit == Vector3.zero)
        { _PreviousHit = _CurrentHit; return; }

        _TouchDelta = new Vector3(_PreviousHit.x - _CurrentHit.x, _PreviousHit.y - _CurrentHit.y, _PreviousHit.z - _CurrentHit.z) * Speed;
        if (_TouchDelta.magnitude > MaxTouchDelta)
            _TouchDelta = _PreviousDelta;

        _PreviousHit = _CurrentHit;

        _ViewAngle = new Vector3(
            Mathf.Clamp(_ViewAngle.x + _TouchDelta.y, CameraMinRotate.x, CameraMaxRotate.x), 
            Mathf.Clamp(_ViewAngle.y - _TouchDelta.x, CameraMinRotate.y, CameraMaxRotate.y), 
            _ViewAngle.z);

        MapRoot.transform.localRotation = Quaternion.Euler(_ViewAngle.x, _ViewAngle.y, 0);

        if (_ScaleDelta != 1)
        {
            float Zoom = _MainCamera.transform.localPosition.z * _ScaleDelta;

            _MainCamera.transform.localPosition = new Vector3(
                _MainCamera.transform.localPosition.x, 
                _MainCamera.transform.localPosition.y, 
                Mathf.Clamp(Zoom, CameraMinTranslate.z, CameraMaxTranslate.z));
        }

        _PreviousDelta = _TouchDelta;
        _ScaleDelta = 1f;
    }
}
