using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZiplineLengthUpgrade : MonoBehaviour, IUpgrade
{
    public float IncreaseAmount = 1;
    public float MaxValue = 10;
    public string DisplayText()
    {
        var curr = PlayerStats.Instance.ZipLineLength;
        return $"({curr} -> {curr + IncreaseAmount})";
    }

    public void DoUpgrade()
    {
        PlayerStats.Instance.ZipLineLength += IncreaseAmount;
        if (PlayerStats.Instance.ZipLineLength >= MaxValue)
            Destroy(this);
    }
}
