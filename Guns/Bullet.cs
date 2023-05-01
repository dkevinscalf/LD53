using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage;
    public float Velocity;
    public GameObject HitEffect;
    public float ShotShake;
    public float Acceleration;
    public Rect KillBounds;
    private bool Dead;
    // Start is called before the first frame update
    void Start()
    {
        if (ShotShake > 0)
            CameraShake.QuickShake(ShotShake);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (Acceleration > 0)
            Velocity *= 1 + (Acceleration * Time.deltaTime);
        transform.position += transform.forward * Velocity * Time.deltaTime;
        if (OutOfBounds())
            Destroy(this.gameObject);
    }

    private bool OutOfBounds()
    {
        return !KillBounds.Contains(transform.position.ToVector2());
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        DoHit(other.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DoHit(collision.gameObject);
    }

    private void DoHit(GameObject other)
    {
        var damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
            damageable.Damage(Damage);
        if (Dead)
            return;
        Dead = true;
        if (HitEffect != null)
            Instantiate(HitEffect, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
