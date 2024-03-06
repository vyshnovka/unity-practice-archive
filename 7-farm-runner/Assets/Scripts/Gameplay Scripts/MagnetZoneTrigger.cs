using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetZoneTrigger : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float smoothness;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Token")) 
            StartCoroutine(SmoothTokenMove(other.gameObject));
    }

    IEnumerator SmoothTokenMove(GameObject other)
    {
        while (other)
        {
            other.transform.position = Vector3.Lerp(other.transform.position, player.transform.position, smoothness);
            yield return new WaitForEndOfFrame();
        }
    }
}
