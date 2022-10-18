using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBase : MonoBehaviour
{
    public ParticleSystem vfxPrefab;
    public string tagToCompare = "Player";
    public GameObject graphicItem;

    [Header("Hide On Collect")]
    public bool hideOnCollect = true;
    public float timeToHide = 1f;
    
    [Header("Destroy On Collect")]
    public bool destroyOnCollect = true;
    public float timeToDestroy = 1f;

    [Header("Audio")]
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(tagToCompare))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        OnCollect();
        if (hideOnCollect)
            Invoke("HideObject", timeToHide);

        if (destroyOnCollect)
            Invoke("DestroyOjbect", timeToDestroy);
    }

    protected virtual void HideObject()
    {
        graphicItem.SetActive(false);
    }
    
    protected virtual void DestroyObject()
    {
        Destroy(gameObject);
    }

    protected virtual void OnCollect()
    {
        if (vfxPrefab != null)
            vfxPrefab.Play();

        if (audioSource != null)
            audioSource.Play();
    }
}
