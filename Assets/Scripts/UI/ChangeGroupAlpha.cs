using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGroupAlpha : MonoBehaviour
{
    public float time;
    public float speed;
    public bool fade;
    public CanvasGroup group;
    void Start()
    {
        group = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if (fade)
        {
            time += Time.deltaTime * speed;

            group.alpha = time;
        }
    }

    public void SetFade()
    {
        fade = true;
    }

    public void SetGroupAlpha1()
    {
        fade = false;
        group.alpha = 1;
    }

}
