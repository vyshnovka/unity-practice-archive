using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class GlobalEvents
{
    public static UnityEvent worldStart = new UnityEvent();
}

public class EnvironmentMovement : MonoBehaviour
{
    [SerializeField]
    public EnvironmentMovementScriptable objectMovementValues;

    public bool canMove = true;

    void FixedUpdate()
    {
        if (canMove)
        {
            transform.position -= transform.forward * objectMovementValues.movementSpeed;
        }
    }
}
