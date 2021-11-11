using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseGenerator : MonoBehaviour
{
    public Transform generationPoint;
    public ObjectPooler[] theHousePools;

    private int houseSelector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < generationPoint.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 10);

            houseSelector = Random.Range(0, theHousePools.Length);

            GameObject newPlatform = theHousePools[houseSelector].getPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.SetActive(true);
        }
    }
}
