using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    private bool flag = false;
    public GameObject LevelPanel;
    public GameObject MainMenuPanel;

    private int lastLevel;
    private int currentLevel;

    private void Start ()
    {
        if(LevelPanel != null)
            LevelPanel.SetActive(false);

        if(MainMenuPanel != null)
            MainMenuPanel.SetActive(true);

        lastLevel = SceneManager.sceneCountInBuildSettings - 3;
        currentLevel = SceneManager.GetActiveScene().buildIndex;

    }

    public void _StartBtn ()
    {
        //eventSistem.GetComponent<other>().playClickSound();
        StartCoroutine(waiter("level1"));
    }
    public void _StartSelectedLevel ()
    {
        string nameButton = EventSystem.current.currentSelectedGameObject.name;

        //eventSistem.GetComponent<other>().playClickSound();
        StartCoroutine(waiter(nameButton));
    }
    public void _StartTutorialLevel ()
    {
        //eventSistem.GetComponent<other>().playClickSound();
        StartCoroutine(waiter("TutorialLevel"));
    }
    public void _OpenSelectLevelPanel ()
    {
        flag = !flag;
        //eventSistem.GetComponent<other>().playClickSound();
        LevelPanel.SetActive(flag);
    }
    public void _ExitFromGame ()
    {
        //eventSistem.GetComponent<other>().playClickSound();
        Application.Quit();
    }
    public void _ExitToMenu ()
    {
        //eventSistem.GetComponent<other>().playClickSound();
        StartCoroutine(waiter(0));
    }
    public void _RestartLevel ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //eventSistem.GetComponent<other>().playClickSound();
        //StartCoroutine(waiter(SceneManager.GetActiveScene().buildIndex));
        //GameObject.Find("Charecter").GetComponent<CharecterControler>().Restart();
    }
    public void _StartNextLevel ()
    {
        //eventSistem.GetComponent<other>().playClickSound();
        Debug.Log(currentLevel + " " + lastLevel);

        if(currentLevel < lastLevel)
            StartCoroutine(waiter("Level" + (currentLevel + 1).ToString()));

        if(currentLevel == lastLevel)
            StartCoroutine(waiter("MainMenu"));
    }

    IEnumerator waiter (int ind)
    {
        yield return new WaitForSecondsRealtime(.1f);
        SceneManager.LoadScene(ind);
    }

    IEnumerator waiter (string ind)
    {
        yield return new WaitForSecondsRealtime(.1f);
        SceneManager.LoadScene(ind);
    }

}
