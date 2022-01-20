using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Resource : MonoBehaviour
{
    [field: SerializeField] public ResourceDataSO ResourceData { get; private set; }

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PickUp()
    {
        StartCoroutine(DestroyCoroutine());
    }

    private IEnumerator DestroyCoroutine()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);

        Destroy(gameObject);
    }
}