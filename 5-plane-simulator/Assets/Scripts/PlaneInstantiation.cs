using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneInstantiation : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> planeList;

    void Start()
    {
        GameObject newPlane = Instantiate(planeList[PlayerPrefs.GetInt("ChoosenPlane", 0)], gameObject.transform);

        switch (PlayerPrefs.GetString(planeList[PlayerPrefs.GetInt("ChoosenPlane", 0)].name + "Color"))
        {
            case "red":
                newPlane.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
                break;
            case "blue":
                newPlane.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.blue);
                break;
            default:
                newPlane.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
                break;
        }
    }
}
