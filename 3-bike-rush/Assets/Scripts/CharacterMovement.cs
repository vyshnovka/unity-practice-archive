using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float forwardSpeed = 1f;
    public float sideSpeed = 1f;
    public float offset = 1f;

    private float startPosX;

    void Start()
    {
        startPosX = transform.position.x;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        float mouseX = Input.GetAxisRaw("Mouse X");

        if (Input.GetMouseButton(0))
        {
            transform.Translate(Vector3.right * mouseX * sideSpeed * Time.deltaTime);

            if (transform.position.x > startPosX + offset)
            {
                transform.position = new Vector3(startPosX + offset, transform.position.y, transform.position.z);
            }
            if (transform.position.x < startPosX - offset)
            {
                transform.position = new Vector3(startPosX - offset, transform.position.y, transform.position.z);
            }
        }
    }
}
