using Febucci.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckTextVisible : MonoBehaviour
{
    public RectTransform rt;
    public Camera cam;
    public bool visible;
    public TextReveal trScript;
    public PixelatedAnim anim;
    public TextAnimator taScript;
    public AnimateLineRenderer lrAnimator;
    public ShuraLineManager lineManager;
    public bool changeAlpha;
    public float time;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        if(GetComponent<TextReveal>())
            trScript = GetComponent<TextReveal>();

        if(GetComponent<PixelatedAnim>())
            anim = GetComponent<PixelatedAnim>();

        if(GetComponent <TextAnimator>())
            taScript = GetComponent<TextAnimator>();

        if(GetComponent<AnimateLineRenderer>())
            lrAnimator = GetComponent<AnimateLineRenderer>();

        if(GetComponent<ShuraLineManager>())
            lineManager = GetComponent<ShuraLineManager>();

        rt = GetComponent<RectTransform>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        visible = rt.IsFullyVisibleFrom(cam);

        if (visible && trScript)
        {
            trScript.reveal = true;
        }
        if (visible && anim)
        {
            anim.animate = true;
        }
        if (visible && taScript)
        {
            taScript.enabled = true;
        }
        if (changeAlpha && visible)
        {
            RawImage ri = GetComponent<RawImage>();
            StartCoroutine(FadeTo(ri, 1, speed));
        }
        if(lrAnimator && visible)
        {
            lrAnimator.gameObject.SetActive(true);
            lrAnimator.enabled = true;
            lrAnimator.activate = true;
        }
        if (lineManager && visible)
        {
            lineManager.enabled = true;
        }
    }

    IEnumerator FadeTo(RawImage ri, float aValue, float aTime)
    {
        float alpha = ri.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            ri.color = newColor;
            yield return null;
        }
    }
}
