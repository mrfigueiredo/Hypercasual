using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : CollectableBase
{
    private bool _collected = false;

    private void Awake()
    {
        
    }

    protected override void OnCollect()
    {
        if (!_collected)
        {
            _collected = true;
            base.OnCollect();
            //ItemManager.Instance.AddCoins();
            StartCoroutine(CollectAnimation());
        }
    }

    IEnumerator CollectAnimation()
    {
        DOTween.Kill(transform);
        //transform.DOScale(0, collectAnimationDuration).SetEase(collectAnimationEase);
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }

 
}
