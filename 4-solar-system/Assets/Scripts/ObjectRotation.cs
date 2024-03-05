using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [SerializeField]
    [Range(-200, 200)]
    private float rotationSpeedY = 0;

    [SerializeField]
    [Range(-200, 200)]
    private float rotationSpeedZ = 0;

    void Start()
    {
        
    }

    void Update()
    {
        transform.eulerAngles += Vector3.up * rotationSpeedY * Time.deltaTime;
        transform.eulerAngles += Vector3.forward * rotationSpeedZ * Time.deltaTime;
    }
}
