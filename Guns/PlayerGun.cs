using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public float FireCD;
    private float FireTime;
    public GameObject Bullet;
    public Transform Muzzle;
    public Animator GunAnimator;
    public float DamageMultiplier = 1;
    public bool AutoFire;

    public bool CanFire
    {
        get
        {
            return FireTime <= 0;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (AutoFire || Input.GetAxis("Fire1") > 0)
        {
            if (CanFire)
                Fire();
        }
        if (FireTime > 0)
            FireTime -= Time.deltaTime;
    }

    private void Fire()
    {
        if (GunAnimator != null)
            GunAnimator.SetTrigger("Fire");
        var bullets = Instantiate(Bullet, Muzzle.position, Muzzle.rotation);
        foreach(var bullet in bullets.GetComponentsInChildren<Bullet>())
        {
            bullet.Damage *= DamageMultiplier;
        }
        FireTime = FireCD;
    }
}

