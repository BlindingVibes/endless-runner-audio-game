using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHapticsController : MonoBehaviour
{
    private ArduinoCommunicator theArduinoCommunicator;

    private void Start()
    {
        theArduinoCommunicator = FindObjectOfType<ArduinoCommunicator>();
    }

    public void MenuSelect()
    {
        theArduinoCommunicator.SendMessage("M0,1,80,150,0;");
    }
    public void MenuClick()
    {
        theArduinoCommunicator.SendMessage("M0,1,80,300,0;");
    }
}
