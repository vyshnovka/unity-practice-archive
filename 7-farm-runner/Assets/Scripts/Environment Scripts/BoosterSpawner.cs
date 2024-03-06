using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> boosterList;

    [SerializeField]
    private Vector3 boosterPosition;

    [SerializeField]
    private float timeToWait = 2f;

    private Coroutine boosterRoutine = null;

    private void Start()
    {
        GlobalEvents.worldStart.AddListener(() =>
        {
            boosterRoutine = StartCoroutine("BoosterGenerator");
        });
    }

    IEnumerator BoosterGenerator()
    {
        while (true)
        {
            if (Random.value < 0.5f)
            {
                Instantiate(boosterList[Random.Range(0, boosterList.Count)], boosterPosition, transform.rotation);
            }
            yield return new WaitForSeconds(timeToWait);
        }
    }
}
