using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEffect : MonoBehaviour
{

    public float amplitude; 
    public float speed;
    public float tempVal;
    public Vector3 tempPos;

    void Start()
    {
        tempVal = transform.localPosition.y;
    }

    void Update()
    {
        tempPos.y = tempVal + amplitude * Mathf.Sin(speed * Time.time);
        transform.localPosition = tempPos;
    }
}
