using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTabButtonColors : MonoBehaviour
{
    public List<RawImage> buttonImages;
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
            }
            else
            {
                buttonImages[i].color = originalColor;
            }
        }
    }

}
