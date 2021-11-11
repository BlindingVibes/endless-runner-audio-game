using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string endlessRunner;

    public void PlayGame()
    {
        SceneManager.LoadScene(endlessRunner);
    }

    public void QuitGame()
    {
        // Waits 1 second for quit sound to play
        StartCoroutine(QuitAfterDelay());
    }

    private IEnumerator QuitAfterDelay()
    {
        yield return new WaitForSeconds(1);
        Application.Quit();
    }
}
