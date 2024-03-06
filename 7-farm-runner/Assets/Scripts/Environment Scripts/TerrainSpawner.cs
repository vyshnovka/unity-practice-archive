using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> terrainList;

    [SerializeField]
    private Vector3 terrainPosition;

    [SerializeField]
    private float timeToWait = 2f;

    private Coroutine terrainRoutine = null;

    [SerializeField]
    private List<EnvironmentMovement> initialTerrains;

    private void Awake()
    {
        GlobalEvents.worldStart.RemoveAllListeners();
    }

    void Start()
    {
        Invoke("BeginGame", 6f);

        GlobalEvents.worldStart.AddListener(() => {
            foreach (var item in initialTerrains)
            {
                item.canMove = true;
            }

            terrainRoutine = StartCoroutine("TerrainGenerator");
        });
    }

    IEnumerator TerrainGenerator()
    {
        while (true)
        {
            Instantiate(terrainList[Random.Range(0, terrainList.Count)], terrainPosition, transform.rotation);
            yield return new WaitForSeconds(timeToWait);
        }
    }

    void BeginGame()
    {
        GlobalEvents.worldStart.Invoke();
    }
}
