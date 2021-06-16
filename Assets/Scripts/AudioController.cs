using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{

    public AudioSource audio;
    void Start()
    {
        if (!PlayerPrefs.HasKey("volume")) audio.volume = 1;
    }

    void Update()
    {
        audio.volume = PlayerPrefs.GetFloat("volume");
    }
}
