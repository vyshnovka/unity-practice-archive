using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRandomizer : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject obstaclePart;

    public GameObject cubePrefab;

    public GameObject road;
    public GameObject roadPart;
    public GameObject roadHalfPart;

    public int roadSize = 100;

    public void Start()
    {
        randomizer();
    }

    /*public void roadBuild()
    {
        GameObject newRoadPart;
        int roadPositionZ;
        int roadPositionX;

        for (roadPositionZ = 6, roadPositionX = 9; roadPositionZ < roadSize; roadPositionZ += 6)
        {
            if (roadPositionZ < 204)
            {
                newRoadPart = Instantiate(roadPart, new Vector3(0, -0.55f, roadPositionZ), Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else
            {
                newRoadPart = Instantiate(roadPart, new Vector3(roadPositionX, -0.55f, 206), Quaternion.Euler(new Vector3(0, 90, 0)));
                roadPositionX += 6;
            }

            newRoadPart.transform.SetParent(road.transform);
        }

        randomizer();
    }*/

    public void randomizer()
    {
        GameObject newObstacle;
        int obstaclePositionZ;
        int obstaclePositionX;

        int obstacleCount;

        for (obstaclePositionZ = 20, obstaclePositionX = 20; obstaclePositionZ < 520; obstaclePositionZ += 20)
        {
            obstacleCount = UnityEngine.Random.Range(1, 4);

            if (obstaclePositionZ < 200)
            {
                for (int i = 0; i < obstacleCount; i++)
                {
                    newObstacle = Instantiate(obstaclePrefab, new Vector3(0, (obstaclePart.GetComponent<Renderer>().bounds.size.y + 0.2f) * i, obstaclePositionZ), Quaternion.Euler(new Vector3(0, 0, 0)));

                    if (i == obstacleCount - 1)
                    {
                        removePart(newObstacle);
                    }
                }
            }
            else
            {
                for (int i = 0; i < obstacleCount; i++)
                {
                    newObstacle = Instantiate(obstaclePrefab, new Vector3(obstaclePositionX, (obstaclePart.GetComponent<Renderer>().bounds.size.y + 0.2f) * i, 206), Quaternion.Euler(new Vector3(0, 90, 0)));

                    if (i == obstacleCount - 1)
                    {
                        removePart(newObstacle);
                    }
                }
                obstaclePositionX += 20;
            }
            
        }

        int cubePositionZ;
        int cubePositionX;

        int cubeCount;
        float cubeOffset;

        for (cubePositionZ = 10, cubePositionX = 10; cubePositionZ < 520; cubePositionZ += 20)
        {
            cubeCount = UnityEngine.Random.Range(1, 4);
            cubeOffset = UnityEngine.Random.Range(-2.3f, 2.3f);

            if (cubePositionZ < 206)
            {
                for (int i = 0; i < cubeCount; i++)
                {
                    Instantiate(cubePrefab, new Vector3(cubeOffset, cubePrefab.GetComponent<Renderer>().bounds.size.y * i + 0.1f, cubePositionZ), Quaternion.Euler(new Vector3(0, 0, 0)));
                }
            } 
            else
            {
                for (int i = 0; i < cubeCount; i++)
                {
                    Instantiate(cubePrefab, new Vector3(cubePositionX, cubePrefab.GetComponent<Renderer>().bounds.size.y * i + 0.1f, 206 + cubeOffset), Quaternion.Euler(new Vector3(0, 0, 0)));
                }
                cubePositionX += 20;
            }
        }
    }

    public void removePart(GameObject obstacle)
    {
        int count;
        int range;

        foreach (Transform child in obstacle.transform)
        {
            count = 0;
            range = UnityEngine.Random.Range(0, 4);

            while (count < range)
            {
                if (UnityEngine.Random.value > 0.5f)
                {
                    child.gameObject.SetActive(false);
                }

                count++;
            }
        }
    }
}
