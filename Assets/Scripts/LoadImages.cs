using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Video;
using UnityEngine.UI;
using DanielLochner.Assets.SimpleScrollSnap;

public class LoadImages : MonoBehaviour
{

    public string filesLocation = @"C:/images";
    public string videofilesLocation = @"C:/images";
    public List<Texture2D> images = new List<Texture2D>();
    public List<Texture2D> images2 = new List<Texture2D>();
    public List<string> videos = new List<string>();
    public bool gotAllVideos;
    public VideoPlayer player;
    public List<VideoPlayer> videoPlayers = new List<VideoPlayer>();

    public SO.Events.EventSO videosLoaded;
    public SO.Events.EventSO imagesLoaded;

    public SimpleScrollSnap snapScript;
    public GameObject contentParent;
    public GameObject content;
    public GameObject rawImage;
    public bool imgsLoaded;
    public bool imgsLoadedPreviously;
    public bool vidsLoaded;
    public bool vidsLoadedPreviously;
    private bool activated;

    public LoadImages externalLoad;
    public bool externallyLoaded = false;

    public IEnumerator Start()
    {
        if (!externallyLoaded)
        {

            if (filesLocation != "")
            {
                yield return StartCoroutine(
                    "LoadAll",
                    Directory.GetFiles(filesLocation, "*.png", SearchOption.AllDirectories)
                );
                yield return StartCoroutine(
                    "LoadAll",
                    Directory.GetFiles(filesLocation, "*.jpg", SearchOption.AllDirectories)
                );
                if (imagesLoaded)
                {
                    imagesLoaded.Raise();
                }
                imgsLoaded = true;
                imgsLoadedPreviously = true;
            }
            if (videofilesLocation != "")
            {

                yield return StartCoroutine(
                    "LoadAllMP4",
                    Directory.GetFiles(videofilesLocation, "*.mp4", SearchOption.AllDirectories)
                );
                if (videosLoaded)
                {
                    videosLoaded.Raise();
                }
                vidsLoaded = true;
                vidsLoadedPreviously = true;
            }
        }

    }

    public void Update()
    {
        if (imgsLoaded && content && activated)
        {
            for (int i = 0; i < images.Count; i++)
            {
                RawImage ri = Instantiate(rawImage).GetComponent<RawImage>();
                ri.texture = images[i];
                ri.transform.SetParent(content.transform);
                ri.transform.position = content.transform.position;
            }
            snapScript.Setup();
            snapScript.transform.parent.transform.parent.gameObject.SetActive(true);
            imgsLoaded = false;
            activated = false;
        }
    }

    public void SetContent()
    {
        DeletePics(content.transform);
        activated = true;
    }
    public void SetActivate()
    {
        if (imgsLoadedPreviously && images.Count > 0)
        {
            imgsLoaded = true;
        }
        activated = true;
    }

    public void DeletePics(Transform content)
    {
        foreach (Transform child in content)
        {
            GameObject.Destroy(child.gameObject);
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