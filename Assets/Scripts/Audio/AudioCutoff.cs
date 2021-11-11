using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCutoff : MonoBehaviour
{
    // To find the sweet spot for the cutoff. 
    public float cutoffOffset; 

    private GameObject thePlayer;
    private AudioSource myAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = GameObject.Find("Player");
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (thePlayer.transform.position.z > transform.position.z + cutoffOffset)
        {
            myAudioSource.Stop();
        }
    }
}
