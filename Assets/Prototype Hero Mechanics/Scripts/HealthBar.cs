using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    private float maxHealth = 1;

    public void SetMaxHealth(float health)
    {
        maxHealth = health;
        slider.maxValue = health;
        SetHealth(health);
    }

    public void SetHealth(float health)
    {
        fill.fillAmount = Mathf.Clamp01(health / maxHealth);
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
