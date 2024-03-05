using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public static CharacterMovement instance;

    private Rigidbody rb;

    [SerializeField]
    private float movementSpeed = 1;
    [SerializeField]
    private float rotationSpeed = 1;
    [SerializeField]
    private float jumpingSpeed = 1;

    private float rotationY;

    [SerializeField]
    private float roadOffset;
    [SerializeField]
    private float rotationOffset;

    private float isGrounded;

    void Start()
    {
        if (instance)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }

        rb = GetComponent<Rigidbody>();

        isGrounded = transform.position.y;
    }
    
    void FixedUpdate()
    {
        rotationY = Input.GetAxis("Horizontal");

        transform.position += transform.forward * movementSpeed;

        if (transform.position.z < -roadOffset)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -roadOffset);
        }
        if (transform.position.z > roadOffset)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, roadOffset);
        }

        if (transform.rotation.eulerAngles.y < (90 - rotationOffset))
        {
            transform.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, 90 - rotationOffset, transform.rotation.eulerAngles.z);
        }
        if (transform.rotation.eulerAngles.y > (90 + rotationOffset))
        {
            transform.eulerAngles = new Vector3(transform.rotation.eulerAngles.x, 90 + rotationOffset, transform.rotation.eulerAngles.z);
        }

        rb.AddTorque(transform.up * rotationY * rotationSpeed);
        rb.angularVelocity = Vector3.Lerp(rb.angularVelocity, Vector3.zero, 0.1f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y <= isGrounded)
        {
            rb.AddForce(Vector3.up * jumpingSpeed, ForceMode.Impulse);
        }
    }
}
