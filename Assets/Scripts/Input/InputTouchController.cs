using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTouchController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 1f;

    private Vector2 _touchPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Move(Input.mousePosition.x - _touchPosition.x);
            
        }
        _touchPosition = Input.mousePosition;
    }

    private void Move(float distance)
    {
        transform.position += Vector3.right * Time.deltaTime * distance * speed;
    }
}
