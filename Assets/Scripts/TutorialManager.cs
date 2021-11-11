using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;

    public AudioMixer gameMixer;

    public ObstacleGenerator theObstacleGenerator;

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

    public GameObject blackScreen;

    public AudioSource actionSound;

    //public float distance;

    private PlatformDestroyer[] platformList;

    private ScoreManager theScoreManager;

    public TutorialDeathMenu theDeathMenu;

    public PauseMenu thePauseMenu;

    public float audioDelay;
    private float popUpDelay = 0.6f;
    private float endTimer;
    private float failTimer;
    private float audioTimer;

    private void Awake()
    {
        // TODO Get mode from user choice

        // Set obstacles used according to selected game mode
        if (Convert.ToBoolean(PlayerPrefs.GetInt("audio mode")))
        {
            jumpObstaclePool.SetPooledObject(jumpObstacleAudio);
            slideObstaclePool.SetPooledObject(slideObstacleAudio);
            //blackScreen.gameObject.SetActive(true);
        }
        else if (Convert.ToBoolean(PlayerPrefs.GetInt("haptic mode")))
        {
            jumpObstaclePool.SetPooledObject(jumpObstacleHaptic);
            slideObstaclePool.SetPooledObject(slideObstacleHaptic);
            //blackScreen.gameObject.SetActive(true);
        }
        else
        {
            jumpObstaclePool.SetPooledObject(jumpObstacleVisual);
            slideObstaclePool.SetPooledObject(slideObstacleVisual);
        }

        // TODO Get obstacle from user choice
        theObstacleGenerator.setObstacleType(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();

        // Initiate startpoint for obstacles and visual objects in the scene
        objectsStartPoint = new Vector3[theObjectGenerators.Length];

        for (int i = 0; i < theObjectGenerators.Length; i++)
        {
            objectsStartPoint[i] = theObjectGenerators[i].position;
        }

        playerStartPoint = thePlayer.transform.position;

        endTimer = popUpDelay;
        failTimer = popUpDelay;
        audioTimer = audioDelay;
        popUpIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (theScoreManager.successCount == 1)
        {
            popUpIndex = 0;
            if (endTimer > 0)
            {
                endTimer -= Time.deltaTime;
            }
            else
            {
                RestartGame();
            }
        }

        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }

        if (!thePauseMenu.isActiveAndEnabled)
        {


            if (popUpIndex == 1)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    popUpIndex++;
                }
            }
            else if (popUpIndex == 2)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    popUpIndex++;
                }
            }
            else if (popUpIndex == 3 && !thePauseMenu.isActiveAndEnabled)
            {
                theObstacleGenerator.transform.position = new Vector3(theObstacleGenerator.transform.position.x, theObstacleGenerator.transform.position.y, thePlayer.transform.position.z + 40);
                theObstacleGenerator.generateJumpObstacle(0);
                popUpIndex++;
            }
            else if (popUpIndex == 4)
            {
                if (theScoreManager.errorsCount == 1)
                {
                    if (failTimer > 0)
                    {
                        failTimer -= Time.deltaTime;
                    }
                    else
                    {
                        popUpIndex++;
                        failTimer = popUpDelay;
                        theObstacleGenerator.transform.position = new Vector3(theObstacleGenerator.transform.position.x, theObstacleGenerator.transform.position.y, thePlayer.transform.position.z + 40);
                        theObstacleGenerator.generateJumpObstacle(0);
                    }
                }
            }
            else if (popUpIndex == 5)
            {
                if (audioTimer > 0)
                {
                    audioTimer -= Time.deltaTime;
                }
                else
                {
                    popUpIndex++;
                    audioTimer = audioDelay;
                }
            }
            else if (popUpIndex == 6)
            {
                actionSound.Play();
                popUpIndex++;
            }
            else if (popUpIndex == 7)
            {
                if (theScoreManager.errorsCount == 2)
                {
                    if (failTimer > 0)
                    {
                        failTimer -= Time.deltaTime;
                    }
                    else
                    {
                        popUpIndex++;
                        failTimer = popUpDelay;
                        theObstacleGenerator.transform.position = new Vector3(theObstacleGenerator.transform.position.x, theObstacleGenerator.transform.position.y, thePlayer.transform.position.z + 40);
                        theObstacleGenerator.generateJumpObstacle(0);
                    }
                }
            }
            else if (popUpIndex == 8)
            {
                if (theScoreManager.errorsCount == 3)
                {
                    if (failTimer > 0)
                    {
                        failTimer -= Time.deltaTime;
                    }
                    else
                    {
                        popUpIndex++;
                        failTimer = popUpDelay;
                        theObstacleGenerator.transform.position = new Vector3(theObstacleGenerator.transform.position.x, theObstacleGenerator.transform.position.y, thePlayer.transform.position.z + 10);
                        theObstacleGenerator.setSpawnObstacles(true);
                    }
                }
            }
            else if (popUpIndex == 9)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    popUpIndex++;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!thePauseMenu.isActiveAndEnabled)
            {
                thePauseMenu.PauseGame();
            }
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

        theScoreManager.scoreCount = 0;
        theScoreManager.errorsCount = 0;
        theScoreManager.successCount = 0;
        theScoreManager.dead = false;

        endTimer = popUpDelay;
        popUpIndex = 1;
        theObstacleGenerator.setSpawnObstacles(false);
    }
}
