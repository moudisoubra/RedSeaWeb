using DanielLochner.Assets.SimpleScrollSnap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPanel : MonoBehaviour
{
    public int childNumber;
    public SimpleScrollSnap ssScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        childNumber = this.transform.GetSiblingIndex();



    }

    public void Go()
    {
        ssScript.GoToPanel(childNumber);
    }
}
