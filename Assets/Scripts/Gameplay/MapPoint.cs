using UnityEngine;
using System;
using System.Collections;
using TouchScript.Gestures;
using TouchScript.Hit;

public class MapPoint : MonoBehaviour
{
    public bool Unlocked;
    public MapLevel.Level Level = new MapLevel.Level();
    private PressGesture _PressGesture;
    public GameObject FrontEndUI;

    private void OnEnable()
    {
        _PressGesture = GetComponent<PressGesture>();
        _PressGesture.Pressed += PressHandler;
    }

    private void OnDisable()
    {
        _PressGesture.Pressed -= PressHandler;
    }

    private void PressHandler(object sender, EventArgs e)
    {
        var gesture = sender as PressGesture;
        HitData hit = gesture.GetScreenPositionHitData();
        Transform T = hit.Target.transform;

        if (T.gameObject == gameObject)
        {
            var FrontEndScript = FrontEndUI.GetComponent<uiFrontEnd>();
            FrontEndScript.OpenDialog();
            FrontEndScript.TitleText.text = MapLevel.NiceLevelNames[(int)Level];

            if (Unlocked)
            {
                FrontEndScript.LoadButton.SetActive(true);
                FrontEndScript.LockedButton.SetActive(false);
                MapLevel.SetLevelToLoad(Level);
            }
            else
            {
                FrontEndScript.LoadButton.SetActive(false);
                FrontEndScript.LockedButton.SetActive(true);
            }
        }
    }

    void Start ()
    {
        FrontEndUI = GameObject.FindGameObjectWithTag("UI");
	}

	void Update ()
    {
	
	}
}
