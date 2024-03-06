using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoosterManager : MonoBehaviour
{
    public static BoosterManager instance;

    [SerializeField] 
    private GameObject magnetZone;

    [SerializeField] 
    private int boosterDuration;
    [SerializeField] 
    private List<GameObject> boostersIcons;

    void Awake()
    {
        if (instance)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }

    public void ApplyBoost(BoosterType type)
    {
        switch (type)
        {
            case BoosterType.DoubleScore:
                StartCoroutine(MoreScoreRoutine());
                break;
            case BoosterType.Magnet:
                StartCoroutine(MagnetRoutine());
                break;
            case BoosterType.Shield:
                StartCoroutine(ShieldRoutine());
                break;
        }
    }

    IEnumerator MoreScoreRoutine()
    {
        boostersIcons[0].SetActive(true);
        ScoreManager.instance.moreScore *= 2;
        yield return new WaitForSeconds(boosterDuration);

        boostersIcons[0].SetActive(false);
        ScoreManager.instance.moreScore /= 2;
    }

    IEnumerator MagnetRoutine()
    {
        boostersIcons[1].SetActive(true);
        magnetZone.SetActive(true);
        yield return new WaitForSeconds(boosterDuration);

        boostersIcons[1].SetActive(false);
        magnetZone.SetActive(false);
    }

    IEnumerator ShieldRoutine()
    {
        boostersIcons[2].SetActive(true);
        ObstacleTrigger.isShield = true;
        yield return new WaitForSeconds(boosterDuration);

        boostersIcons[2].SetActive(false);
        ObstacleTrigger.isShield = false;
    }
}
