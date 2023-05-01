using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZiplineCountUpgrade : MonoBehaviour, IUpgrade
{
    public int IncreaseAmount = 1;
    public int MaxValue = 4;
    public string DisplayText()
    {
        var curr = PlayerStats.Instance.ZipLineCount;
        return $"({curr} -> {curr + IncreaseAmount})";
    }

    public void DoUpgrade()
    {
        PlayerStats.Instance.ZipLineCount += IncreaseAmount;
        if (PlayerStats.Instance.ZipLineCount >= MaxValue)
            Destroy(this);
    }
}
