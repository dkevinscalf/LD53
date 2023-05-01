using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OtherUpgradesRequired : MonoBehaviour
{
    public UpgradeButton[] RequiredUpgrades;
    public void CheckOnUpgrades()
    {
        if (!RequiredUpgrades.Any(o => !o.UpgradeActive))
            GetComponent<UpgradeButton>().Activate();
    }
}
