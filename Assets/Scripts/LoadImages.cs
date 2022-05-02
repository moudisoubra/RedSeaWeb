using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Video;

public class LoadImages : MonoBehaviour
{

    public string filesLocation = @"C:/images";
    public string videofilesLocation = @"C:/images";
    public List<Texture2D> images = new List<Texture2D>();
    public List<string> videos = new List<string>();
    public bool gotAllVideos;
    public VideoPlayer player;
    public List<VideoPlayer> videoPlayers = new List<VideoPlayer>();
    public OrbitObject ooScript;

    public SO.Events.EventSO videosLoaded;
    public SO.Events.EventSO imagesLoaded;

    public IEnumerator Start()
    {
        if (filesLocation != "")
        {
            yield return StartCoroutine(
                "LoadAll",
                Directory.GetFiles(filesLocation, "*.png", SearchOption.AllDirectories)
            );

            imagesLoaded.Raise();
        }
        if (videofilesLocation != "")
        {

            yield return StartCoroutine(
                "LoadAllMP4",
                Directory.GetFiles(videofilesLocation, "*.mp4", SearchOption.AllDirectories)
            );
            
            videosLoaded.Raise();
        }

    }

    public void Update()
    {
        if (gotAllVideos)
        {
            //player.url = videos[0];
            //player.Play();
            ooScript.videos = videos;
            ooScript.enabled = true;
            gotAllVideos = false;
        }
    }

    public IEnumerator LoadAll(string[] filePaths)
    {
        foreach (string filePath in filePaths)
        {
            WWW load = new WWW("file:///" + filePath);
            yield return load;
            if (!string.IsNullOrEmpty(load.error))
            {
                Debug.LogWarning(filePath + " error");
            }
            else
            {
                images.Add(load.texture);
            }
        }
    }

    public IEnumerator LoadAllMP4(string[] filePaths)
    {
        foreach (string filePath in filePaths)
        {
            WWW load = new WWW("file:///" + filePath);
            yield return load;
            if (!string.IsNullOrEmpty(load.error))
            {
                Debug.LogWarning(filePath + " error");
            }
            else
            {
                videos.Add(filePath);
            }
        }
    }
}