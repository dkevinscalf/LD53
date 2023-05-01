using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipRope : MonoBehaviour
{
    
    public SpriteRenderer Rope;
    public Transform Collider;
    public float Speed = 10f;
    private Vector3 _target;

    public void Setup(float distance, Vector3 target)
    {
        _target = target;
        var sz = Rope.size;
        sz.x = distance;
        Rope.size = sz;
        var ls = Collider.localScale;
        ls.x = distance;
        Collider.localScale = ls;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var zoom = collision.GetComponent<ZoomPlayer>();
        if (zoom != null)
            zoom.Zoom(_target, Speed);
    }
}
