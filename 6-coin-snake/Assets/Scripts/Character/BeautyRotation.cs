using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeautyRotation : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 1;

    void FixedUpdate()
    {
        transform.eulerAngles += Vector3.up * rotationSpeed;
    }
}
