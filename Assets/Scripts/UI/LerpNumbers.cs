using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LerpNumbers : MonoBehaviour
{
    public List<float> numbersToLerp = new List<float>();
    public List<float> numbersToLerpTo = new List<float>();
    public List<TextMeshProUGUI> numbersToLerpText = new List<TextMeshProUGUI> ();
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
        animate = checkTextVisible.visible;
        if (animate)
        {
            time += Time.deltaTime * speed;

            time = Mathf.Clamp01(time);

            for (int i = 0; i < numbersToLerp.Count; i++)
            {
                numbersToLerp[i] = Mathf.Lerp(numbersToLerp[i], numbersToLerpTo[i], time);
            }

            for (int i = 0; i < numbersToLerpText.Count; i++)
            {
                numbersToLerpText[i].text = ((int)numbersToLerp[i]).ToString();
            }

        }
    }
}
