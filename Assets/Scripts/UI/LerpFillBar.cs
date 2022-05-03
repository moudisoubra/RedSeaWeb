using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LerpFillBar : MonoBehaviour
{
    public Image img;
    public bool animate;
    public float time;
    public float speed;
    public CheckTextVisible checkTextVisible;

    // Start is called before the first frame update
    void Start()
    {
        checkTextVisible = GetComponent<CheckTextVisible>();
    }

    // Update is called once per frame
    void Update()
    {
        if(checkTextVisible)
        animate = checkTextVisible.visible;


        if (animate)
        {
            time += Time.deltaTime * speed;

            time = Mathf.Clamp01(time);

            img.fillAmount = time;
        }
    }
}
