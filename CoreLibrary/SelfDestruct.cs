using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float TimeToLive = 1f;
    public GameObject DeathEffect;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestructCR());
    }

    private IEnumerator SelfDestructCR()
    {
        yield return new WaitForSeconds(TimeToLive);
        if (DeathEffect != null)
            Instantiate(DeathEffect, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
