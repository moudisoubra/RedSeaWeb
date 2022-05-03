using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class YearLerp : MonoBehaviour
{
    public List<float> twentyThree = new List<float>();
    public List<float> thirty = new List<float>();
    public float a;
    public float b;
    public float c;
    public float d;
    public float time;
    public float speed;
    public bool forward = false;
    public bool backward = true;
    public bool clicked = false;

    public TextMeshProUGUI islandText;
    public TextMeshProUGUI hotelText;
    public TextMeshProUGUI roomText;
    public TextMeshProUGUI inlandText;

    public Color golden;
    public TextMeshProUGUI year1;
    public Image year1Fill;
    public TextMeshProUGUI year2;
    public Image year2Fill;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Lerping();
        AssignText();
    }

    public void AssignText() {
        islandText.text = ((int)a).ToString();
        hotelText.text = ((int)b).ToString();
        roomText.text = ((int)c).ToString();
        inlandText.text = ((int)d).ToString();
    }

    public void Lerping()
    {
        if (forward && clicked)
        {

            time += Time.deltaTime * speed;
            time = Mathf.Clamp01(time);
            a = Mathf.Lerp(twentyThree[0], thirty[0], time);
            b = Mathf.Lerp(twentyThree[1], thirty[1], time);
            c = Mathf.Lerp(twentyThree[2], thirty[2], time);
            d = Mathf.Lerp(twentyThree[3], thirty[3], time);

        }

        if (backward && clicked)
        {

            time += Time.deltaTime * speed;
            time = Mathf.Clamp01(time);
            a = Mathf.Lerp(thirty[0], twentyThree[0], time);
            b = Mathf.Lerp(thirty[1], twentyThree[1], time);
            c = Mathf.Lerp(thirty[2], twentyThree[2], time);
            d = Mathf.Lerp(thirty[3], twentyThree[3], time);

        }
    }

    public void OnButtonClick()
    {
        time = 0;
        clicked = true;
        forward = !forward;
        backward = !backward;

        if (forward)
        {
            year1.color = Color.grey;
            year2.color = golden;
            year1Fill.GetComponent<LerpFillBar>().speed = -5;
            year2Fill.GetComponent<LerpFillBar>().speed = 5;
        }
        else
        {
            year1.color = golden;
            year2.color = Color.grey;
            year2Fill.GetComponent<LerpFillBar>().speed = -5;
            year1Fill.GetComponent<LerpFillBar>().speed = 5;
        }
    }
}
