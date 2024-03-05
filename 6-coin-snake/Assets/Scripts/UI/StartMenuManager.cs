using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

    [SerializeField]
    private GameObject levels;

    public void StartGame()
    {
        menu.SetActive(false);
        levels.SetActive(true);
    }

    public void LoadLevel(Object sender)
    {
        SceneManager.LoadScene(sender.name);
    }
}
