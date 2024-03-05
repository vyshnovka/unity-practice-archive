using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesMovement : MonoBehaviour
{
    private Coroutine spikeRoutine;

    [SerializeField]
    private float maxToMove = 1f;

    void Start()
    {
        spikeRoutine = StartCoroutine(MoveSpikesDown());
    }

    //problem with frames in maximize mod
    //TODO add * Time.deltaTime
    IEnumerator MoveSpikesDown()
    {
        float doneToMove = maxToMove;

        while (doneToMove > 0f)
        {
            transform.position -= transform.up * 0.01f;
            doneToMove -= 0.01f;

            yield return null;
        }

        spikeRoutine = StartCoroutine(MoveSpikesUp());
    }

    IEnumerator MoveSpikesUp()
    {
        float doneToMove = maxToMove;

        while (doneToMove > 0f)
        {
            transform.position += transform.up * 0.01f;
            doneToMove -= 0.01f;

            yield return null;
        }

        spikeRoutine = StartCoroutine(MoveSpikesDown());
    }
}
