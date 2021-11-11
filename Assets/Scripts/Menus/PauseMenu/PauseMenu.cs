using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public string mainMenu;

    public GameObject thePauseMenu;

    public Button theResumeButton;

    /*private AudioSource endlessRunnerMusic;
    private AudioSource MenuHover;
    private AudioSource MenuClick;*/

    private void Awake()
    {
        /*endlessRunnerMusic = GameObject.Find("EndlessRunnerMusic").GetComponent<AudioSource>();
        MenuHover = GameObject.Find("Menu_Hover").GetComponent<AudioSource>();
        MenuClick = GameObject.Find("Menu_Click").GetComponent<AudioSource>();


        endlessRunnerMusic.ignoreListenerPause = true;
        MenuHover.ignoreListenerPause = true;
        MenuClick.ignoreListenerPause = true;*/
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        thePauseMenu.SetActive(true);
        //theResumeButton.Select();
        //PauseGameMusic(true);
    }

    public void ResumeGame()
    {
        thePauseMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGameMusic(false);
    }

    public void RestartGame()
    {
        thePauseMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGameMusic(false);
        FindObjectOfType<GameManager>().Reset();
    }

    public void QuitToMainMenu()
    {
        thePauseMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGameMusic(false);
        SceneManager.LoadScene(mainMenu);
    }

    private void PauseGameMusic(bool state)
    {
        AudioListener.pause = state;
    }
}
