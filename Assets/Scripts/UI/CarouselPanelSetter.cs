using DanielLochner.Assets.SimpleScrollSnap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarouselPanelSetter : MonoBehaviour
{
    public SimpleScrollSnap snapScript;
    public RawImage img;
    public GameObject content;
    public int current;



    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        img.texture = content.transform.GetChild(snapScript.SelectedPanel).gameObject.GetComponent<RawImage>().texture;

    }

    public void NextPanel()
    {
        if (content.transform.childCount < 6)
        {
            current++;
            if (current > content.transform.childCount - 1)
            {
                current = 0;
            }
            img.texture = content.transform.GetChild(current).gameObject.GetComponent<RawImage>().texture;
        }
        else
        {
            snapScript.GoToNextPanel();

            Texture currentImage = content.transform.GetChild(snapScript.CenteredPanel).gameObject.GetComponent<RawImage>().texture;

            if (img.texture != currentImage)
                img.texture = currentImage;
        }
    }

    public void PreviousPanel()
    {
        if (content.transform.childCount < 6)
        {
            current--;
            if (current < 0)
            {
                current = content.transform.childCount - 1;
            }
            img.texture = content.transform.GetChild(current).gameObject.GetComponent<RawImage>().texture;
        }
        {
            snapScript.GoToPreviousPanel();
            Texture currentImage = content.transform.GetChild(snapScript.CenteredPanel).gameObject.GetComponent<RawImage>().texture;

            if (img.texture != currentImage)
                img.texture = currentImage;
        }

    }
}
