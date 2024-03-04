using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BallEvents : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip bounceSound;
    [SerializeField]
    private AudioClip deathSound;
    [SerializeField]
    private AudioClip winSound;

    private Queue<Sequence> animationQueue = new Queue<Sequence>();

    [SerializeField]
    private GameObject splashImage;
    [SerializeField]
    private Material calmMaterial;
    [SerializeField]
    private GameObject particles;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Death":
                if (ScoreManager.ringsCount > 2)
                {
                    goto default;
                }

                UIManager.state = UIManager.States.Loose;
                audioSource.PlayOneShot(deathSound, 1f);

                break;
            case "Finish":
                UIManager.state = UIManager.States.Win;
                audioSource.PlayOneShot(winSound, 1f);

                break;
            default:
                if (ScoreManager.ringsCount > 2)
                {
                    Destroy(other.transform.parent.gameObject);
                }
                else
                {
                    GameObject splash = Instantiate(splashImage, new Vector3(transform.position.x, transform.position.y - 0.12f, transform.position.z), Quaternion.Euler(new Vector3(90, 0, 0)), other.transform);
                    Destroy(splash, 1);
                }

                transform.DOMoveY(transform.position.y + 1, 0.5f);
                BounceEffect();
                audioSource.PlayOneShot(bounceSound, 1f);

                ScoreManager.ringsCount = 0;
                GetComponent<Rigidbody>().drag = 2;
                GetComponent<MeshRenderer>().material = calmMaterial;
                particles.gameObject.SetActive(false);

                break;
        }
    }

    public void BounceEffect()
    {
        var seq = DOTween.Sequence();
        seq.Pause();

        seq.Append(transform.DOScaleX(0.4f, 0.1f));
        seq.Append(transform.DOScaleX(0.3f, 0.1f));
        seq.Append(transform.DOScaleY(0.4f, 0.1f));
        seq.Append(transform.DOScaleY(0.3f, 0.1f));

        animationQueue.Enqueue(seq);

        animationQueue.Peek().Play();

        animationQueue.Dequeue();
    }
}