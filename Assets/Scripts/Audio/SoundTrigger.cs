using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    private AudioSource theActionIndicator;

    // Start is called before the first frame update
    void Start()
    {
        theActionIndicator = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            theActionIndicator.PlayOneShot(theActionIndicator.clip);
        }
    }

}
