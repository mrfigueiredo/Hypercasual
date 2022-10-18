using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 10f;

    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    public string tagToCompareEnemy = "Enemy";
    public string tagToCompareFinish= "FinishLine";

    public GameObject endScreen;

    private bool _canRun;
    private Vector3 _posTarget;

    public void StartGame()
    {
        _canRun = true;
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
        transform.Translate(transform.forward * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag(tagToCompareEnemy))
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
}
