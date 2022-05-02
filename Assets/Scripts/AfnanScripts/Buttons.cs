using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public List<GameObject> fadedButtons;
    public List<GameObject> goldenButtons;
    public List<GameObject> mapIcons;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOffOtherButtons(int index)
    {
        for (int i = 0; i < goldenButtons.Count; i++)
        {
            if (i == index)
            {
                goldenButtons[i].SetActive(true);
                fadedButtons[i].SetActive(false);
                mapIcons[i].SetActive(true);
            }
            else
            {
                goldenButtons[i].SetActive(false);
                fadedButtons[i].SetActive(true);
                mapIcons[i].SetActive(false);

            }
        }
    }
}
