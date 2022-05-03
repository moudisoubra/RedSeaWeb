using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScaleUIHeigh : MonoBehaviour
{

    public float time, delay;
    private float targetHeight = 0;

    public bool animateOnStart;


    public UnityEvent OnHeightINFinished = new UnityEvent();
    public UnityEvent OnHeightOUTFinished = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        if(targetHeight == 0)
             targetHeight = this.gameObject.GetComponent<RectTransform>().sizeDelta.y;


     //   Debug.Log(this.gameObject.name + "  " +  targetHeight);
        this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(this.gameObject.GetComponent<RectTransform>().sizeDelta.x , 0);
        if(animateOnStart)
          ScaleIN();

    }

    
    public void ScaleIN()
    {
        iTween.ValueTo(this.gameObject, iTween.Hash(
              "time", time,
              "delay" , delay,
              "from", 0,
              "to", targetHeight,
              "onupdate", "OnUpdateHeight",
              "oncomplete", "OnCompleteHeightIn",
              "oncompletetarget", this.gameObject,
              "easetype", iTween.EaseType.easeInOutQuart
          ));
    }
    void OnUpdateHeight(float val)
    {
        RectTransform rt = gameObject.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, val);
    }

    void OnCompleteHeightIn()
    {
        OnHeightINFinished.Invoke();
    }

    public void ResetAnimation()
    {
        if(targetHeight == 0)
            targetHeight = this.gameObject.GetComponent<RectTransform>().sizeDelta.y;

        this.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(this.gameObject.GetComponent<RectTransform>().sizeDelta.x, 0);
    }

    public void ScaleOUT()
    {
        iTween.ValueTo(this.gameObject, iTween.Hash(
            "time", time,
            "delay", delay,
            "from", targetHeight,
            "to", 0,
            "onupdate", "OnUpdateHeight",
            "oncomplete", "OnCompleteHeightOUT",
            "oncompletetarget", this.gameObject,
            "easetype", iTween.EaseType.easeInOutQuart


        ));
    }

    void OnCompleteHeightOUT()
    {
        OnHeightOUTFinished.Invoke();
    }
}
