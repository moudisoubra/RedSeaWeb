using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTabButtonColors : MonoBehaviour
{
    //public List<RawImage> buttonImages;
    public List<Image> images;
    public List<GameObject> panels;
    public List<TextMeshProUGUI> titles;
    public Color titleOG;
    public Color titleAlt;
    public Color originalColor;
    public Color selectedColor;
    public int selectedButton;
    public float speed;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void CycleButtonColors(int x)
    {
        selectedButton = x;

        for (int i = 0; i < images.Count; i++)
        {
            if (i == selectedButton)
            {
                images[i].GetComponent<LerpFillBar>().speed = speed;
                panels[i].GetComponent<ChangeGroupAlpha>().SetGroupAlpha1();
                panels[i].GetComponent<ChangeGroupAlpha>().time = 1;
                panels[i].SetActive(true);
            }
            else
            {
                images[i].GetComponent<LerpFillBar>().speed = -speed;
                panels[i].transform.SetSiblingIndex(2);
                panels[i].GetComponent<ChangeGroupAlpha>().SetFade();
            }

            if (selectedButton == 0)
            {
                titles[i].color = titleOG;
            }
            else
            {
                titles[i].color = titleAlt;
            }
        }

        for (int z = 0; z < images.Count; z++)
        {

        }
    }

}
