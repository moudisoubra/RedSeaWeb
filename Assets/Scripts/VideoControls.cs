using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoControls : MonoBehaviour
{
    public VideoPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayVideo()
    {
        player.Play();
    }

    public void PauseVideo()
    {
        player.Pause();
    }    

    public void Seek(int seekTime)
    {
        player.time += seekTime;
    }
}
