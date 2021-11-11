using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public float offsetRange;

    public Transform generationPoint;

    private int obstacleTypeSelector;

    public ObjectPooler[] theObstaclePools;

    public bool spawnObstacles;
    public bool randomizeObstacles;

    //public NextObstacleQueue nextObjectQueue;

    private void Update()
    {
        if (transform.position.z < generationPoint.position.z)
        {
            float randomOffset = Random.Range(-offsetRange, offsetRange);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + randomOffset + (20 + offsetRange));

            if (randomizeObstacles)
            {
                obstacleTypeSelector = Random.Range(0, theObstaclePools.Length);
            }

            if (spawnObstacles)
            {

                if (obstacleTypeSelector == 0)
                {
                    generateJumpObstacle(obstacleTypeSelector);
                }
                else if (obstacleTypeSelector == 1)
                {
                    //generateJumpObstacle(0);
                    generateSlideObstacle(obstacleTypeSelector);
                }

            }

            //nextObjectQueue.Enqueue(newObstacle);
        }
    }

    public void generateJumpObstacle(int obstacleTypeSelector)
    {
        GameObject newObstacle = theObstaclePools[obstacleTypeSelector].getPooledObject();
        newObstacle.transform.position = transform.position;
        newObstacle.SetActive(true);
    }
    private void generateSlideObstacle(int obstacleTypeSelector)
    {
        GameObject newObstacle = theObstaclePools[obstacleTypeSelector].getPooledObject();
        newObstacle.transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y + 0.75f, transform.position.z);
        newObstacle.SetActive(true);
    }

    public void spawnObstacle(Vector3 position)
    {
        float randomOffset = Random.Range(-offsetRange, offsetRange);

        GameObject obstacle1 = theObstaclePools[obstacleTypeSelector].getPooledObject();
        position = new Vector3(position.x, position.y, position.z + randomOffset);
        obstacle1.transform.position = position;
        obstacle1.SetActive(true);

    }

    internal void setObstacleType(int obstacleType)
    {
        obstacleTypeSelector = obstacleType;
    }

    internal void setSpawnObstacles(bool spawnObstacles)
    {
        this.spawnObstacles = spawnObstacles;
    }
}
