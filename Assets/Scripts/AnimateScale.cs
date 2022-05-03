using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimateScale : MonoBehaviour
{
    public float targetScale;
    public float timeToLerp = 0.25f;
    float scaleModifier = 1;

    public bool animate;
    public GameObject text;
    void Start()
    {
        //targetScale = transform.localScale.x;
        //transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        StartCoroutine(LerpFunction(targetScale, timeToLerp));
    }
    private void Update()
    {

    }
    IEnumerator LerpFunction(float endValue, float duration)
    {
        float time = 0;
        float startValue = scaleModifier;
        Vector3 startScale = transform.localScale;
        while (time < duration)
        {
            scaleModifier = Mathf.Lerp(startValue, endValue, time / duration);
            transform.localScale = startScale * scaleModifier;
            time += Time.deltaTime;
            yield return null;
        }

        transform.localScale = startScale * endValue;
        scaleModifier = endValue;
        text.SetActive(true);
    }
}
