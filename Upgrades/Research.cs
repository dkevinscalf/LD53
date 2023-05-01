using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Research : MonoBehaviour
{
    public float Units;
    public TMPro.TextMeshProUGUI UnitText;
    public static Research Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        UpdateUI();
    }

    public bool Debit(float cost)
    {
        if (Units < cost)
            return false;
        Units -= cost;
        UpdateUI();
        return true;
    }

    private void UpdateUI()
    {
        UnitText.text = $"${Units.RoundToDigits(2)}";
    }

    public void Credit(float v)
    {
        Units += v;
        UpdateUI();
    }
}
