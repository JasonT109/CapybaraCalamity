using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class uiScore : MonoBehaviour {

    public float totalNumAgents = 0;
    public float totalNumSaved = 0;
    public float totalNumLost = 0;
    public float percentageSaved = 0;
    public int pOneStar = 50;
    public int pTwoStar = 75;
    public int pThreeStar = 100;
    public Text scoreText;
    public Text timeLeft;
    private float timeRemaining;
    private float minutes;
    private float seconds;
    public bool levelComplete = false;
    private string fmt = "00.##";
    public void startTimer(float t)
    {
        timeRemaining = t;
    }

    public void addSavedUnit()
    {
        totalNumSaved += 1;
    }

    public void addLostUnit()
    {
        totalNumLost += 1;
    }

    public void resetScore()
    {
        totalNumSaved = 0;
        totalNumLost = 0;
        percentageSaved = 0;
        levelComplete = false;
    }

    // Update is called once per frame
    void Update () {

        if (totalNumSaved != 0 && totalNumAgents != 0)
        {
            percentageSaved = totalNumSaved / totalNumAgents * 100;
        }

        timeRemaining -= Time.deltaTime;

        scoreText.text = (percentageSaved.ToString("n0") + " / 100%");
        if (timeRemaining >= 0.0f && !levelComplete)
        {
            minutes = Mathf.Floor(timeRemaining / 60);
            seconds = ((timeRemaining / 60) - minutes) * 60;
            timeLeft.text = (minutes.ToString(fmt) + ":" + Mathf.Round(seconds).ToString(fmt));
        }
        
        if (totalNumSaved + totalNumLost == totalNumAgents && !levelComplete)
        {
            levelComplete = true;
            var menuScript = gameObject.GetComponent<menuStates>();
            if (percentageSaved >= pThreeStar)
            {
                menuScript.showResults(3);
                //Debug.Log("Level complete! Your score = ***");
            }
            else if (percentageSaved < pThreeStar && percentageSaved >= pTwoStar)
            {
                menuScript.showResults(2);
                //Debug.Log("Level complete! Your score = **");
            }
            else if (percentageSaved < pTwoStar && percentageSaved >= pOneStar)
            {
                menuScript.showResults(1);
                //Debug.Log("Level complete! Your score = *");
            }
            else
            {
                menuScript.showResults(0);
                //Debug.Log("Level failed!");
            }
        }
    }
}
