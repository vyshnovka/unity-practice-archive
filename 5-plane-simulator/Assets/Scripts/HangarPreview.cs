using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangarPreview : MonoBehaviour
{
    [SerializeField]
    private GameObject targetObject;

    [SerializeField]
    [Range(0, 100)]
    private float cameraSpeed = 1;

    private float horizontalInput;
    private float verticalInput;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.position += transform.right * horizontalInput * cameraSpeed;
        transform.position += transform.forward * verticalInput * cameraSpeed;

        transform.LookAt(targetObject.transform);
    }
}
