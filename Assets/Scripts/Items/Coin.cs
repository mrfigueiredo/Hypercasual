using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : CollectableBase
{
    [Header("Collect Magnet")]
    public float lerpSpeed = 5f;
    public float distanceToDestroy = 1f;
    public float timeToDestroyOnCollect = 0.1f;

    private bool _collected = false;

    private void Awake()
    {
        
    }

    protected override void Collect()
    {
        OnCollect();
    }

    protected override void OnCollect()
    {
        if (!_collected)
        {
            _collected = true;
            base.OnCollect();
        }
    }

    private void Update()
    {
        if(_collected)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerController.Instance.transform.position, lerpSpeed * Time.deltaTime);
            if(Vector3.Distance(transform.position, PlayerController.Instance.transform.position) < distanceToDestroy)
            {
                DestroyObject(timeToDestroyOnCollect);
            }
        }
    }
}
