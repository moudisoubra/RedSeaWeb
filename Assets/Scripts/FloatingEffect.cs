using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEffect : MonoBehaviour
{

    public float amplitude; 
    public float speed;
    public float tempVal;
    public Vector3 tempPos;
    public bool active;

    void Start()
    {
    }

    void Update()
    {
        if (active)
            Float();
    }
    
    public void Float()
    {
        if (tempVal == 0)
        {
            tempVal = transform.localPosition.y;
        }
        if (tempPos == Vector3.zero)
        {
            tempPos = transform.localPosition;
        }
        else
        {
            tempPos.y = tempVal + amplitude * Mathf.Sin(speed * Time.time);
            transform.localPosition = tempPos;
        }
    }
}
