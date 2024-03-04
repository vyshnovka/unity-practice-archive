using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static Action showWin;
    public static Action showFail;

    public GameObject startUI;
    public GameObject winUI;
    public GameObject failUI;

    public Button startButton;
    public Button nextButton;
    public Button reloadButton;

    public void Start()
    {
        showWin += showWinUI;
        showFail += showFailUI;

        winUI.SetActive(false);
        failUI.SetActive(false);

        Time.timeScale = 0;

        startButton.onClick.AddListener(startButtonPressed);

        nextButton.onClick.AddListener(buttonPressed);
        reloadButton.onClick.AddListener(buttonPressed);
    }

    public void showWinUI()
    {
        winUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void showFailUI()
    {
        failUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void buttonPressed()
    {
        SceneManager.LoadScene(0);
    }

    public void startButtonPressed()
    {
        startUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnDestroy()
    {
        showWin -= showWinUI;
        showFail -= showFailUI;
    }
}
