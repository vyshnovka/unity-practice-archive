using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakingStation : MonoBehaviour
{
    [SerializeField]
    public GlowEffectScriptableObject glowValues;

    [SerializeField]
    private GameObject productToTake;


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MovementController>().item == null)
        {
            Material[] materials = GetComponent<MeshRenderer>().materials;
            materials[1] = glowValues.glow;
            GetComponent<MeshRenderer>().materials = materials;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) )
            {
                if(other.GetComponent<MovementController>().item == null)
                {   
                    MovementController.instance.TakeProduct(Instantiate(productToTake));
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
