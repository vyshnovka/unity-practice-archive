using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinAddToStack : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> coinList;

    [SerializeField]
    private GameObject targetCoin;

    [SerializeField]
    private GameObject coinPrefab;

    [SerializeField]
    private float distance = 1f;

    [SerializeField]
    private float dropSpeed = 1f;

    private Coroutine damageRoutine = null;

    [SerializeField]
    private GameObject meshToBlink;

    void Start()
    {
        coinList = new List<GameObject>();
        coinList.Add(targetCoin);
    }

    void FixedUpdate()
    {
        for (int i = 1; i < coinList.Count; i++)
        {
            coinList[i].transform.position = Vector3.Lerp(coinList[i].transform.position, coinList[i - 1].transform.position, distance);
            coinList[i].transform.rotation = Quaternion.Lerp(coinList[i].transform.rotation, coinList[i - 1].transform.rotation, distance);
        }
    }

    public void AddCoin()
    {
        GameObject newCoin = Instantiate(coinPrefab, coinList[coinList.Count - 1].transform.position, coinList[coinList.Count - 1].transform.rotation);
        coinList.Add(newCoin);
    }

    public void RemoveCoin()
    {
        if (coinList.Count > 1)
        {
            for (int i = coinList.Count - 1; i > 0; i--)
            {
                coinList[i].AddComponent<Rigidbody>();
                coinList[i].GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(0f, 0.2f), 1f, Random.Range(-0.2f, 0.2f)) * dropSpeed, ForceMode.Impulse);

                var temp = coinList[i];
                coinList.Remove(coinList[i]);

                Destroy(temp, 1f);
            }

            damageRoutine = StartCoroutine(DamageAnimation());
        }
        else
        {
            CharacterMovement.instance.enabled = false;
            LevelCanvasManager.instance.SetActiveDeadUI();
        }
    }

    IEnumerator DamageAnimation()
    {
        ObstacleTrigger.takeDamage = false;

        for (int i = 0; i < 8; i++)
        {
            meshToBlink.GetComponent<MeshRenderer>().enabled = !meshToBlink.GetComponent<MeshRenderer>().enabled;
            i++;

            yield return new WaitForSeconds(0.2f);
        }

        ObstacleTrigger.takeDamage = true;
        StopCoroutine(damageRoutine);
    }
}
