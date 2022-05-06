using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoURL : MonoBehaviour
{
    public string url;
    public string nameOfVideo;
    public VideoPlayer player;
    public LoadImages liScript;
    public GameObject tabs;
    public GameObject playerParent;
    public GameObject lines;

    public SO.Events.EventSO playEvent;
    public bool animated;
    void Start()
    {
        SetVideo();
    }

    void Update()
    {
        if (url == "")
        {
            SetVideo();
        }
    }
    void CheckDimensions(string url)
    {
        //GameObject tempVideo = new GameObject("Temp video for " + url);
        //VideoPlayer videoPlayer = tempVideo.AddComponent<VideoPlayer>();
        //videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        player.source = VideoSource.Url;
        player.url = url;
        player.prepareCompleted += (VideoPlayer source) =>
        {
            Debug.Log("dimensions " + source.texture.width + " x " + source.texture.height); // do with these dimensions as you wish
            //Destroy(tempVideo);
            RenderTexture rt = new RenderTexture(source.texture.width, source.texture.height, 0);
            rt.name = transform.gameObject.name;
            player.targetTexture = rt;
            player.GetComponent<RawImage>().texture = rt;
        };
        player.gameObject.SetActive(true);
        player.Prepare();
    }
    public void SetVideo()
    {
        if (liScript != null)
        {
            for (int i = 0; i < liScript.videos.Count; i++)
            {
                if (liScript.videos[i].Contains(nameOfVideo))
                {
                    url = liScript.videos[i];
                    //CheckDimensions(url);
                }
            }
        }
        //player.url = url;
        //player.gameObject.SetActive(true);
        //player.Play();
    }

    public void PlayVideo()
    {
        if (url != "")
        {
            CheckDimensions(url);

            if(lines != null)
                lines.SetActive(false);

            if (tabs != null)
            {
                tabs.SetActive(false);
            }

            if(playerParent != null)
                playerParent.SetActive(true);

            player.url = url;
            player.Play();
            if (animated)
            {
                playEvent.Raise();
            }
            player.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Video Null");
        }
    }
}
