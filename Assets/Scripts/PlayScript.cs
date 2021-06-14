using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayScript : MonoBehaviour
{
    private VideoPlayer MyVideoPlayer;

    private void Start()
    {
        MyVideoPlayer = GetComponent<VideoPlayer>();
        // play video player
        //MyVideoPlayer.Play();
        
    }

    public void Run()
	{
        Debug.Log("video started");
        MyVideoPlayer.Play();
    }

    public void Stop()
    {
        Debug.Log("video stopped");
   
        MyVideoPlayer.Stop();
    }


}
