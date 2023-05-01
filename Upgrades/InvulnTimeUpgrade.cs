using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvulnTimeUpgrade : MonoBehaviour, IUpgrade
{
    public int IncreaseAmount = 1;
    public int MaxValue = 3;
    public string DisplayText()
    {
        var curr = PlayerStats.Instance.InvulnTime;
        return $"({curr} -> {curr + IncreaseAmount})";
    }

    public void DoUpgrade()
    {
        PlayerStats.Instance.InvulnTime += IncreaseAmount;
        if (PlayerStats.Instance.InvulnTime >= MaxValue)
            Destroy(this);
    }
}
