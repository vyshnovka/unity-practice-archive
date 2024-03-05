using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlaneControllerRigidbody : MonoBehaviour
{
    private Rigidbody rb;
    private TrailRenderer trail;

    [SerializeField]
    private float movementSpeed = 1;
    private float currentSpeed;

    [SerializeField]
    private float actionSpeed = 1;

    private float pitchInput;
    private float yawInput;
    private float rollInput;

    //private float speedCount = 0;

    private bool pitchButtonPressed = false;
    private bool yawButtonPressed = false;
    private bool rollButtonPressed = false;
    private bool nitroButtonPressed = false;

    void Start()
    {
        trail = GetComponentInChildren<TrailRenderer>();
        rb = GetComponent<Rigidbody>();

        currentSpeed = movementSpeed;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Hangar");
        }


        if (!pitchButtonPressed)
        {
            pitchInput = Input.GetAxis("Vertical");
        }

        if (!yawButtonPressed)
        {
            yawInput = Input.GetAxis("Horizontal");
        }

        if (!rollButtonPressed)
        {
            if (Input.GetKey("q"))
            {
                rollInput = -1;
            }
            else if (Input.GetKey("e"))
            {
                rollInput = +1;
            }
            else if (!Input.GetKey("e") && !Input.GetKey("q"))
            {
                rollInput = 0;
            }
        }

        //if (Input.GetKey("f"))
        //{
        //    speedCount += 0.001f;
        //}
        //if (Input.GetKey("r"))
        //{
        //    speedCount -= 0.001f;
        //}

        if (!nitroButtonPressed)
        {
            if (Input.GetKey("space"))
            {
                currentSpeed = movementSpeed * 2f;
                trail.enabled = true;
            }
            else
            {
                currentSpeed = movementSpeed;
                trail.enabled = false;
            }
        }

        //ignores collision
        //rb.MovePosition(transform.position + transform.forward * (movementSpeed + 2 * speedCount));
        rb.AddForce(transform.forward * currentSpeed);

        //causes cringe turbulence
        //rb.velocity = Vector3.Lerp(rb.velocity + (rb.velocity * speedCount), Vector3.zero, 0.1f);
        rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, 0.1f);

        rb.AddTorque(transform.right * actionSpeed * pitchInput);
        rb.AddTorque(transform.up * actionSpeed * yawInput);

        rb.angularVelocity = Vector3.Lerp(rb.angularVelocity, Vector3.zero, 0.1f);

        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, 0, -rollInput));
    }

    public void OnPointerDown(GameObject sender)
    {
        switch (sender.name)
        {
            case "Up":
                pitchButtonPressed = true;
                pitchInput = 1;
                break;
            case "Down":
                pitchButtonPressed = true;
                pitchInput = -1;
                break;
            case "Right":
                yawButtonPressed = true;
                yawInput = 1;
                break;
            case "Left":
                yawButtonPressed = true;
                yawInput = -1;
                break;
            case "RotateRight":
                rollButtonPressed = true;
                rollInput = 1;
                break;
            case "RotateLeft":
                rollButtonPressed = true;
                rollInput = -1;
                break;
            case "Nitro":
                nitroButtonPressed = true;
                currentSpeed = movementSpeed * 2f;
                break;
        }
    }

    public void OnPointerUp(GameObject sender)
    {
        switch (sender.name)
        {
            case "Up":
                pitchButtonPressed = false;
                pitchInput = 0;
                break;
            case "Down":
                pitchButtonPressed = false;
                pitchInput = 0;
                break;
            case "Right":
                yawButtonPressed = false;
                yawInput = 0;
                break;
            case "Left":
                yawButtonPressed = false;
                yawInput = 0;
                break;
            case "RotateRight":
                rollButtonPressed = false;
                rollInput = 0;
                break;
            case "RotateLeft":
                rollButtonPressed = false;
                rollInput = 0;
                break;
            case "Nitro":
                nitroButtonPressed = false;
                currentSpeed = movementSpeed;
                break;
        }
    }
}
