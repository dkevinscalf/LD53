using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgrade : MonoBehaviour, IUpgrade
{
    public float IncreaseAmount = 1;
    public float MaxValue = 10;
    public string DisplayText()
    {
        var currSpeed = PlayerStats.Instance.Speed;
        return $"({currSpeed} -> {currSpeed + IncreaseAmount})";
    }

    public void DoUpgrade()
    {
        PlayerStats.Instance.Speed += IncreaseAmount;
        if (PlayerStats.Instance.Speed >= MaxValue)
            Destroy(this);
    }
}
