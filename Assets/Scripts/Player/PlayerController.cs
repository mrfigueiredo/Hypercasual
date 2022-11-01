using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{
    [Header("Movement")]
    public float speed = 10f;

    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    public string tagToCompareEnemy = "Enemy";
    public string tagToCompareFinish= "FinishLine";

    public Collider CoinCollector;
    public GameObject endScreen;

    [Header("Animation")]
    public AnimatorManager animatorManager;
    public float growthDuration = .1f;
    public Ease ease = Ease.OutBack;
    [SerializeField] private BounceHelper bounceHelper;

    private bool _isHittable;
    private bool _canRun;
    private bool _isDead;
    private float _currentSpeed;
    private Vector3 _posTarget;
    private Vector3 _startPos;
    private Vector3 _rotateAngleDeath = new Vector3(0, 180, 0);
    private float _currentBaseAnimationSpeed = 7f;

    public void StartGame()
    {
        _currentSpeed = speed;
        _isHittable = true;
        _startPos = transform.position;
        _isDead = false;
        StartRun();
    }

    private void Start()
    {
        StartAnimation();
    }

    public void StartRun()
    {
        _canRun = true;
        PlayAnimationRun();
    }

    private void PlayAnimationRun()
    {
        animatorManager.PlayAnimationType(AnimatorManager.AnimationType.RUN, _currentSpeed / _currentBaseAnimationSpeed);
    }

    private void StartAnimation()
    {
        transform.DOScale(0, growthDuration).From().SetEase(ease);
    }

    private bool checkIsDead()
    {
        return _isDead;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_canRun)
            return;

        _posTarget.x = target.position.x;
        _posTarget.y = transform.position.y;
        _posTarget.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, _posTarget, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag(tagToCompareEnemy) && _isHittable)
        {
            var _bounceHelper = collision.gameObject.GetComponent<BounceHelper>();
            if (_bounceHelper != null)
                _bounceHelper.Bounce();
            OnDeath();
            EndGame(AnimatorManager.AnimationType.DEATH);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(tagToCompareFinish))
        {
            EndGame(AnimatorManager.AnimationType.IDLE);
        }
    }

    private void OnDeath()
    {
        transform.DOMoveZ(-1.5f, 0.5f).SetRelative();
    }

    private void EndGame(AnimatorManager.AnimationType animationType = AnimatorManager.AnimationType.IDLE)
    {
        _canRun = false;
        _isDead = true;
        endScreen.SetActive(true);
        animatorManager.PlayAnimationType(animationType);
    }

    public void Bounce()
    {
        if (bounceHelper != null)
            bounceHelper.Bounce();
    }

    #region PowerUps

    public void SpeedUp(float f)
    {
        _currentSpeed = speed * f;
        PlayAnimationRun();
    }

    public void ResetSpeed()
    {
        _currentSpeed = speed;
        if(!checkIsDead())
            PlayAnimationRun();
    }

    public void Hittable()
    {
        _isHittable = true;
    }

    public void UnHittable()
    {
        _isHittable = false;
    }

    public void Fly(float flyHeight, float duration)
    {
        var p = transform.position;
        p.y += flyHeight;
        transform.position = p;
    }

    public void Landing()
    {
        var p = transform.position;
        p.y = _startPos.y;
        transform.position = p;
    }

    public void ChangeCoinCollectorSize(float size)
    {
        CoinCollector.transform.localScale = Vector3.one * size;
    }

    #endregion
}
