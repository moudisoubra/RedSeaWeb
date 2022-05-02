using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePointsOnMap : MonoBehaviour
{
    public List<AnimateScale> scale = new List<AnimateScale>();
    public List<AnimateLineRenderer> lines = new List<AnimateLineRenderer>();
    public List<GameObject> pings = new List<GameObject>();
    public List<Vector3> originalPositions = new List<Vector3>();
    public List<Vector3> newPositions = new List<Vector3>();
    public GameObject lastPoint;
    public int index = 0;
    public float duration;
    public float imageTime = 0;
    public float time = 0;
    public bool test;
    public bool next;
    public bool countDownForImages = false;
    void Start()
    {
        for (int i = 0; i < pings.Count; i++)
        {
            originalPositions.Add(pings[i].transform.position);
            newPositions.Add(pings[i].transform.position + new Vector3(0,1000,0));
            pings[i].transform.position = newPositions[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (test)
        {
            StartCoroutine(PlacePing(pings[0], originalPositions[0], newPositions[0]));
            test = false;
        }
        if (next && index < pings.Count - 1)
        {

            if (time / duration >= 0.5f)
            {
                index++;
                StartCoroutine(PlacePing(pings[index], originalPositions[index], newPositions[index]));
                time = 0;
            }
            else
            {
                time += Time.deltaTime;
            }
        }
        else if (index == pings.Count - 1 && Vector2.Distance(pings[pings.Count - 1].transform.position, lastPoint.transform.position) < 10)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                lines[i].enabled = true;
                countDownForImages = true;
            }
        }

        if (countDownForImages)
        {
            imageTime += Time.deltaTime;

            if (imageTime >= lines[0].animationDuration - 1)
            {
                for (int i = 0; i < scale.Count; i++)
                {
                    scale[i].enabled = true;
                }
                countDownForImages = false;
            }
        }
    }

    public void PlacePings()
    {
        
    }

    public IEnumerator PlacePing(GameObject p, Vector3 og, Vector3 ng)
    {
        next = true;
        float time = 0;

        while (time < duration)
        {
            p.transform.position = Vector3.Lerp(ng, og, time / duration);
            //Debug.Log(time/duration);

            time += Time.deltaTime;
            yield return null;
        }
    }
}
