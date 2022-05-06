using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AnimatePanelPosition : MonoBehaviour
{
    public Vector3 currentVector;
    public Vector3 goalVector;
    public float time;
    public float speed;
    public bool animate;
    public bool fade;
    public bool returnObject;
    public bool turnOff;
    public RawImage imageToFade;
    public GameObject childToSet;
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

            if (fade)
            {
                Color c = imageToFade.color;
                c.a = Mathf.Lerp(1, 0, time);
                imageToFade.color = c;
            }

            if (transform.localPosition == goalVector && returnObject)
            {
                animate = false;
                time = 0;
                transform.gameObject.SetActive(false);
                transform.localPosition = currentVector;
                returnObject = false;
            }

            if (transform.localPosition == goalVector && turnOff)
            {
                transform.gameObject.SetActive(false);
            }
        }
    }

    public void SetChild()
    {
        transform.SetSiblingIndex(0);
    }

    public void SetAnimate()
    {
        animate = true;
    }

    public void SetReturn()
    {
        returnObject = true;
    }
}
