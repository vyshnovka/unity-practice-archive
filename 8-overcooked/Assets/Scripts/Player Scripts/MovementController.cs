using UnityEngine;

public class MovementController : MonoBehaviour
{
    public static MovementController instance;

    private CharacterController playerController;
    private float inputX, inputZ;

    [SerializeField]
    private float playerSpeed = 2f;

    [SerializeField]
    [Range(0f, 1f)]
    private float rotateSpeed;

    public bool canPick = true;
    public GameObject item = null;

    [SerializeField]
    private float offsetY = 2f;

    private void Awake()
    {
        if (instance)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(inputX, 0, inputZ);
        playerController.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(move), rotateSpeed);
        }
    }

    public void TakeProduct(GameObject itemToTake)
    {
        canPick = false;
        if (item)
        {
            item.transform.parent = null;
            item.transform.position = new Vector3(itemToTake.transform.position.x, (itemToTake.transform.position.y + offsetY), itemToTake.transform.position.z);
            //item.GetComponent<Collider>().enabled = true;
        }

        itemToTake.transform.parent = transform;
        itemToTake.transform.position = new Vector3(transform.position.x, (transform.position.y + 1f), transform.position.z);
        //itemToTake.GetComponent<Collider>().enabled = false;

        item = itemToTake;

        StartCoroutine(Utility.TimedEvent(ResetPick, 1f));
    }

    public void ResetPick()
    {
        canPick = true;
    }
}
