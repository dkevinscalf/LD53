using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFireDistanceUpgrade : MonoBehaviour, IUpgrade
{
    public float IncreaseAmount = 5;
    public float MaxValue = 50;
    public string DisplayText()
    {
        var curr = PlayerStats.Instance.CannonFiringDistance;
        return $"({curr} -> {curr + IncreaseAmount})";
    }

    public void DoUpgrade()
    {
        PlayerStats.Instance.CannonFiringDistance += IncreaseAmount;
        if (PlayerStats.Instance.CannonFiringDistance >= MaxValue)
            Destroy(this);
    }
}
