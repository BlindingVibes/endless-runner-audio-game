using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActionIndicator : MonoBehaviour
{
    private HapticsController theHapticsController;

    // Start is called before the first frame update
    void Start()
    {
        theHapticsController = FindObjectOfType<HapticsController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            theHapticsController.Now();
        }
    }
}
