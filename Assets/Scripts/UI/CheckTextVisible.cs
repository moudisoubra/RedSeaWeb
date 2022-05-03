using Febucci.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTextVisible : MonoBehaviour
{
    public RectTransform rt;
    public Camera cam;
    public bool visible;
    public TextReveal trScript;
    public PixelatedAnim anim;
    public TextAnimator taScript;
    // Start is called before the first frame update
    void Start()
    {
        if(GetComponent<TextReveal>())
            trScript = GetComponent<TextReveal>();

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
    }
}
