using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScaleUITween : MonoBehaviour
{
    public float time, delay;
    GameObject goScale;
    public iTween.EaseType easeType;
    public float targetScale = 1;
    public UnityEvent OnScaleUIInFinished = new UnityEvent();
    public UnityEvent OnScaleUIOUTFinished = new UnityEvent();
    public bool animateOnStart = false;

    private void OnEnable()
    {
        if (animateOnStart)
            AnimteScaleIN();
    }

    // Start is called before the first frame update
    void Start()
    {
        goScale = this.gameObject;

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AnimteScaleIN()
    {

        iTween.ValueTo(this.gameObject, iTween.Hash(
        "from", 0,
        "to", targetScale,
        "delay", delay,
        "easetype", easeType,
        "time", time,
        "looptype", iTween.LoopType.none,
        "onupdatetarget", this.gameObject,
        "onupdate", "UpdateScaleValue",
         "oncomplete", "OnCompleteScaleIN",
         "oncompletetarget", this.gameObject));
        
    }

    public void OnCompleteScaleIN()
    {
        OnScaleUIInFinished.Invoke();
    }

    public void AnimteScaleOUT()
    {

        iTween.ValueTo(this.gameObject, iTween.Hash(
        "from", targetScale,
        "to", 0,
        "delay", delay,
        "easetype", easeType,
        "time", time,
        "looptype", iTween.LoopType.none,
        "onupdatetarget", this.gameObject,
        "onupdate", "UpdateScaleValue",
         "oncomplete", "OnCompleteScaleOUT",
         "oncompletetarget", this.gameObject));

    }


    public void OnCompleteScaleOUT()
    {
        OnScaleUIOUTFinished.Invoke();
    }

    public void UpdateScaleValue(float val)
    {
        goScale.transform.localScale = new Vector3(val, val, val);
    }
}
