using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public List<InventoryItem> Items;
    public static InventorySystem Instance;
    public Sprite UnknownIcon;
    public GameObject InventoryWindow;
    public Transform InventorySpace;
    public GameObject ItemTilePrefab;
    public InputPlus MenuButton;

    private void Awake()
    {
        if (Instance == null)
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
        if (Items == null)
            Items = new List<InventoryItem>();
    }

    private void Update()
    {
        if (MenuButton.Pressed)
            ToggleInventory();
    }

    public void Add(InventoryItem item)
    {
        var existingItem = FindItem(item.Name);
        if (existingItem != null)
            existingItem.Amount += item.Amount;
        else
            Items.Add(item);
    }

    public void Add(string name, float amount)
    {
        InventoryItem existingItem = FindItem(name);
        if (existingItem != null)
            existingItem.Amount += amount;
        else
            Items.Add(new InventoryItem { Name = name, Amount = amount, Icon = UnknownIcon });
    }

    private InventoryItem FindItem(string name)
    {
        return Items.FirstOrDefault(o => o.Name == name);
    }

    public bool Consume(string name, float amount)
    {        
        if (!HasEnough(name, amount))
            return false;
        var item = FindItem(name);
        item.Amount -= amount;
        return true;
    }

    public void OpenInventory()
    {
        InventoryWindow.SetActive(true);
        foreach (Transform child in InventorySpace)
            Destroy(child.gameObject);
        foreach(var item in Items)
        {
            Instantiate(ItemTilePrefab, InventorySpace).GetComponent<InventoryItemTile>().Setup(item);
        }
    }

    public void CloseInventory()
    {
        InventoryWindow.SetActive(false);
    }

    public void ToggleInventory()
    {
        if (InventoryWindow.activeSelf)
            CloseInventory();
        else
            OpenInventory();
    }

    private bool HasEnough(string name, float amount)
    {
        var item = FindItem(name);
        if (item == null)
            return false;
        if (item.Amount < amount)
            return false;
        return true;
    }
}

[Serializable]
public class InventoryItem
{
    public string Name;
    public float Amount;
    public Sprite Icon;
}