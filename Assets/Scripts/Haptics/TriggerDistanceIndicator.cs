using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDistanceIndicator : MonoBehaviour
{
    public int myDistance;

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
            switch (myDistance)
            {
                case 100:
                    theHapticsController.Hundred();
                    //theHapticsController.Far();
                    break;

                case 90:
                    theHapticsController.Ninety();
                    break;

                case 80:
                    theHapticsController.Eighty();
                    break;

                case 70:
                    theHapticsController.Seventy();
                    break;

                case 60:
                    theHapticsController.Sixty();
                    break;

                case 50:
                    theHapticsController.Fifty();
                    //theHapticsController.Close();
                    break;

                case 40:
                    theHapticsController.Fourty();
                    break;

                case 30:
                    theHapticsController.Thirty();
                    break;

                case 20:
                    theHapticsController.Twenty();
                    break;

                case 10:
                    theHapticsController.Ten();
                    //theHapticsController.Closest();
                    break;
            }
        }
    }

}
