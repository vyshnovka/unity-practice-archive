using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMovement : MonoBehaviour
{
    public float forwardSpeed = 1f;

    void Update()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        if (transform.position.x > 38.62f)
        {
            transform.position = new Vector3(38.62f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < 32.07f)
        {
            transform.position = new Vector3(32.07f, transform.position.y, transform.position.z);
        }
    }
}
