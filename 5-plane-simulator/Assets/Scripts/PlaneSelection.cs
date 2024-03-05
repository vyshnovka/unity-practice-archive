using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlaneSelection : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> planeList;

    [SerializeField]
    private Button prevButton;
    [SerializeField]
    private Button nextButton;

    [SerializeField]
    private Button startButton;

    [SerializeField]
    private Button buyButton;
    [SerializeField]
    private Text priceText;

    private int planeNumber;

    [SerializeField]
    private Text scoreText;

    public static int score;

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt(planeList[0].name, 1);

        score = PlayerPrefs.GetInt("Coins", 1000);
        scoreText.text = score.ToString() + " $";

        planeNumber = PlayerPrefs.GetInt("ChoosenPlane", 0);

        planeList[planeNumber].SetActive(true);

        SetChoosenPlaneColor();

        if (PlayerPrefs.GetInt(planeList[planeNumber].name, 0) == 0)
        {
            startButton.gameObject.SetActive(false);
            buyButton.gameObject.SetActive(true);
            priceText.text = planeList[planeNumber].GetComponent<PlaneInfo>().price.ToString() + " $";
        }
        else
        {
            startButton.gameObject.SetActive(true);
            buyButton.gameObject.SetActive(false);
        }

        prevButton.onClick.AddListener(() => ChoosenPlane(false));
        nextButton.onClick.AddListener(() => ChoosenPlane(true));

        startButton.onClick.AddListener(StartGame);
        buyButton.onClick.AddListener(BuyPlane);
    }

    void ChoosenPlane(bool direction)
    {
        planeList[planeNumber].SetActive(false);

        if (direction)
        {
            planeNumber++;
        }
        else
        {
            planeNumber--;
        }

        if (planeNumber >= planeList.Count)
        {
            planeNumber = 0;
        }
        else if (planeNumber < 0)
        {
            planeNumber = planeList.Count - 1;
        }

        planeList[planeNumber].SetActive(true);

        SetChoosenPlaneColor();

        PlayerPrefs.SetInt("ChoosenPlane", planeNumber);

        if (PlayerPrefs.GetInt(planeList[planeNumber].name, 0) == 0)
        {
            startButton.gameObject.SetActive(false);
            buyButton.gameObject.SetActive(true);
            priceText.text = planeList[planeNumber].GetComponent<PlaneInfo>().price.ToString() + " $";
        }
        else
        {
            startButton.gameObject.SetActive(true);
            buyButton.gameObject.SetActive(false);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Plane");
    }

    public void BuyPlane()
    {
        if (score >= planeList[planeNumber].GetComponent<PlaneInfo>().price)
        {
            score -= planeList[planeNumber].GetComponent<PlaneInfo>().price;

            PlayerPrefs.SetInt(planeList[planeNumber].name, 1);

            PlayerPrefs.SetInt("Coins", score);
            scoreText.text = score.ToString() + " $";

            startButton.gameObject.SetActive(true);
            buyButton.gameObject.SetActive(false);
        }
    }

    public void ChangeColorToRed()
    {
        planeList[planeNumber].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);

        PlayerPrefs.SetString(planeList[planeNumber].name + "Color", "red");
    }

    public void ChangeColorToBlue()
    {
        planeList[planeNumber].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);

        PlayerPrefs.SetString(planeList[planeNumber].name + "Color", "blue");
    }

    public void ChangeColorToDefault()
    {
        planeList[planeNumber].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);

        PlayerPrefs.SetString(planeList[planeNumber].name + "Color", "white");
    }

    void SetChoosenPlaneColor()
    {
        switch (PlayerPrefs.GetString(planeList[planeNumber].name + "Color"))
        {
            case "red":
                planeList[planeNumber].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
                break;
            case "blue":
                planeList[planeNumber].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);
                break;
            default:
                planeList[planeNumber].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
                break;
        }
    }
}
