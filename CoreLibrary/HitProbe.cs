using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HitProbe : MonoBehaviour
{
    public List<Collider> Colliders;

    private void Start()
    {
        Colliders = new List<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger)
            Colliders.Add(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.isTrigger)
            Colliders.Remove(other);
    }

    private void OnDisable()
    {
        Colliders = new List<Collider>();
    }

    private void Update()
    {
        Colliders = Colliders.Where(o => o != null).ToList();
    }

    public bool Hit
    {
        get
        {
            return Colliders.Any();
        }
    }

    internal Transform FirstTransform()
    {
        return Colliders.Select(o => o.transform).FirstOrDefault();
    }
}
