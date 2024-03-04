using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "BotBody":
                if (transform.position.z > other.transform.position.z)
                {
                    Destroy(other.transform.parent.gameObject);
                }
                else
                {
                    Destroy(transform.parent.gameObject);
                }
                break;
            case "CharacterBody":
            case "Obstacle":
                Destroy(transform.parent.gameObject);
                break;
            default:
                break;
        }
    }
}
