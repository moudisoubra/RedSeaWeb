using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRectTransform : MonoBehaviour
{
    public Vector2 rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (RectTransform t in transform)
        {
            if (t.sizeDelta != rectTransform)
            {
                t.sizeDelta = rectTransform;
            }
        }
    }
    public void DeletePics(Transform content)
    {
        foreach (Transform child in content)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
}
