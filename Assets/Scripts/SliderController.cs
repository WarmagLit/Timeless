using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    public float oldVolume;
    bool isFullScreen = true;
    public Dropdown dropdown;

    void Start()
    {
        oldVolume = slider.value;
        if (!PlayerPrefs.HasKey("volume")) slider.value = 1;
        else slider.value = PlayerPrefs.GetFloat("volume");
    }

    void Update()
    {
        if (oldVolume != slider.value)
        {
            PlayerPrefs.SetFloat("volume", slider.value);
            PlayerPrefs.Save();
            oldVolume = slider.value;
        }
    }

    public void FullScreenToggle()
    {
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }

    public void Resolution(int r)
    {
        if (dropdown.value == 0)
        {
            Screen.SetResolution(1920, 1080, isFullScreen);
            Debug.Log(0);
        }
        if (dropdown.value == 1)
        {
            Screen.SetResolution(3840, 2160, isFullScreen);
            Debug.Log(1);
        }
        if (dropdown.value == 2)
        {
            Screen.SetResolution(2560, 1440, isFullScreen);
        }
        if (dropdown.value == 3)
        {
            Screen.SetResolution(1366, 768, isFullScreen);
        }
        if (dropdown.value == 4)
        {
            Screen.SetResolution(1024, 768, isFullScreen);
        }
        if (dropdown.value == 5)
        {
            Screen.SetResolution(640, 480, isFullScreen);
        }
        if (dropdown.value == 6)
        {
            Screen.SetResolution(800, 600, isFullScreen);
        }
        if (dropdown.value == 7)
        {
            Screen.SetResolution(1080, 720, isFullScreen);
        }
    }
}
