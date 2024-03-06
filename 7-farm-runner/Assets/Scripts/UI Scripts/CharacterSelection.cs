using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> characterList;

    [SerializeField]
    private Button leftButton;
    [SerializeField]
    private Button rightButton;
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button buyButton;

    [SerializeField]
    private Text priceText;
    [SerializeField]
    private Text scoreText;

    private int characterNumber;

    private int score;

    void Start()
    {
        PlayerPrefs.SetInt(characterList[0].name, 1);
        score = PlayerPrefs.GetInt("Coins", 0);
        scoreText.text = score.ToString();

        characterNumber = PlayerPrefs.GetInt("ChoosenCharacter", 0);

        characterList[characterNumber].SetActive(true);

        if (PlayerPrefs.GetInt(characterList[characterNumber].name, 0) == 0)
        {
            startButton.gameObject.SetActive(false);
            buyButton.gameObject.SetActive(true);
            priceText.text = characterList[characterNumber].GetComponent<CharacterInfo>().price.ToString() + " $";
        }
        else
        {
            startButton.gameObject.SetActive(true);
            buyButton.gameObject.SetActive(false);
        }

        leftButton.onClick.AddListener(() => ChoosenCharacter(false));
        rightButton.onClick.AddListener(() => ChoosenCharacter(true));
        buyButton.onClick.AddListener(BuyCharacter);

    }

    void ChoosenCharacter(bool direction)
    {
        characterList[characterNumber].SetActive(false);

        if (direction)
        {
            characterNumber++;
        }
        else
        {
            characterNumber--;
        }

        if (characterNumber >= characterList.Count)
        {
            characterNumber = 0;
        }
        else if (characterNumber < 0)
        {
            characterNumber = characterList.Count - 1;
        }

        characterList[characterNumber].SetActive(true);

        

        PlayerPrefs.SetInt("ChoosenCharacter", characterNumber);
        if (PlayerPrefs.GetInt(characterList[characterNumber].name, 0) == 0)
        {
            startButton.gameObject.SetActive(false);
            buyButton.gameObject.SetActive(true);
            priceText.text = characterList[characterNumber].GetComponent<CharacterInfo>().price.ToString() + " $";
        }
        else
        {
            startButton.gameObject.SetActive(true);
            buyButton.gameObject.SetActive(false);
        }


    }

    public void BuyCharacter()
    {
        if (score >= characterList[characterNumber].GetComponent<CharacterInfo>().price)
        {
            score -= characterList[characterNumber].GetComponent<CharacterInfo>().price;

            PlayerPrefs.SetInt(characterList[characterNumber].name, 1);

            PlayerPrefs.SetInt("Coins", score);
            scoreText.text = score.ToString();

            startButton.gameObject.SetActive(true);
            buyButton.gameObject.SetActive(false);
        }
    }
}
