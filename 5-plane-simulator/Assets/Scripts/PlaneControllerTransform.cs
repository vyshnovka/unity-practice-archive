using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControllerTransform : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 1;

    [SerializeField]
    private float actionSpeed = 1;

    private float yawInput;
    private float pitchInput;
    private float rollInput;

    private float pitchTarget = 0;
    private float rollTarget = 0;
    private float yawTarget = 0;

    public static int speedCount = 1;
    private float currentSpeed;
    private float targetSpeed;

    [SerializeField]
    [Range(0, 0.5f)]
    private float smoothing = 0.01f;

    private void Start()
    {
        currentSpeed = movementSpeed;
        targetSpeed = movementSpeed;
    }

    void Update()
    {
        pitchInput = Input.GetAxis("Vertical");
        rollInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown("q"))
        {
            yawInput = -1;
        }
        else if (Input.GetKeyDown("e"))
        {
            yawInput = +1;
        }
        else if (Input.GetKeyUp("e") || Input.GetKeyUp("q"))
        {
            yawInput = 0;
        }

        if (Input.GetKeyDown("f") && speedCount < 5)
        {
            speedCount++;

            currentSpeed = targetSpeed;
            targetSpeed = movementSpeed * speedCount;
        }
        if (Input.GetKeyDown("r") && speedCount > 1)
        {
            speedCount--;

            currentSpeed = targetSpeed;
            targetSpeed = movementSpeed * speedCount;
        }

        transform.position += transform.forward * Mathf.Lerp(currentSpeed, targetSpeed, 0.5f);

        transform.position += -Vector3.up * 0.1f;

        yawTarget = Mathf.Lerp(yawTarget, yawInput, smoothing);
        pitchTarget = Mathf.Lerp(pitchTarget, pitchInput, smoothing);
        rollTarget = Mathf.Lerp(rollTarget, rollInput, smoothing);

        transform.eulerAngles += transform.right * pitchTarget * actionSpeed * speedCount;
        transform.eulerAngles += transform.up * yawTarget * actionSpeed * speedCount;
        transform.eulerAngles += transform.forward * -rollTarget * actionSpeed * speedCount;
    }
}
