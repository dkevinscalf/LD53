using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleHealthBar : MonoBehaviour, IHealthBar
{
    public Transform HealthBar;
    public GameObject Container;
    public bool AutoHide = true;
    public void Set(float health, float max, bool vertical)
    {
        if (AutoHide && Container != null)
            Container.SetActiveSafe(health != max);
        SetBarSize(HealthBar, health/max, vertical);
    }

    private void SetBarSize(Transform bar, float v, bool vertical)
    {
        var ls = bar.localScale;
        if (vertical)
            ls.y = v;
        else
            ls.x = v;
        bar.localScale = ls;
    }
}
