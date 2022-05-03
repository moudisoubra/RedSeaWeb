using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CheckTextVisible))]
public class ScaleUI : MonoBehaviour
{

    public Vector3 newScale;
    public float speed = 2;
    public bool scale;
    public CheckTextVisible ctvScript;
    void Start()
    {
        ctvScript = GetComponent<CheckTextVisible>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ctvScript.visible || scale)
        transform.localScale = Vector3.Lerp(transform.localScale, newScale, speed * Time.deltaTime);
    }
}
