using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class AssignRenderTexture : MonoBehaviour
{
    private RawImage rawImage;
    private VideoPlayer player;
    public string videoURL;

    void Start()
    {
        rawImage = GetComponentInChildren<RawImage>();
        player = GetComponent<VideoPlayer>();
        AssignToChild();
    }

    void Update()
    {
        //if (videoURL != "" && !player.isPlaying)
        //{
        //    player.Play();
        //}
    }

    public void AssignToChild()
    {
        RenderTexture rt = new RenderTexture(720, 960, 16, RenderTextureFormat.ARGB32);
        rawImage.texture = rt;
        player.targetTexture = rt;
        player.url = videoURL;
    }
}
