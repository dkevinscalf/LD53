using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCountUpgrade : MonoBehaviour, IUpgrade
{
    public int IncreaseAmount = 1;
    public int MaxValue = 3;
    public string DisplayText()
    {
        var curr = PlayerStats.Instance.JumpCount;
        return $"({curr} -> {curr + IncreaseAmount})";
    }

    public void DoUpgrade()
    {
        PlayerStats.Instance.JumpCount += IncreaseAmount;
        if (PlayerStats.Instance.JumpCount >= MaxValue)
            Destroy(this);
    }
}
