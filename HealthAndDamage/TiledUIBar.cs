using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiledUIBar : MonoBehaviour, IHealthBar
{
    public RectTransform HealthBar;
    public RectTransform MaxHealthBar;
    public float UnitWidth = 100f;
    public void Set(float health, float max, bool vertical)
    {
        SetHealth(HealthBar, health, vertical);
        SetHealth(MaxHealthBar, max, vertical);
    }

    private void SetHealth(RectTransform sprite, float value, bool vertical)
    {
        if (sprite == null)
            return;
        var sz = sprite.sizeDelta;
        if (vertical)
            sz.y = value * UnitWidth;
        else
            sz.x = value * UnitWidth;
        sprite.sizeDelta = sz;
    }
}