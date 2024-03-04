using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRandomizer : MonoBehaviour
{
    [SerializeField]
    private Material deathMaterial;

    [SerializeField]
    private int maxToDeath = 2;
    [SerializeField]
    private int maxToDelete = 2;

    private int count = 0;
    
    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.tag != "Finish")
            {
                count = 0;
                
                int rangeToDeath = Random.Range(0, maxToDeath);
                int rangeToDelete = Random.Range(1, maxToDelete);

                foreach (Transform grandchild in child.transform)
                {
                    if (grandchild.tag != "Score")
                    {
                        if (count > rangeToDeath)
                            break;

                        bool toDeath = (Random.value > 0.5f);
                        if (toDeath)
                        {
                            grandchild.gameObject.tag = "Death";
                            grandchild.gameObject.GetComponent<Renderer>().material = deathMaterial;
                            count++;
                        }
                    }
                }

                count = 0;

                foreach (Transform grandchild in child.transform)
                {
                    if (grandchild.tag != "Score")
                    {
                        if (count > rangeToDelete)
                            break;

                        bool toDelete = (Random.value > 0.5f);
                        if (toDelete)
                        {
                            grandchild.gameObject.SetActive(false);
                            count++;
                        }
                    }
                }

                if (count == 0)
                {
                    child.GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
                }
            }
        }
    }
}
