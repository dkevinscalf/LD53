using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnUpgrade : MonoBehaviour, IUpgrade
{
    public float IncreaseAmount = -1;
    public float MinValue = 4;
    public string DisplayText()
    {
        var curr = PlayerStats.Instance.EnemySpawnRatio;
        return $"({curr}% per meter -> {curr + IncreaseAmount}% per meter)";
    }

    public void DoUpgrade()
    {
        PlayerStats.Instance.EnemySpawnRatio += IncreaseAmount;
        if (PlayerStats.Instance.EnemySpawnRatio <= MinValue)
            Destroy(this);
    }
}
