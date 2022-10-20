using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private bool _isHittable;
    private float _currentSpeed;
    private bool _canRun;
    private Vector3 _posTarget;
    private Vector3 _startPos;

    public void StartGame()
    {
        _canRun = true;
        _currentSpeed = speed;
        _isHittable = true;
        _startPos = transform.position;
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
            EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(tagToCompareFinish))
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        _canRun = false;
        endScreen.SetActive(true);
    }

    #region PowerUps

    public void SpeedUp(float f)
    {
        _currentSpeed = speed * f;
    }

    public void ResetSpeed()
    {
        _currentSpeed = speed;
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
