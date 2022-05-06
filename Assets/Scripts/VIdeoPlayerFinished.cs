using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VIdeoPlayerFinished : MonoBehaviour
{
    public VideoPlayer player;
    public double length;
    public double time;
    public GameObject tabs;
    public SO.Events.EventSO removeVideo;

    void Start()
    {
        player = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        length = player.length;
        time = player.time;
        if (player.isPlaying && (int)time >= (int)length)
        {
            Debug.Log("Video Player Finished");
            tabs.SetActive(true);
            removeVideo.Raise();
            //transform.gameObject.SetActive(false);
        }
    }
}
