using System;
using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public float MaxHealth;
    public float Health;
    public float KnockBack = 1f;
    public GameObject DeathEffect;
    public IHealthBar HealthBar;
    public bool VerticalHealthBar;
    public float InvulnTime = 2f;
    
    private DamageFlash _flash;
    private CargoInventory _cargo;
    private bool dead;
    private bool invuln;

    public void Damage(float v, Vector3? p = null)
    {
        if (dead)
            return;
        if (invuln)
            return;
        Health -= v;
        if (Health <= 0)
            Die();
        if (_flash != null)
            _flash.Flash();
        if (_cargo != null)
            _cargo.CargoHit();
        DoKnockBack(p);
        StartCoroutine(InvulnCR());
        UpdateHealthBar();
    }

    private void DoKnockBack(Vector3? p)
    {
        if (p == null)
            return;
        var k = transform.position - p.Value;
        if (k.y < 0)
            k.y = 0;
        transform.position += k.normalized * KnockBack;
    }

    private IEnumerator InvulnCR()
    {
        invuln = true;
        yield return new WaitForSeconds(InvulnTime);
        invuln = false;
    }

    private void Die()
    {
        if (DeathEffect != null)
            Instantiate(DeathEffect, transform.position, transform.rotation);
        if (_cargo != null)
            _cargo.LoseAllCargo();
        Health = 0;
        Destroy(this.gameObject);
        dead = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = PlayerStats.Instance.Health;
        
        Health = MaxHealth;
        if (HealthBar == null)
            HealthBar = GetComponent<IHealthBar>();
        _flash = GetComponent<DamageFlash>();
        SetInvulnTime();
        _cargo = GetComponent<CargoInventory>();
        Health = MaxHealth;
        UpdateHealthBar();
    }

    private void SetInvulnTime()
    {
        InvulnTime = PlayerStats.Instance.InvulnTime;
        _flash.FlashIterations = Mathf.RoundToInt(InvulnTime / (_flash.OnTime + _flash.OffTime));
    }

    private void UpdateHealthBar()
    {
        if (HealthBar == null)
            return;
        HealthBar.Set(Health, MaxHealth, VerticalHealthBar);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
