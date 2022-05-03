using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public ChangeGroupAlpha cgaScript;
    public PlayTransition ptScript;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ptScript.timer > 1.9f)
        {
            cgaScript.fade = true;
        }
        if (ptScript.timer > 4.5f)
        {
            gameObject.SetActive(false);
        }
    }
}
