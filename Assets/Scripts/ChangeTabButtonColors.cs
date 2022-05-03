using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTabButtonColors : MonoBehaviour
{
    public List<RawImage> buttonImages;
    public List<GameObject> panels;
    public Color originalColor;
    public Color selectedColor;
    public int selectedButton;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void CycleButtonColors(int x)
    {
        selectedButton = x;

        for (int i = 0; i < buttonImages.Count; i++)
        {
            if (i == selectedButton)
            {
                buttonImages[i].color = selectedColor;
                panels[i].GetComponent<ChangeGroupAlpha>().SetGroupAlpha1();
                panels[i].GetComponent<ChangeGroupAlpha>().time = 1;
                panels[i].SetActive(true);
            }
            else
            {
                buttonImages[i].color = originalColor;
                panels[i].transform.SetSiblingIndex(2);
                panels[i].GetComponent<ChangeGroupAlpha>().SetFade();
            }
        }
    }

}
