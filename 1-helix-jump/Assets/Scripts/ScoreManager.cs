using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    public static int passedRings = 0;
    public static int ringsCount = 0;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Material rampageMaterial;
    [SerializeField]
    private GameObject particles;

    void Start()
    {
        score = 0;
        passedRings = 0;
        ringsCount = 0;
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Score"))
        {
            score++;
            passedRings++;
            ringsCount++;
            Destroy(collision);

            scoreText.text = score.ToString();

            if (ringsCount > 2)
            {
                GetComponent<MeshRenderer>().material = rampageMaterial;
                particles.gameObject.SetActive(true);
                GetComponent<Rigidbody>().drag = 1;
            }
        }
    }
}
