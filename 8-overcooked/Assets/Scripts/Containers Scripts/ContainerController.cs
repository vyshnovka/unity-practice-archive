using System;
using System.Collections.Generic;
using UnityEngine;

public class ContainerController : MonoBehaviour
{
    public Container containerDescription;
    public List<GameObject> productsInContainer = new List<GameObject>();

    [NonSerialized]
    public List<Product> productsInPlate = new List<Product>();
    public string recipeInPlate = null;
    public int foodPrice = 0;

}
