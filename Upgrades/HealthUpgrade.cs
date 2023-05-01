using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpgrade : MonoBehaviour, IUpgrade
{
    public float IncreaseAmount = 1;
    public float MaxValue = 10;
    public string DisplayText()
    {
        var curr = PlayerStats.Instance.Health;
        return $"({curr} -> {curr + IncreaseAmount})";
    }

    public void DoUpgrade()
    {
        PlayerStats.Instance.Health += IncreaseAmount;
        if (PlayerStats.Instance.Health >= MaxValue)
            Destroy(this);
    }
}
