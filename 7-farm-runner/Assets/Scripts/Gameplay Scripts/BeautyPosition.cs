using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeautyPosition : MonoBehaviour
{
    private Coroutine boosterRoutine;

    [SerializeField]
    private float maxToRotate = 1f;

    [SerializeField]
    [Range(1, 5)]
    private float rotateSpeed = 1f;

    void Start()
    {
        boosterRoutine = StartCoroutine(RotateBooster());
    }

    IEnumerator RotateBooster()
    {
        while (true)
        {
            transform.rotation = Quaternion.Euler(0, 0, maxToRotate * Mathf.Sin(rotateSpeed * Time.time));

            yield return null;
        }
    }
}
