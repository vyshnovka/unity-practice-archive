using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "ScriptableObjects/Recipe")]
public class RecipeManagerScriptableObject : ScriptableObject
{
    public string recipeName;
    public GameObject beautifulFood;
    public List<Product> recipeContent;
    public int recipePrice;
}
