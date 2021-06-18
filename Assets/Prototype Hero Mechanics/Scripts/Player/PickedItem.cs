using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedItem : MonoBehaviour
{
    public DurationImage durationImage;

    private Item currentItem;
    private float maxDuration = 7;
    public float currentDuration;
    private bool picked = false;

    void Update()
    {
        if (picked)
        {
            currentDuration -= Time.deltaTime;

            if (currentDuration > 0)
            {
                durationImage.SetCurrentDuration(currentDuration / maxDuration);
            }
            else
            {
                picked = false;
                currentItem = null;
                durationImage.HideIcon();
            }
        }
    }

    public void TakeItem(Item item)
    {
        currentItem = item;
        maxDuration = item.duration;
        currentDuration = maxDuration;
        durationImage.ShowIcon();
        durationImage.SetCurrentDuration(1);
        picked = true;
    }

    public void UseItem()
    {
        if (picked && currentItem != null)
        {
            currentItem.Use();
            ThrowItem();
        }
    }

    public void ThrowItem()
    {
        picked = false;
        currentItem = null;
        durationImage.HideIcon();
    }

    public bool HasItem()
    {
        return picked;
    }
}
