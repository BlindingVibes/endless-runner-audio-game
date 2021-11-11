using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public PlayerController thePlayer;

    private Vector3 lastPlayerPosition;
    private float distanceToMoveZ;
    private float distanceToMoveX;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        lastPlayerPosition = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToMoveZ = thePlayer.transform.position.z - lastPlayerPosition.z;
        distanceToMoveX = thePlayer.transform.position.x - lastPlayerPosition.x;

        transform.position = new Vector3(transform.position.x + distanceToMoveX, transform.position.y, transform.position.z + distanceToMoveZ);

        lastPlayerPosition = thePlayer.transform.position;
    }
}
