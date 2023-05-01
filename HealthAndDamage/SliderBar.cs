using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour, IHealthBar
{
    public Slider HealthBar;
    public void Set(float health, float max, bool vertical)
    {
        HealthBar.value = health;
        HealthBar.maxValue = max;
    }
}