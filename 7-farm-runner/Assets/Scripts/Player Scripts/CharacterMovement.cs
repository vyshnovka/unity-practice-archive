using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField] private GameObject character;
    private Animator movementAnimator;

    [SerializeField] private List<float> linesPositions = new List<float>();
    private int currentLineIndex = 1;
    private bool groundedPlayer;

    private Vector3 playerVelocity;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float jumpHeight = 1.0f;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        movementAnimator = character.GetComponent<Animator>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeLine(false);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeLine(true);
        }

        if (Input.GetKey(KeyCode.Space) && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);


        if (currentLineIndex > linesPositions.Count - 1)
        {
            currentLineIndex = linesPositions.Count - 1;
        }
        else if (currentLineIndex < 0)
        {
            currentLineIndex = 0;
        }

        transform.position = Vector3.Lerp(transform.position, new Vector3(linesPositions[currentLineIndex], transform.position.y, transform.position.z), 0.1f);


    }

    private void ChangeLine(bool isRight)
    {
        if (isRight)
        {
            currentLineIndex++;
        }
        else if (!isRight)
        {
            currentLineIndex--;
        }
    }

    public void TakeDamage()
    {
        character.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f);
        movementAnimator.SetTrigger("death");
    }
}