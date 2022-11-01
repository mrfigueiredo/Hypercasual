using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceHelper : MonoBehaviour
{
    [Header("Animation")]
    public float scaleDuration = .1f;
    public float scaleBounce = 1.2f;
    public Ease ease = Ease.OutBack;

    public void Bounce()
    {
        transform.DOScale(scaleBounce, scaleDuration).SetRelative().SetEase(ease).SetLoops(2, LoopType.Yoyo);
    }

}
