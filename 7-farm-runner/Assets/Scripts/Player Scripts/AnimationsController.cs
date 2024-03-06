using UnityEngine;

public class AnimationsController : MonoBehaviour
{
    Animator animator;
    int isRunningHash;

    void Start()
    {
        animator = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash("isRunning");
    }

    void Update()
    {
        bool forwardRun = Input.GetKey(KeyCode.W);
        bool jumping = Input.GetKeyDown(KeyCode.Space);
        bool leftForward = Input.GetKeyDown(KeyCode.A);
        bool rightForward = Input.GetKeyDown(KeyCode.D);

        bool isRunning = animator.GetBool(isRunningHash);

        if (!isRunning && forwardRun)
        {
            animator.SetBool(isRunningHash, true);
        }
        else if (isRunning && !forwardRun)
        {
            animator.SetBool(isRunningHash, false);
        }

        if (jumping)
        {
            animator.SetTrigger("jump");
        }

        if (leftForward)
        {
            animator.SetTrigger("left");
        }
        else if (rightForward)
        {
            animator.SetTrigger("right");
        }
    }
}
