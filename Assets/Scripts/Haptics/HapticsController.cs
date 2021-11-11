using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticsController : MonoBehaviour
{

    // Variables for RayCaster System
    /*RaycastHit hit;
    float maxDistance;
    bool newDistance;*/

    // Variables for Next Obstacle System
    /*private GameObject nextObstacle;
    bool newObstacle;
    float maxDistance;
    float distance;*/

    private ArduinoCommunicator theArduinoCommunicator;


    private void Start()
    {
        theArduinoCommunicator = FindObjectOfType<ArduinoCommunicator>();
    }
    void Update()
    {
        /*
        // Queue System
        distance = nextObstacle.transform.position.z - transform.position.z;
        if (newObstacle)
        {
            maxDistance = distance;
            newObstacle = false;
        }

        print("Max distance to next obstacle is " + maxDistance);
        print("Vibration intensity is " + (100 - Mathf.Round(distance / maxDistance * 100)) + "%");


        // RayCaster System
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            float distance = hit.distance;

            if (newDistance)
            {
                maxDistance = distance;
                newDistance = false;
                print("New distance is " + maxDistance);
            }

            print("Max distance to next obstacle is " + maxDistance);
            print("Procentage of distance left is " + Mathf.Round(distance / maxDistance * 100) + "%");

            if (Mathf.Round(distance) == 0)
            {
                print("New distance ready");
                newDistance = true;
            }
            
        }

        theArduinoCommunicator.SendMessage("M0,1," + (100 - Mathf.Round(distance / maxDistance * 100)) + ",1000,1000;M1,0,80,1000,1000;M2,0,80,1000,1000;M3,0,80,1000,1000;");
        */
    }

    public void Hundred()
    {
        theArduinoCommunicator.SendMessage("M0,1,100,200,0;");
    }

    public void Ninety()
    {
        theArduinoCommunicator.SendMessage("M0,1,90,200,0;");
    }

    public void Eighty()
    {
        theArduinoCommunicator.SendMessage("M0,1,80,200,0;");
    }

    public void Seventy()
    {
        theArduinoCommunicator.SendMessage("M0,1,70,200,0;");
    }

    public void Sixty()
    {
        theArduinoCommunicator.SendMessage("M0,1,60,200,0;");
    }

    public void Fifty()
    {
        theArduinoCommunicator.SendMessage("M0,1,50,200,0;");
    }

    public void Fourty()
    {
        theArduinoCommunicator.SendMessage("M0,1,40,200,0;");
    }

    public void Thirty()
    {
        theArduinoCommunicator.SendMessage("M0,1,80,200,0;");
    }

    public void Twenty()
    {
        theArduinoCommunicator.SendMessage("M0,1,80,200,0;");
    }

    public void Ten()
    {
        theArduinoCommunicator.SendMessage("M0,1,80,200,0;");
    }

    public void Far()
    {
        theArduinoCommunicator.SendMessage("M0,1,100,500,0;");
    }

    public void Close()
    {
        theArduinoCommunicator.SendMessage("M0,1,100,300,0;");
    }

    public void Closest()
    {
        theArduinoCommunicator.SendMessage("M0,1,100,200,0;");
    }

    public void Now()
    {
        theArduinoCommunicator.SendMessage("M0,1,80,500,0;");
    }

    /*public void updateNextObstacle(GameObject nextObstacle)
    {
        this.nextObstacle = nextObstacle;
        newObstacle = true;
    }*/
}
