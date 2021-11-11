using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public Transform generationPoint;

    private float platformLength = 10;

    public ObjectPooler thePlatformPool;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < generationPoint.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + platformLength);
            
            GameObject newPlatform = thePlatformPool.getPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.SetActive(true);
        }
    }
}
