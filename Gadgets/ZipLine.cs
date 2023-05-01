using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZipLine : MonoBehaviour
{
    public float ZipLineHeight = 2f;
    public GameObject ZipLinePrefab;
    public GameObject RopePrefab;

    public void Setup(Vector3 a, Vector3 b)
    {
        var postA = Instantiate(ZipLinePrefab, a, Quaternion.identity);
        var postB = Instantiate(ZipLinePrefab, b, Quaternion.identity);
        var rope = Instantiate(RopePrefab, Midpoint(a, b), Quaternion.identity);
        rope.transform.LookAt(b + Vector3.up * ZipLineHeight);
        rope.GetComponent<ZipRope>().Setup(a.Distance(b), b + Vector3.up * ZipLineHeight);
    }

    private Vector3 Midpoint(Vector3 a, Vector3 b)
    {
        a += Vector3.up * ZipLineHeight;
        b += Vector3.up * ZipLineHeight;
        return (a + b) / 2f;
    }
}
