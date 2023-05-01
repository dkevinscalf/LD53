using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CargoMenuItem : MonoBehaviour
{
    public TMPro.TextMeshProUGUI NameText;
    public TMPro.TextMeshProUGUI DestinationText;
    public Image Icon;
    public GameObject DeliverButton;
    private CargoItem _cargo;
    private CityMapNode _city;

    internal void Setup(CargoItem cargo, CityMapNode city)
    {
        _city = city;
        if (DeliverButton != null)
        {
            if (city.Name == cargo.Destination)
                DeliverButton.SetActiveSafe(true);
        }
        _cargo = cargo;
        if (cargo.CargoSprite != null)
            Icon.sprite = cargo.CargoSprite;
        NameText.text = cargo.Name;
        DestinationText.text = cargo.Destination;
    }

    public void Accept()
    {
        PlayerStats.Instance.Cargo.Add(_cargo);
        _city.AcceptCargo(_cargo);
        Destroy(this.gameObject);
    }

    public void Deliver()
    {
        PlayerStats.Instance.Cargo.Remove(_cargo);
        Research.Instance.Credit(_cargo.Value);
        Destroy(this.gameObject);
    }
}
