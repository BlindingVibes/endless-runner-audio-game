using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;

    public float scoreCount;
    public float highScoreCount;
    public int errorsCount;
    public int successCount;

    public float pointsPerSecond;

    public bool dead;

    private string highScoreKeyAudio = "HighScore audio";
    private string highScoreKeyHaptic = "HighScore haptic";
    private string highScoreKeyVisual = "HighScore visual";

    private int gamemode;

    // Start is called before the first frame update
    void Start()
    {
        if (gamemode == 0)
        {
            highScoreCount = PlayerPrefs.GetFloat(highScoreKeyAudio, 0);
        } else if (gamemode == 1)
        {
            highScoreCount = PlayerPrefs.GetFloat(highScoreKeyHaptic, 0);
        } else
        {
            highScoreCount = PlayerPrefs.GetFloat(highScoreKeyVisual, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            if (gamemode == 0)
            {
                PlayerPrefs.SetFloat(highScoreKeyAudio, highScoreCount);
            }
            else if (gamemode == 1)
            {
                PlayerPrefs.SetFloat(highScoreKeyHaptic, highScoreCount);
            }
            else
            {
                PlayerPrefs.SetFloat(highScoreKeyVisual, highScoreCount);
            }
        }

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highScoreText.text = "High Score: " + Mathf.Round(highScoreCount);
    }

    public void addErrorCount()
    {
        errorsCount++;
    }

    public void applyPenalty(float amount)
    {
        scoreCount -= 0;
    }

    public void AddSuccessCount()
    {
        successCount++;
    }

    public void Reset()
    {
        scoreCount = 0;
        errorsCount = 0;
        successCount = 0;
        dead = false;
    }

    internal void ResetHighscore()
    {
        highScoreCount = 0;
        PlayerPrefs.SetFloat(highScoreKeyAudio, highScoreCount);
        PlayerPrefs.SetFloat(highScoreKeyHaptic, highScoreCount);
        PlayerPrefs.SetFloat(highScoreKeyVisual, highScoreCount);
        highScoreText.text = "High Score: 0";
    }

    public void SetPointsPerSecond(float pointsPerSecond)
    {
        this.pointsPerSecond = pointsPerSecond;
    }

    public void SetGamemode(int value)
    {
        this.gamemode = value;
    }
}
