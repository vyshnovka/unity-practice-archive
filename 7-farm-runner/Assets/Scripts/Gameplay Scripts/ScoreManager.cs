using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private int tokenValue = 1;

    [NonSerialized]
    public int score = 0;

    [NonSerialized]
    public int moreScore = 1;

    private Coroutine scoreRoutine = null;

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

    void Start()
    {
        scoreRoutine = StartCoroutine(AddScore());
        Time.timeScale = 1;
    }

    IEnumerator AddScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            score++;
            scoreText.text = score.ToString();
        }
    }

    public void AddScoreOnToken()
    {
        score += tokenValue * moreScore;

        scoreText.text = score.ToString();
    }
}
