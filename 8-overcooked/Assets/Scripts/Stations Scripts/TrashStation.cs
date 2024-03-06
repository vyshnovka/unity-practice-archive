using UnityEngine;

public class TrashStation : MonoBehaviour
{
    [SerializeField]
    public GlowEffectScriptableObject glowValues;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MovementController>().item)
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
            if (Input.GetKeyDown(KeyCode.E))
            { 
                var item = other.GetComponent<MovementController>().item;
                if (item)
                {
                    if (item.GetComponent<ProductController>() || item.GetComponent<ContainerController>().containerDescription.container == ContainerType.Plate)
                    {
                        other.GetComponent<MovementController>().item = null;
                        Destroy(item.gameObject);
                    }
                    else
                    {
                        foreach (var product in item.GetComponent<ContainerController>().productsInContainer)
                        {
                            Destroy(product.gameObject);
                        }
                        item.GetComponent<ContainerController>().containerDescription.products.Clear();
                        item.GetComponent<ContainerController>().productsInContainer.Clear();
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
