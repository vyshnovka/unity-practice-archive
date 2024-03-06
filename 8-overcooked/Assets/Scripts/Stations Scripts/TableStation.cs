using System.Collections.Generic;
using UnityEngine;

public class TableStation : MonoBehaviour
{
    [SerializeField]
    public GlowEffectScriptableObject glowValues;

    public GameObject itemOnTable = null;

    public List<RecipeManagerScriptableObject> recipeBook;
    //public string recipeInPlate = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MovementController>().item || itemOnTable)
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
            var itemOnHand = other.GetComponent<MovementController>().item;

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (itemOnTable == null && itemOnHand)
                {
                    itemOnTable = itemOnHand;
                    itemOnHand.transform.parent = transform;
                    itemOnHand.transform.position = transform.position + new Vector3(0f, 1f, 0f);
                    other.GetComponent<MovementController>().item = null;
                }
                else if (itemOnTable)
                {
                    if (itemOnHand == null)
                    {
                        MovementController.instance.TakeProduct(itemOnTable);
                        itemOnTable = null;
                    }
                    else if (itemOnHand)
                    {
                        if (itemOnTable.GetComponent<ProductController>())
                        {
                            MovementController.instance.TakeProduct(itemOnTable);
                        }
                        else //item on table pan pot plate
                        {
                            if (itemOnHand.GetComponent<ProductController>())
                            {
                                other.GetComponent<MovementController>().item = null;
                                var randomPosition = new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(0f, 0.3f), Random.Range(-0.2f, 0.2f));

                                itemOnTable.GetComponent<ContainerController>().productsInContainer.Add(itemOnHand);
                                itemOnHand.transform.parent = itemOnTable.transform;
                                itemOnTable.GetComponent<ContainerController>().containerDescription.products.Add(itemOnHand.GetComponent<ProductController>().productDescription);
                                itemOnHand.transform.position = itemOnTable.transform.position + randomPosition;

                                if (itemOnTable.GetComponent<ContainerController>().containerDescription.container == ContainerType.Plate)
                                {
                                    itemOnTable.GetComponent<ContainerController>().productsInPlate.Add(itemOnHand.GetComponent<ProductController>().productDescription);
                                    RecipeVerification(itemOnTable.GetComponent<ContainerController>().productsInPlate, itemOnTable);
                                }
                            }
                            else //item is container and on table is container pan pot plate
                            {
                                if (itemOnHand.GetComponent<ContainerController>().productsInContainer.Count == 0)
                                {
                                    MovementController.instance.TakeProduct(itemOnTable);
                                }
                                else
                                {
                                    foreach (var product in itemOnHand.GetComponent<ContainerController>().productsInContainer)
                                    {
                                        var randomPosition = new Vector3(Random.Range(-0.2f, 0.2f), transform.position.y + 0.2f, Random.Range(-0.2f, 0.2f));

                                        itemOnTable.GetComponent<ContainerController>().productsInContainer.Add(product);
                                        product.transform.parent = itemOnTable.transform;
                                        itemOnTable.GetComponent<ContainerController>().containerDescription.products.Add(product.GetComponent<ProductController>().productDescription);
                                        product.transform.position = itemOnTable.transform.position + randomPosition;
                                    }

                                    if (itemOnTable.GetComponent<ContainerController>().containerDescription.container == ContainerType.Plate)
                                    {
                                        foreach (var product in itemOnHand.GetComponent<ContainerController>().productsInContainer)
                                        {
                                            itemOnTable.GetComponent<ContainerController>().productsInPlate.Add(product.GetComponent<ProductController>().productDescription);
                                        }
                                        RecipeVerification(itemOnTable.GetComponent<ContainerController>().productsInPlate, itemOnTable);
                                    }

                                    itemOnHand.GetComponent<ContainerController>().productsInContainer.Clear();
                                    itemOnHand.GetComponent<ContainerController>().containerDescription.products.Clear();
                                }
                            }
                        }
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

    void RecipeVerification(List<Product> productsInPlate, GameObject plate)
    {
        for (int recipeIndex = 0; recipeIndex < recipeBook.Count; recipeIndex++)
        {
            if (productsInPlate.Count != recipeBook[recipeIndex].recipeContent.Count)
                continue;

            bool isMatch = true;

            for (int productInRecipeIndex = 0; productInRecipeIndex < productsInPlate.Count; productInRecipeIndex++)
            {
                for (int productInPlateIndex = 0; productInPlateIndex < recipeBook[recipeIndex].recipeContent.Count; productInPlateIndex++)
                {
                    if (recipeBook[recipeIndex].recipeContent[productInRecipeIndex].Equals(productsInPlate[productInPlateIndex]))
                    {
                        isMatch = true;
                        break;
                    }
                    else
                    {
                        isMatch = false;
                    }
                }

                if (!isMatch)
                {
                    break;
                }
            }

            if (isMatch)
            {
                plate.GetComponent<ContainerController>().recipeInPlate = recipeBook[recipeIndex].recipeName;
                plate.GetComponent<ContainerController>().foodPrice = recipeBook[recipeIndex].recipePrice;
                Instantiate(recipeBook[recipeIndex].beautifulFood, plate.transform);
                foreach(var product in plate.GetComponent<ContainerController>().productsInContainer)
                {
                    product.transform.localScale = new Vector3(0, 0, 0);
                }

                return;
            }
            plate.GetComponent<ContainerController>().recipeInPlate = null;
        }
    }
}

