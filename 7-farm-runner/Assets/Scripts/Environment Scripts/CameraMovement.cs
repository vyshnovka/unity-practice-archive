using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Vector3 targetPosition;

    [SerializeField]
    private Vector3 targetRotation;

    void Start()
    {
        Invoke("BeginCameraMovement", 5.7f);
    }

    void BeginCameraMovement()
    {
        StartCoroutine(CameraBegin());
    }

    IEnumerator CameraBegin()
    {
        while (transform.position != targetPosition && transform.eulerAngles != targetRotation)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, 0.05f);
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetRotation, 0.1f);

            yield return new WaitForEndOfFrame();
        }
    }
}
