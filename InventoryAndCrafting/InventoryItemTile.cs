using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemTile : MonoBehaviour
{
    public TMPro.TextMeshProUGUI Count;
    public TMPro.TextMeshProUGUI Name;
    public Image Icon;

    public void Setup(InventoryItem item) {
        Name.text = item.Name;
        Count.text = item.Amount.ToString();
        if (item.Icon != null)
            Icon.sprite = item.Icon;
    }
}
