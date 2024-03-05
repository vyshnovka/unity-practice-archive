using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    public static bool takeDamage = true;

    private void OnTriggerEnter(Collider other)
    {
        if (takeDamage)
        {
            other.transform.parent.GetComponent<CoinAddToStack>().RemoveCoin();

            Destroy(gameObject);
        }
    }
}
