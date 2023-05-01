using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockOtherUpgrades : MonoBehaviour, IUpgrade
{
    public UpgradeButton[] ChildUpgrades;

    public string DisplayText()
    {
        throw new System.NotImplementedException();
    }

    public void DoUpgrade()
    {
        foreach (var child in ChildUpgrades)
        {
            child.Activate();
        }

        Destroy(this);
    }
}
