using Coffee.UIEffects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTransition : MonoBehaviour
{
    public float timer;
    public float time;
    public float time1;
    public float time2;
    public float speed;
    public float altSpeed;
    public bool animate;
    public bool altAnimate;
    public bool fade;
    public UITransitionEffect transitionScript;
    public bool timed;
    public float setTimer;

    void Start()
    {

    }

    void Update()
    {

        if (timed)
        {
            timer += Time.deltaTime;

            if (timer > setTimer)
            {
                animate = true;
            }
        }

        if (animate)
        {
            time += Time.deltaTime * speed;

            transitionScript.effectFactor = time;

            if(time < 0)
                transform.gameObject.SetActive(false);
        }

        if (altAnimate)
        {
            time += Time.deltaTime * altSpeed;

            transitionScript.effectFactor = time;

            if (time < 0)
                transform.gameObject.SetActive(false);
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
