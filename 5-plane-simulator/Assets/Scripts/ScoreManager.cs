using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private int coinValue = 10;

    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins", 1000) + coinValue);
        Destroy(gameObject);
    }
}
