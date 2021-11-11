using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialDeathMenu : MonoBehaviour
{
    public string mainMenu;

    public void RestartGame()
    {
        FindObjectOfType<TutorialManager>().Reset();
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
