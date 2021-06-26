using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DurationImage : MonoBehaviour
{
    public Image durationImage;

    void Start()
    {
        durationImage.fillAmount = 0;
    }

    public void SetCurrentDuration(float duration)
    {
        if (duration < 0 || duration > 1)
            throw new InvalidOperationException();

        durationImage.fillAmount = duration;
    }

    public void HideIcon()
    {
        gameObject.SetActive(false);
    }

    public void ShowIcon()
    {
        gameObject.SetActive(true);
    }
}
