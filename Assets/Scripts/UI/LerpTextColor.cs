using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LerpTextColor : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float fadeDuration;
    public Color colorA;
    public Color colorB;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator UpdateTextColor()
    {
        float t = 0;
        while (t < 1)
        {
            text.color = Color.Lerp(colorA, colorB, t);
            t += Time.deltaTime / fadeDuration;
            yield return new WaitForEndOfFrame(); 
        }
    }

    IEnumerator ReverTextColor()
    {
        float t = 0;
        while (t < 1)
        {
            text.color = Color.Lerp(colorB, colorA, t);
            t += Time.deltaTime / fadeDuration;
            yield return new WaitForEndOfFrame();
        }
    }
    
    public void DoUpdateTextColor()
    {
        StartCoroutine(UpdateTextColor());
    }
    public void DoReverTextColor()
    {
        StartCoroutine(ReverTextColor());
    }
}
