using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactDamage : MonoBehaviour
{
    public float Damage = 1f;
    public bool DoReset;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var damageable = collision.collider.GetComponent<IDamageable>();
        if (damageable != null)
            damageable.Damage(Damage);
        if(DoReset)
        {
            var safeposition = collision.collider.GetComponent<SafePosition>();
            if (safeposition != null)
                safeposition.ResetPosition();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.Damage(Damage, transform.position);
        }
        if (DoReset)
        {
            var safeposition = collision.GetComponent<Collider>().GetComponent<SafePosition>();
            if (safeposition != null)
                safeposition.ResetPosition();
        }
    }
}
