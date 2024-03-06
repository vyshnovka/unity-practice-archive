using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingStation : MonoBehaviour
{
    [SerializeField]
    public GlowEffectScriptableObject glowValues;

    private GameObject containerOnStation = null;

    [SerializeField]
    private List<GameObject> alreadyBoiled;

    [SerializeField]
    private List<Product> boillable = new List<Product>();

    [SerializeField]
    private List<GameObject> alreadyFried;

    [SerializeField]
    private List<Product> friable = new List<Product>();

    [SerializeField]
    private float offsetY;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MovementController>().item && other.GetComponent<MovementController>().item.GetComponent<ContainerController>())
        {
            Material[] materials = GetComponent<MeshRenderer>().materials;
            materials[1] = glowValues.glow;
            GetComponent<MeshRenderer>().materials = materials;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (other.GetComponent<MovementController>().item == null && containerOnStation)
                {
                    other.GetComponent<MovementController>().TakeProduct(containerOnStation);
                }
                else if (other.GetComponent<MovementController>().item && other.GetComponent<MovementController>().item.GetComponent<ContainerController>())
                {
                    var container = other.GetComponent<MovementController>().item.GetComponent<ContainerController>();
                    container.transform.parent = transform;
                    container.transform.position = new Vector3(transform.position.x, (transform.position.y + offsetY), transform.position.z);
                    containerOnStation = other.GetComponent<MovementController>().item;
                    other.GetComponent<MovementController>().item = null;

                    StartCoroutine(Utility.TimedEvent(() =>
                    {
                        for (int i = 0; i < container.productsInContainer.Count; i++)
                        {
                            var item = container.productsInContainer[i];
                            if (container.containerDescription.container == ContainerType.Pot)
                            {
                                int index = boillable.FindIndex(p => p.Equals(container.productsInContainer[i].GetComponent<ProductController>().productDescription));

                                if (index == -1)
                                {
                                    index = alreadyBoiled.Count - 1;
                                }

                                var newItem = Instantiate(alreadyBoiled[index], item.gameObject.transform.position, item.gameObject.transform.rotation, container.transform);
                                container.productsInContainer[i] = newItem;
                                container.containerDescription.products[i] = newItem.GetComponent<ProductController>().productDescription;
                                Destroy(item.gameObject);
                            }
                            else if (container.containerDescription.container == ContainerType.Pan)
                            {
                                int index = friable.FindIndex(p => p.Equals(container.productsInContainer[i].GetComponent<ProductController>().productDescription));

                                if (index == -1)
                                {
                                    index = alreadyFried.Count - 1;
                                }

                                var newItem = Instantiate(alreadyFried[index], item.gameObject.transform.position, item.gameObject.transform.rotation, container.transform);
                                container.productsInContainer[i] = newItem;
                                container.containerDescription.products[i] = newItem.GetComponent<ProductController>().productDescription;
                                Destroy(item.gameObject);
                            }
                        }
                    }, 5f));
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
