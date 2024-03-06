using UnityEngine;
using UnityEngine.UI;

public class FinalStation : MonoBehaviour
{
    [SerializeField]
    public GlowEffectScriptableObject glowValues;

    [SerializeField]
    private Text scoreText;

    private int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MovementController>().item && other.GetComponent<MovementController>().item.GetComponent<ContainerController>().containerDescription.container == ContainerType.Plate)
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
                if (itemOnHand.GetComponent<ContainerController>().recipeInPlate != null && itemOnHand.GetComponent<ContainerController>().containerDescription.container == ContainerType.Plate)
                {
                    score += itemOnHand.GetComponent<ContainerController>().foodPrice;
                    Destroy(other.GetComponent<MovementController>().item);
                    other.GetComponent<MovementController>().item = null;
                    scoreText.text = score.ToString();
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
