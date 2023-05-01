using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float Cost = 1f;
    public float CostIncrease = 1f;
    public GameObject CantAffordPrefab;
    public GameObject MaxedPrefab;
    public GameObject ActivePanel;
    public TMPro.TextMeshProUGUI HoverText;
    public string Name;
    public string DefaultText = "Gym";

    public void Start()
    {
        float c = PlayerStats.Instance.GetUpgradeCost(Name);
        if (c != 0)
            Cost = c;
    }

    public bool UpgradeActive { 
        get {
            return ActivePanel.activeSelf;
        } 
    }

    public void Purchase()
    {
        var Upgrades = GetComponents<IUpgrade>();
        if(!Upgrades.Any())
        {
            Instantiate(MaxedPrefab, transform);
            return;
        }
        if(Research.Instance.Debit(Cost))
        {
            foreach(var upgrade in Upgrades)
            {
                upgrade.DoUpgrade();
            }
            foreach(var req in FindObjectsOfType<OtherUpgradesRequired>())
            {
                req.CheckOnUpgrades();
            }
            Cost += CostIncrease;
            PlayerStats.Instance.SetUpgradeCost(Name, Cost);
            SetDisplayText();
        } else
        {
            Instantiate(CantAffordPrefab, transform);
        }
    }

    public void Activate()
    {
        ActivePanel.SetActiveSafe(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetDisplayText();
    }

    private void SetDisplayText()
    {
        HoverText.text = $"{Name} Cost: ${Cost} {GetUpgradeEffect()}";
    }

    private string GetUpgradeEffect()
    {
        var upgrade = GetComponent<IUpgrade>();
        if (upgrade == null)
            return "Maxed";
        return upgrade.DisplayText();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HoverText.text = DefaultText;
    }
}
