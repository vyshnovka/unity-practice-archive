using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform targetCamera;
    [SerializeField]
    private Transform currentCamera;

    [SerializeField]
    [Range(0, 1)]
    private float smoothCamera = 0.2f;

    void FixedUpdate()
    {
        currentCamera.position = targetCamera.position;
        //currentCamera.position = Vector3.Lerp(currentCamera.position, targetCamera.position, smoothCamera);
        currentCamera.rotation = Quaternion.Lerp(currentCamera.rotation, targetCamera.rotation, smoothCamera);
    }
}
