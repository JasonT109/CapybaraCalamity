using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class menuStates : MonoBehaviour {

    public bool isPaused = false;
    public GameObject abilityHandler;
    public GameObject abilityPanel;
    public GameObject pauseButton;
    public GameObject resetPanel;
    public GameObject resultsPanel;
    public Text resultsText;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject nextButton;
    public GameObject resetButton2;
    public GameObject homeButton2;
    private bool resultsScreen = false;

    void Start()
    {
        resultsPanel.SetActive(false);
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        nextButton.SetActive(false);
        resetButton2.SetActive(false);
        homeButton2.SetActive(false);
    }

    public void pauseGame()
    {
        if (!resultsScreen)
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Time.timeScale = 0;
                resetPanel.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                resetPanel.SetActive(false);
            }
        }
    }

    public void resetGame()
    {
        //find all agents and kill them
        GameObject[] agents = GameObject.FindGameObjectsWithTag("agent");
        foreach (GameObject a in agents)
        {
            Destroy(a);
        }

        //remove all tunnels and holes
        GameObject[] tunnels = GameObject.FindGameObjectsWithTag("tunnel");
        foreach (GameObject t in tunnels)
        {
            Destroy(t);
        }

        GameObject[] holes = GameObject.FindGameObjectsWithTag("hole");
        foreach (GameObject h in holes)
        {
            Destroy(h);
        }

        //reset abilities count
        var abilityScript = abilityHandler.GetComponent<abilityHandler>();
        abilityScript.ResetUICount();

        //reset score
        var scoreScript = gameObject.GetComponent<uiScore>();
        scoreScript.resetScore();
        scoreScript.startTimer(abilityScript.TimeLimit);

        //reset spawners
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("spawner");
        foreach (GameObject s in spawners)
        {
            spawner spawnerScript = s.GetComponent<spawner>();
            if (spawnerScript)
                spawnerScript.ResetSpawner();
        }

        if (!resultsScreen)
        {
            pauseGame();
        }
        else
        {
            //turn off results screen if it is active
            resultsScreen = false;
            resultsPanel.SetActive(false);
            abilityPanel.SetActive(true);
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
            nextButton.SetActive(false);
            resetButton2.SetActive(false);
            homeButton2.SetActive(false);
        }
    }

    public void showResults(int stars)
    {
        resultsScreen = true;
        StartCoroutine(doScale(0.1f, resultsPanel, 0.1f));
        StartCoroutine(doScale(1.4f, nextButton, 0.01f));
        StartCoroutine(doScale(1.6f, resetButton2, 0.01f));
        StartCoroutine(doScale(1.7f, homeButton2, 0.01f));
        abilityPanel.SetActive(false);
        pauseButton.SetActive(false);

        if (stars == 0)
        {
            resultsText.text = "Level Failed!";
        }
        else if (stars == 1)
        {
            resultsText.text = "Level Complete!";
            StartCoroutine(doScale(0.6f, star1, 5.0f));
        }
        else if (stars == 2)
        {
            resultsText.text = "Level Complete!";
            StartCoroutine(doScale(0.6f, star1, 5.0f));
            StartCoroutine(doScale(0.9f, star2, 5.0f));
        }
        else if (stars == 3)
        {
            resultsText.text = "Level Complete!";
            StartCoroutine(doScale(0.6f, star1, 5.0f));
            StartCoroutine(doScale(0.9f, star2, 5.0f));
            StartCoroutine(doScale(1.2f, star3, 5.0f));
        }
    }

    IEnumerator doScale(float waitTime, GameObject uiItem, float scaleFactor)
    {
        yield return new WaitForSeconds(waitTime);
        uiItem.SetActive(true);
        var scaleScript = uiItem.GetComponent<uiScaler>();
        scaleScript.scaleUI(scaleFactor);
    }

    public void loadNextLevel()
    {
        int loadedLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int numberOfLevels = SceneManager.sceneCountInBuildSettings;
        if (loadedLevelIndex != (numberOfLevels - 1))
        {
            Debug.Log("Loading next scene " + loadedLevelIndex++);
            SceneManager.LoadScene(loadedLevelIndex++, LoadSceneMode.Single);
        }
    }
}
