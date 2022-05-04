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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * speed;
        if (time > timeDuration)
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
            this.enabled = false;
        }
    }
}
