using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class CubeMovement : MonoBehaviour
{
    public float forwardSpeed = 1f;
    public float sideSpeed = 1f;

    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxisRaw("Mouse X");

            GetComponent<SplineFollower>().offsetModifier.keys[0].offset += Vector2.right * mouseX * sideSpeed * Time.deltaTime;

            if (GetComponent<SplineFollower>().offsetModifier.keys[0].offset.x < -2.2f)
            {
                GetComponent<SplineFollower>().offsetModifier.keys[0].offset.x = -2.2f;
            }

            if (GetComponent<SplineFollower>().offsetModifier.keys[0].offset.x > 2.2f)
            {
                GetComponent<SplineFollower>().offsetModifier.keys[0].offset.x = 2.2f;
            }
        }
    }
}
