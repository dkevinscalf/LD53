using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationFire : MonoBehaviour
{
    public Transform Muzzle;
    public GameObject Bullet;
    public void Fire()
    {
        Instantiate(Bullet, Muzzle.position, Muzzle.rotation);
    }
}
