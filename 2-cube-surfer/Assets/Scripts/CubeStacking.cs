using System;
using System.Collections.Generic;
using UnityEngine;

public class CubeStacking : MonoBehaviour
{
    public Action<GameObject> cubeAttach;
    public Action<GameObject> cubeDetach;

    public GameObject humanModel;

    public void Start()
    {
        cubeAttach += Attachment;
        cubeDetach += Detachment;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            collision.gameObject.tag = "Untagged";
            cubeAttach(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            cubeDetach(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Finish")
        {
            StateManager.finish();
        }
    }

    public void Attachment(GameObject other)
    {
        transform.parent.GetChild(0).position = new Vector3(transform.position.x, GetComponent<Renderer>().bounds.size.y * (transform.parent.childCount - 1) + 0.1f, transform.position.z);

        other.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        other.transform.position = new Vector3(transform.position.x, GetComponent<Renderer>().bounds.size.y * (transform.parent.childCount - 2) + 0.1f, transform.position.z);
        other.AddComponent<CubeStacking>();
        other.transform.parent = transform.parent;
    }

    public void Detachment(GameObject other)
    {
        foreach (Transform child in other.transform.parent)
        {
            child.tag = "Untagged";
        }

        Destroy(GetComponent<CubeStacking>());
        transform.parent = null;

        StateManager.noCubesLeft();
    }

    public void OnDestroy()
    {
        cubeAttach -= Attachment;
        cubeDetach -= Detachment;
    }
}
