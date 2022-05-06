using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffAllLines : MonoBehaviour
{
    public List<LineRenderer> lines;
    public Gradient normal;
    public Gradient noAlpha;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOff()
    {
        for (int i = 0; i < lines.Count; i++)
        {
            //lines[i].enabled = false;
            lines[i].colorGradient = noAlpha;
        }
    }

    public void TurnOn()
    {
        for (int i = 0; i < lines.Count; i++)
        {
            lines[i].colorGradient = normal;
            //lines[i].enabled = true;
        }
    }
}
