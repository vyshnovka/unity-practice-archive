using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCanvasManager : MonoBehaviour
{
    public static LevelCanvasManager instance;

    [SerializeField]
    private GameObject restartUI;

    [SerializeField]
    private GameObject nextUI;

    private void Start()
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

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void SetActiveDeadUI()
    {
        restartUI.SetActive(true);
    }

    public void SetActiveFinishedUI()
    {
        nextUI.SetActive(true);
    }
}
