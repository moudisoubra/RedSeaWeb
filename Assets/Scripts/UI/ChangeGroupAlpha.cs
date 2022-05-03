using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGroupAlpha : MonoBehaviour
{
    public float time;
    public float speed;
    public bool fade;
    public CanvasGroup group;
    public List<GameObject> gameObjectsToTurnOff;
    
    void Start()
    {
        group = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if (fade)
        {
            for (int i = 0; i < gameObjectsToTurnOff.Count; i++)
            {
                gameObjectsToTurnOff[i].SetActive(false);
            }
            time += Time.deltaTime * speed;

            time = Mathf.Clamp01(time);

            group.alpha = time;

            if (group.alpha == 0)
            {
                transform.gameObject.SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < gameObjectsToTurnOff.Count; i++)
            {
                gameObjectsToTurnOff[i].SetActive(true);
            }
        }
    }

    public void SetFade()
    {
        fade = true;
    }

    public void SetGroupAlpha1()
    {
        fade = false;
        group.alpha = 1;
    }

}
