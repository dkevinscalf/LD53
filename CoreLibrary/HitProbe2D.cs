using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HitProbe2D : MonoBehaviour
{
    public List<Collider2D> Colliders;

    private void Start()
    {
        Colliders = new List<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger)
            Colliders.Add(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.isTrigger)
            Colliders.Remove(collision);
    }

    private void OnDisable()
    {
        Colliders = new List<Collider2D>();
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
