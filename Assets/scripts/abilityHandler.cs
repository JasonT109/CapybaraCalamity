using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class abilityHandler : MonoBehaviour {


    public int NumDiggers = 0;
    public int NumGnawers = 0;
    public int NumFloaters = 0;
    public int NumStoppers = 0;
    public float TimeLimit = 30.0f;
    public GameObject HolePrefab;
    private Vector3 HoleOffset = new Vector3(0, 0.145f, 0);

    public enum Abilities
    {
        None,
        Digger,
        Gnawer,
        Floater,
        Stopper
    }

    public Abilities CurrentAbility = new Abilities();

    private GameObject UICounter;
    private Text DiggerCountText;
    private Text GnawerCountText;
    private Text FloaterCountText;
    private Text StopperCountText;

    [HideInInspector]
    public int _InitDiggerCount;
    [HideInInspector]
    public int _InitGnawerCount;
    [HideInInspector]
    public int _InitFloaterCount;
    [HideInInspector]
    public int _InitStopperCount;

    void Start ()
    {
        _InitDiggerCount = NumDiggers;
        _InitGnawerCount = NumGnawers;
        _InitFloaterCount = NumFloaters;
        _InitStopperCount = NumStoppers;

        UICounter = GameObject.FindGameObjectWithTag("UI");
        var UICounterScript = UICounter.GetComponent<uiAbilityCounter>();

        DiggerCountText = UICounterScript.DiggerCountText.GetComponent<Text>();
        GnawerCountText = UICounterScript.GnawerCountText.GetComponent<Text>();
        FloaterCountText = UICounterScript.FloaterCountText.GetComponent<Text>();
        StopperCountText = UICounterScript.StopperCountText.GetComponent<Text>();

        DiggerCountText.text = "" + NumDiggers;
        GnawerCountText.text = "" + NumGnawers;
        FloaterCountText.text = "" + NumFloaters;
        StopperCountText.text = "" + NumStoppers;

        if (NumDiggers == 0)
            UICounterScript.DiggerToggle.interactable = false;
        if (NumFloaters == 0)
            UICounterScript.FloaterToggle.interactable = false;
        if (NumGnawers == 0)
            UICounterScript.GnawerToggle.interactable = false;
        if (NumStoppers == 0)
            UICounterScript.StopperToggle.interactable = false;

        UICounter.GetComponent<uiScore>().startTimer(TimeLimit);
    }
	
	void Update ()
    {
	    if (Input.GetMouseButtonDown(0))
        {
            Ray Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;
            if (Physics.Raycast(Ray.origin, Ray.direction, out Hit))
            {
                if (Hit.collider.tag == "agent")
                {
                    var SelectedAgent = Hit.collider.GetComponent<agent>();

                    if (CurrentAbility == Abilities.Digger && !SelectedAgent.Falling && SelectedAgent.FallSpeed < 0.01 && SelectedAgent.CanDig && NumDiggers > 0)
                    {
                        if (SelectedAgent.Ability == Abilities.Stopper)
                            SelectedAgent.ToggleStopper();

                        GameObject HoleClone = Instantiate(HolePrefab, Hit.transform.position - HoleOffset, Quaternion.identity) as GameObject;

                        var HoleScript = HoleClone.GetComponentInChildren<createHole>();
                        HoleScript.digger = Hit.transform.gameObject;

                        NumDiggers -= 1;
                        DiggerCountText.text = "" + NumDiggers;
                    }

                    if (CurrentAbility == Abilities.Stopper && !SelectedAgent.Falling && SelectedAgent.FallSpeed < 0.01)
                    {
                        if (SelectedAgent.Ability != Abilities.Stopper && NumStoppers > 0)
                        {
                            NumStoppers -= 1;
                            StopperCountText.text = "" + NumStoppers;
                            SelectedAgent.ToggleStopper();
                        }
                        else if (SelectedAgent.Ability == Abilities.Stopper)
                        {
                            SelectedAgent.ToggleStopper();
                        }
                        
                    }

                    if (CurrentAbility == Abilities.Gnawer && !SelectedAgent.Falling && SelectedAgent.FallSpeed < 0.01 && NumGnawers > 0)
                    {
                        if (SelectedAgent.Ability != Abilities.Gnawer)
                        {
                            NumGnawers -= 1;
                            GnawerCountText.text = "" + NumGnawers;
                        }
                        SelectedAgent.ToggleGnawer();
                    }

                    if (CurrentAbility == Abilities.Floater && NumFloaters > 0)
                    {
                        if (SelectedAgent.Ability != Abilities.Floater)
                        {
                            NumFloaters -= 1;
                            FloaterCountText.text = "" + NumFloaters;
                            SelectedAgent.ToggleFloater();
                        }
                    }
                }
            }
        }
	}

    public void ResetUICount()
    {
        NumDiggers = _InitDiggerCount;
        NumGnawers = _InitGnawerCount;
        NumFloaters = _InitFloaterCount;
        NumStoppers = _InitStopperCount;

        DiggerCountText.text = "" + NumDiggers;
        GnawerCountText.text = "" + NumGnawers;
        FloaterCountText.text = "" + NumFloaters;
        StopperCountText.text = "" + NumStoppers;
    }

    public void SetAbility (string Ability)
    {
        switch (Ability)
        {
            case "Digger":
                if (CurrentAbility == Abilities.Digger)
                    CurrentAbility = Abilities.None;
                else
                    CurrentAbility = Abilities.Digger;
                break;
            case "Gnawer":
                if (CurrentAbility == Abilities.Gnawer)
                    CurrentAbility = Abilities.None;
                else
                    CurrentAbility = Abilities.Gnawer;
                break;
            case "Floater":
                if (CurrentAbility == Abilities.Floater)
                    CurrentAbility = Abilities.None;
                else
                    CurrentAbility = Abilities.Floater;
                break;
            case "Stopper":
                if (CurrentAbility == Abilities.Stopper)
                    CurrentAbility = Abilities.None;
                else
                    CurrentAbility = Abilities.Stopper;
                break;
            default:
                break;
        }
    }
}
