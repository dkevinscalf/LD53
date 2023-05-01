using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoSecurityUpgrade : MonoBehaviour, IUpgrade
{
    public int IncreaseAmount = 10;
    public int MaxValue = 100;
    public string DisplayText()
    {
        var curr = PlayerStats.Instance.CargoSecurity;
        return $"({curr} -> {curr + IncreaseAmount})";
    }

    public void DoUpgrade()
    {
        PlayerStats.Instance.CargoSecurity += IncreaseAmount;
        if (PlayerStats.Instance.CargoSecurity >= MaxValue)
            Destroy(this);
    }
}
