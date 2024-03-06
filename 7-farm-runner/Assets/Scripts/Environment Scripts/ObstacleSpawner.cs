using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> obstacleList;

    [SerializeField]
    private Vector3 obstaclePosition;

    [SerializeField]
    private List<Vector3> initialObstacles;

    [SerializeField]
    private float timeToWait = 1f;

    private Coroutine obstacleRoutine = null;

    private void Start()
    {
        for (int i = 0; i < initialObstacles.Count; i++)
        {
            var item = Instantiate(obstacleList[Random.Range(0, obstacleList.Count)], initialObstacles[i], transform.rotation);

            item.GetComponent<EnvironmentMovement>().canMove = false;

            GlobalEvents.worldStart.AddListener(() => {
                item.GetComponent<EnvironmentMovement>().canMove = true;
            });
        }

        GlobalEvents.worldStart.AddListener(() =>
        {
            obstacleRoutine = StartCoroutine("ObstacleGenerator");
        });
    }

    IEnumerator ObstacleGenerator()
    {
        while (true)
        {
            Instantiate(obstacleList[Random.Range(0, obstacleList.Count)], obstaclePosition, transform.rotation);
            yield return new WaitForSeconds(timeToWait);
        }
    }
}
