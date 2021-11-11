using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] theObjectGenerators;
    private Vector3[] objectsStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    public ObjectPooler jumpObstaclePool;
    public ObjectPooler slideObstaclePool;

    public GameObject jumpObstacleVisual;
    public GameObject jumpObstacleAudio;
    public GameObject jumpObstacleHaptic;
    public GameObject slideObstacleVisual;
    public GameObject slideObstacleAudio;
    public GameObject slideObstacleHaptic;

    public float distance;

    private PlatformDestroyer[] platformList;

    private ScoreManager theScoreManager;

    public DeathMenu theDeathMenu;
    public PauseMenu thePauseMenu;

    enum Gamemode
    {
        Audio,
        Haptic,
        Visual
    }

    private Enum gamemode;

    private void Awake()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();

        jumpObstaclePool.SetPooledObject(jumpObstacleAudio);
            slideObstaclePool.SetPooledObject(slideObstacleAudio);
            gamemode = Gamemode.Audio;
            theScoreManager.SetGamemode(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initiate startpoint for obstacles and visual objects in the scene
        objectsStartPoint = new Vector3[theObjectGenerators.Length];

        for (int i = 0; i < theObjectGenerators.Length; i++)
        {
            objectsStartPoint[i] = theObjectGenerators[i].position;
        }

        playerStartPoint = thePlayer.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Resetting highscore");
            theScoreManager.ResetHighscore();
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (!thePauseMenu.isActiveAndEnabled && !theScoreManager.dead)
            {
                thePauseMenu.PauseGame();
            }
        }

        if (theScoreManager.errorsCount >= 1 && !theDeathMenu.isActiveAndEnabled)
        {
            RestartGame();
        }

        thePlayer.PauseState(thePauseMenu.isActiveAndEnabled);
    }

    public void RestartGame()
    {
        theScoreManager.dead = true;
        thePlayer.gameObject.SetActive(false);
        theDeathMenu.gameObject.SetActive(true);
    }

    public void Reset()
    {
        theDeathMenu.gameObject.SetActive(false);

        // Destroy objects so they can be reused when the game restarts
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        // Reset the players position
        thePlayer.transform.position = playerStartPoint;

        // Reset generation points
        for (int i = 0; i < theObjectGenerators.Length; i++)
        {
            theObjectGenerators[i].position = objectsStartPoint[i];
        }

        thePlayer.gameObject.SetActive(true);

        theScoreManager.Reset();
        thePlayer.RestartPlayer();
    }
}
