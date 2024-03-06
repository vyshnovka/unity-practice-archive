using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterTrigger : MonoBehaviour
{
    public BoosterType type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BoosterManager.instance.ApplyBoost(type);
            Destroy(gameObject);
        }
    }
   
}

public enum BoosterType
{
    Magnet,
    DoubleScore,
    Shield
}
