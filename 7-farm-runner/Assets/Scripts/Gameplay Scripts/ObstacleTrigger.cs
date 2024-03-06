using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{
    public static bool isShield = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!isShield)
            {
                other.GetComponent<CharacterMovement>().TakeDamage();

                Time.timeScale = 0;
                GameOverScript.instance.RestartUI();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
