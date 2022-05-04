using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuraLineManager : MonoBehaviour
{
    public List<AnimateLineRenderer> lineRenderers = new List<AnimateLineRenderer>();
    public float time;
    public float timeDuration;
    public float speed;
    public int index;
    public bool stop = false;
    public CheckTextVisible ctv;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * speed;
        if (time > timeDuration && !stop && (ctv != null && ctv.visible))
        {
            lineRenderers[index].enabled = true;
            if (lineRenderers[index].GetComponent<LoadImages>())
            {
                lineRenderers[index].GetComponent<LoadImages>().enabled = true;
            }
            index++;
            time = 0;
        }

        if (lineRenderers[lineRenderers.Count - 1].isActiveAndEnabled)
        {
            stop = true;
        }
    }

    public void TurnLinesOff()
    {
        for (int i = 0; i < lineRenderers.Count; i++)
        {
            lineRenderers[i].GetComponent<LineRenderer>().enabled = false;
        }
    }

    public void TurnLinesOn()
    {
        for (int i = 0; i < lineRenderers.Count; i++)
        {
            lineRenderers[i].GetComponent<LineRenderer>().enabled = true;
        }
    }
}
