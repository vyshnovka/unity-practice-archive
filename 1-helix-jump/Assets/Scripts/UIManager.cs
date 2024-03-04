using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public enum States
    {
        Play, Win, Loose
    }

    public static States state;

    [SerializeField]
    private GameObject GameplayUI;
    [SerializeField]
    private GameObject WinUI;
    [SerializeField]
    private GameObject LooseUI;

    public static int currentLevel;

    [SerializeField]
    private Slider progressSlider;
    [SerializeField]
    private Text currentNumber;
    [SerializeField]
    private Text nextNumber;

    void Awake()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
    }

    void Start()
    {
        WinUI.SetActive(false);
        LooseUI.SetActive(false);
    }

    void Update()
    {
        currentNumber.text = currentLevel.ToString();
        nextNumber.text = (currentLevel + 1).ToString();

        progressSlider.value = ScoreManager.passedRings * 100 / 18;

        switch (state)
        {
            case States.Win:
                WinUI.SetActive(true);
                PlayerPrefs.SetInt("CurrentLevel", currentLevel + 1);

                if (Input.GetMouseButtonDown(0))
                {
                    WinUI.SetActive(false);
                    state = States.Play;

                    if (SceneManager.GetActiveScene().buildIndex == 4)
                    {
                        SceneManager.LoadScene(0);
                    }
                    else
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    }
                }
                break;

            case States.Loose:
                LooseUI.SetActive(true);
                Time.timeScale = 0;

                if (Input.GetMouseButtonDown(0))
                {
                    Time.timeScale = 1;
                    LooseUI.SetActive(false);
                    state = States.Play;

                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                break;

            default:
                break;
        }
    }
}
