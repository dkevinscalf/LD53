using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonCountUpgrade : MonoBehaviour, IUpgrade
{
    public int IncreaseAmount = 1;
    public int MaxValue = 4;
    public string DisplayText()
    {
        var curr = PlayerStats.Instance.CannonCount;
        return $"({curr} -> {curr + IncreaseAmount})";
    }

    public void DoUpgrade()
    {
        PlayerStats.Instance.CannonCount += IncreaseAmount;
        if (PlayerStats.Instance.CannonCount >= MaxValue)
            Destroy(this);
    }
}
