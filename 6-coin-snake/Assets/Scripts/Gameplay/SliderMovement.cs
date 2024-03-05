using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMovement : MonoBehaviour
{
    private Coroutine sliderRoutine;

    [SerializeField]
    private float maxToRotate = 1f;

    [SerializeField]
    [Range(-5, 5)]
    private float slideSpeed = 1f;

    void Start()
    {
        sliderRoutine = StartCoroutine(MoveSlider());
    }

    IEnumerator MoveSlider()
    {
        while (true)
        {
            transform.rotation = Quaternion.Euler(180, 270, maxToRotate * Mathf.Sin(slideSpeed * Time.time));

            yield return null;
        }
    }
}
