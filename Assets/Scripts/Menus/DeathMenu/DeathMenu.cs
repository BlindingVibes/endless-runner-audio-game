using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    public string mainMenu;

    public Text Score;
    public Text Highscore;

    private ScoreManager theScoreManager;

    private void Awake()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Reset();
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    private void OnEnable()
    {
        Score.text = "Score: " + Mathf.Round(theScoreManager.scoreCount);
        Highscore.text = "Highscore: " + Mathf.Round(theScoreManager.highScoreCount);
    }
}
