using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CargoInventory : MonoBehaviour
{
    public GameObject CargoLoosePrefab;
    public GameObject CargoHeldPrefab;
    public Transform CargoContainer;
    [Range(0,100)]
    public float CargoSecurity;
    public List<CargoItem> Cargo;
    public Transform PlayerBody;
    private SafePosition _safePosition;


    public void Start()
    {
        CargoSecurity = PlayerStats.Instance.CargoSecurity;
        _safePosition = GetComponent<SafePosition>();
        Cargo = PlayerStats.Instance.Cargo.ToList();
        foreach(var cargo in Cargo)
        {
            cargo.HeldCargoItem = Instantiate(CargoHeldPrefab, CargoContainer);
            cargo.HeldCargoItem.GetComponent<HeldCargoItem>().Setup(cargo);
        }
    }

    public void CargoHit()
    {
        if (UnityEngine.Random.Range(0, 100) > CargoSecurity)
            LoseCargo(transform.position, Quaternion.identity);
    }

    public void LoseCargo(Vector3 p, Quaternion rotation)
    {
        var lostCargo = Cargo.FirstOrDefault();
        Destroy(lostCargo.HeldCargoItem);
        PlayerStats.Instance.Cargo.Remove(lostCargo);
        Cargo.Remove(lostCargo);
        Instantiate(CargoLoosePrefab, transform.position, rotation).GetComponentInChildren<LostCargo>().Setup(lostCargo);
    }

    internal void PickupCargo(CargoItem cargoItem)
    {
        PlayerStats.Instance.Cargo.Add(cargoItem);
        Cargo.Add(cargoItem);
        cargoItem.HeldCargoItem = Instantiate(CargoHeldPrefab, CargoContainer);
        cargoItem.HeldCargoItem.GetComponent<HeldCargoItem>().Setup(cargoItem);
    }

    internal void LoseAllCargo()
    {
        for(var i = 0; i < Cargo.Count; i++)
        {
            LoseCargo(transform.position, Quaternion.identity);
        }
    }
}

[Serializable]
public class CargoItem
{
    public string Name;
    public Sprite CargoSprite;
    public GameObject HeldCargoItem;
    public string Destination;
    public float Value;
}