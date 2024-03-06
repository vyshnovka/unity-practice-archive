using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);

            ScoreManager.instance.AddScoreOnToken();
        }
    }
}
