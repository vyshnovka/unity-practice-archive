using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    [SerializeField]
    [Range(-100, 100)]
    private float rotationSpeedX = 0;

    [SerializeField]
    [Range(-100, 100)]
    private float rotationSpeedY = 0;

    void Start()
    {
        
    }

    void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.right, rotationSpeedX * Time.deltaTime);
        transform.RotateAround(target.transform.position, Vector3.up, rotationSpeedY * Time.deltaTime);

        transform.LookAt(target.transform);
    }
}
