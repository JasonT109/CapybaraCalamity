using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class uiFrontEnd : MonoBehaviour
{
    public Text TitleText;
    public GameObject LoadButton;
    public GameObject LockedButton;
    public GameObject UI;

    public void LoadLevel()
    {
        string Level = MapLevel.LevelToLoad;
        if (Level != "")
            SceneManager.LoadScene(Level);
    }

    public void DismissDialog()
    {
        UI.SetActive(false);
    }

    public void OpenDialog()
    {
        UI.SetActive(true);
    }

    void Start()
    {
        DismissDialog();
    }
}
