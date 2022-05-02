using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimatePanelPosition : MonoBehaviour
{
    public Vector3 currentVector;
    public Vector3 goalVector;
    public float time;
    public float speed;
    public bool animate;


    void Start()
    {
        currentVector = transform.localPosition;
    }

    void Update()
    {
        if (animate)
        {
            time += Time.deltaTime * speed;
            transform.localPosition = Vector3.Lerp(currentVector, goalVector, time);
        }
    }

    public void SetAnimate()
    {
        animate = true;
    }
}
