using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateChildren : MonoBehaviour
{
    public List<GameObject> children = new List<GameObject>();
    public float time = 0;
    public float duration;
    public int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > duration && index < children.Count - 1)
        {
            index++;
            time = 0;
        }
        else if(index >= children.Count - 1)
        {
            this.enabled = false;
        }

        if (!children[index].GetComponent<AnimatePanelPosition>().isActiveAndEnabled)
        {
            children[index].GetComponent<AnimatePanelPosition>().enabled = true;
        }
        if (!children[index].GetComponent<LerpColor>().isActiveAndEnabled)
        {
            children[index].GetComponent<LerpColor>().enabled = true;
        }
    }
}
