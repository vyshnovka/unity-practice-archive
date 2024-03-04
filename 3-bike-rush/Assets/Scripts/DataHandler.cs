using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    public float sideSpeed = 0.04f;
    public DataCollector DataCollector;

    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag("Untagged"))
        {
            if (DataCollector.countRight > DataCollector.countLeft)
            {
                transform.parent.position += Vector3.right * sideSpeed;
            }
            else
            {
                transform.parent.position += Vector3.left * sideSpeed;
            }
        }
    }
}
