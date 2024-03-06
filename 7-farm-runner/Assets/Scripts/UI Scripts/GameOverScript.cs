using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public static GameOverScript instance;

    [SerializeField]
    private GameObject restartUI;
    [SerializeField]
    private GameObject gameplayUI;

    [SerializeField]
    private Text scoreText;

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

    public void RestartUI()
    {
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + ScoreManager.instance.score);
        scoreText.text = ScoreManager.instance.score.ToString();

        gameplayUI.SetActive(false);
        restartUI.SetActive(true);
    }
}
