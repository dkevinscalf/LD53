using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiledSpriteBar : MonoBehaviour, IHealthBar
{
    public SpriteRenderer Health;
    public SpriteRenderer Max;
    public void Set(float health, float max, bool vertical)
    {
        SetHealth(Health, health, vertical);
        SetHealth(Max, max, vertical);
    }

    private void SetHealth(SpriteRenderer sprite, float value, bool vertical)
    {
        if (sprite == null)
            return;
        var sz = sprite.size;
        if (vertical)
            sz.y = value;
        else
            sz.x = value;
        sprite.size = sz;
    }
}

public interface IHealthBar
{
    void Set(float health, float max, bool vertical);
}