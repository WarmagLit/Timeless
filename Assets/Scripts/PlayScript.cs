using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayScript : MonoBehaviour
{
    private VideoPlayer MyVideoPlayer;

    private SpriteRenderer sprite;

    private void Start()
    {
        MyVideoPlayer = GetComponent<VideoPlayer>();
        sprite = GetComponent<SpriteRenderer>();
        // play video player
        //MyVideoPlayer.Play();
        
    }

    public void Run()
	{
        Debug.Log("video started");
        sprite.color = Color.white;
        MyVideoPlayer.Play();
    }

    public void Stop()
    {
        Debug.Log("video stopped");
   
        MyVideoPlayer.Stop();
    }


}
