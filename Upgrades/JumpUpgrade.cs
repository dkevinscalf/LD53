using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpUpgrade : MonoBehaviour, IUpgrade
{
    public float IncreaseAmount = 1;
    public float MaxValue = 30;
    public string DisplayText()
    {
        var curr = PlayerStats.Instance.JumpHeight;
        return $"({curr} -> {curr + IncreaseAmount})";
    }

    public void DoUpgrade()
    {
        PlayerStats.Instance.JumpHeight += IncreaseAmount;
        if (PlayerStats.Instance.JumpHeight >= MaxValue)
            Destroy(this);
    }
}
