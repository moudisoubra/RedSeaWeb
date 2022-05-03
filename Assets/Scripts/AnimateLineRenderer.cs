using UnityEngine;
using System.Collections;

public class AnimateLineRenderer : MonoBehaviour
{
    public float animationDuration = 5f;

    private LineRenderer lineRenderer;
    private Vector3[] linePoints;
    private int pointsCount;

    public CanvasGroup cg;
    public bool activate;
    public bool needToWait;

    private void Start()
    {
        if (GetComponent<CanvasGroup>())
        {
            cg = GetComponent<CanvasGroup>();
        }

        lineRenderer = GetComponent<LineRenderer>();

        pointsCount = lineRenderer.positionCount;
        linePoints = new Vector3[pointsCount];
        for (int i = 0; i < pointsCount; i++)
        {
            linePoints[i] = lineRenderer.GetPosition(i);
        }
            if(!needToWait)
            StartCoroutine(AnimateLine());
        else
        {
            if(activate)
            StartCoroutine(AnimateLine());

        }


        if (cg != null)
            StartCoroutine(RunAlpha(cg));
    }

    private void Update()
    {

    }
    public IEnumerator RunAlpha(CanvasGroup gq)
    {
        float time = 0;

        while (time < animationDuration)
        {
            gq.alpha = Mathf.Lerp(0, 1, time / animationDuration);

            time += Time.deltaTime;
            yield return null;
        }
    }
    private IEnumerator AnimateLine()
    {
        lineRenderer.enabled = true;
        float segmentDuration = animationDuration / pointsCount;
        
        
        for (int i = 0; i < pointsCount - 1; i++)
        {
            float startTime = Time.time;

            Vector3 startPosition = linePoints[i];
            Vector3 endPosition = linePoints[i + 1];

            Vector3 pos = startPosition;
            while (pos != endPosition)
            {
                float t = (Time.time - startTime) / segmentDuration;
                pos = Vector3.Lerp(startPosition, endPosition, t);

                for (int j = i + 1; j < pointsCount; j++)
                    lineRenderer.SetPosition(j, pos);

                yield return null;
            }
        }
    }
}