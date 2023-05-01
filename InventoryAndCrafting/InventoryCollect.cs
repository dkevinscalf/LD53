using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCollect : MonoBehaviour, ICollectible
{
    public InventoryItem CollectedItem;
    public GameObject CollectEffect;
    public void Collect()
    {
        InventorySystem.Instance.Add(CollectedItem);
        if (CollectEffect != null)
            Instantiate(CollectEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            Collect();
    }
}

public interface ICollectible
{
    void Collect();
}