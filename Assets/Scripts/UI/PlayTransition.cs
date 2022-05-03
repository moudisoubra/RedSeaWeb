using Coffee.UIEffects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTransition : MonoBehaviour
{
    public float time;
    public float time1;
    public float time2;
    public float speed;
    public float altSpeed;
    public bool animate;
    public bool altAnimate;
    public bool fade;
    public UITransitionEffect transitionScript;

    void Start()
    {

    }

    void Update()
    {
        if (animate)
        {
            time += Time.deltaTime * speed;

            transitionScript.effectFactor = time;
        }

        if (altAnimate)
        {
            time += Time.deltaTime * altSpeed;

            transitionScript.effectFactor = time;
        }
    }

    public void SetAnimate()
    {
        animate = true;
        altAnimate = false;
        time = time1;
    }

    public void SetAltAnimate()
    {
        animate = false;
        altAnimate = true;
        time = time2;
    }
}
