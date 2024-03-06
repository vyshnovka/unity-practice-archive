using System.Collections.Generic;
using UnityEngine;

public class CuttingStation : MonoBehaviour
{
    [SerializeField] 
    public GlowEffectScriptableObject glowValues;

    [SerializeField]
    private List<GameObject> alreadyCut;

    [SerializeField]
    private List<Product> cuttable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MovementController>().item && other.GetComponent<MovementController>().item.GetComponent<ProductController>())
        {
            var item = other.GetComponent<MovementController>().item.GetComponent<ProductController>();
            int index = cuttable.FindIndex(p => p.Equals(item.productDescription));

            if (index != -1)
            {
                Material[] materials = GetComponent<MeshRenderer>().materials;
                materials[1] = glowValues.glow;
                GetComponent<MeshRenderer>().materials = materials;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (other.GetComponent<MovementController>().item && other.GetComponent<MovementController>().item.GetComponent<ProductController>())
                {
                    var item = other.GetComponent<MovementController>().item.GetComponent<ProductController>();
                    int index = cuttable.FindIndex(p => p.Equals(item.productDescription));

                    if (index != -1)
                    {
                        Destroy(item.gameObject);
                        MovementController.instance.TakeProduct(Instantiate(alreadyCut[index]));
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Material[] materials = GetComponent<MeshRenderer>().materials;
        materials[1] = null;
        GetComponent<MeshRenderer>().materials = materials;
    }
}

