using UnityEngine;

public class ProductController : MonoBehaviour
{
    public Product productDescription;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && MovementController.instance.canPick)
            {
                MovementController.instance.TakeProduct(gameObject);
            }
        }
    }
}
