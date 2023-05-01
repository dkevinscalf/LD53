using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform FiringDirection;
    public float FiringSpeed = 20f;
    public float FiringDistance = 10f;
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var zoom = collision.GetComponent<ZoomPlayer>();
        if (zoom == null)
            return;
        anim.SetTrigger("Fire");
        zoom.Zoom(transform.position + (FiringDirection.forward * FiringDistance), FiringSpeed);
    }
}
