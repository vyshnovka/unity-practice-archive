using System;
using System.Collections.Generic;
using UnityEngine;

public class DataCollector : MonoBehaviour
{
    public int countLeft = 0;
    public int countRight = 0;

    public void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Bicyclist":
                TriggerDecision(other, 1);
                break;
            case "Obstacle":
                TriggerDecision(other, 2);
                break;
            case "Character":
                TriggerDecision(other, 3);
                break;
            default:
                break;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Bicyclist":
                TriggerDecision(other, -1);
                break;
            case "Obstacle":
                TriggerDecision(other, -2);
                break;
            case "Character":
                TriggerDecision(other, -3);
                break;
            default:
                break;
        }
    }

    public void TriggerDecision(Collider other, int power)
    {
        if (other.transform.position.x > transform.position.x)
        {
            countLeft += power;
        }
        else
        {
            countRight += power;
        }
    }
}
