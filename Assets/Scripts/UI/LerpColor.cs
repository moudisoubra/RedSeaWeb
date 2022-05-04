using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LerpColor : MonoBehaviour
{
    public Color blue;
    public Color yellow;
    public float time1;
    public float time2;
    public float speed;
    public bool hovered;
    public RawImage rImage;

    // Start is called before the first frame update
    void Start()
    {
        rImage = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hovered)
        {
            time1 += Time.deltaTime * speed;
            rImage.color = Color.Lerp(blue, yellow, time1 * speed);
            time2 = 0;
        }
        else
        {
            time2 += Time.deltaTime * speed;
            rImage.color = Color.Lerp(yellow, blue, time2 * speed);
            time1 = 0;
        }
    }

    public void SetHovered()
    {
        hovered = true;
    }

    public void SetUnHovered()
    {
        hovered = false;
    }
}
