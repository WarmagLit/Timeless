using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    public float oldVolume;
    bool isFullScreen = false;
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
        }
        if (dropdown.value == 1)
        {
            Screen.SetResolution(3840, 2160, isFullScreen);
        }
        if (dropdown.value == 2)
        {
            Screen.SetResolution(2560, 1440, isFullScreen);
        }
        if (dropdown.value == 3)
        {
            Screen.SetResolution(1366, 768, isFullScreen);
        }
    }
}
