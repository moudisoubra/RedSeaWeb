using Coffee.UIEffects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelatedAnim : MonoBehaviour
{
    public bool animate;
    public float time;
    public float speed;
    public UIEffect uieffect;
    void Start()
    {

    }

    void Update()
    {
        if (animate)
        {
            time += Time.deltaTime * speed;
            
            time = Mathf.Clamp01(time);

            uieffect.effectFactor = time;

        }
    }
}
