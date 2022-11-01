using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    public List<Transform> positions;

    public float movementDuration = 2f;

    private int _index;
    private float time;
    private Vector3 _currentPosition;

    private void Start()
    {
        _index = RandomIndex();

        StartCoroutine(StartMovement());

    }

    private int nextIndex()
    {
        _index++;
        if (_index >= positions.Count)
            _index = 0;
        return _index;
    }

    private int RandomIndex()
    {
        return Random.Range(0, positions.Count);
    }

    IEnumerator StartMovement()
    {
        time = 0;

        while(true)
        {
            _currentPosition = transform.position;

            while(time < movementDuration)
            {
                transform.position = Vector3.Lerp(_currentPosition, positions[_index].transform.position, (time/movementDuration));

                time += Time.deltaTime;

                yield return null;
            }

            _index = nextIndex();

            time = 0;

            yield return null;
        }
    }

}
