using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinMove : MonoBehaviour
{
    public Vector3 Direction = Vector3.up;
    public float Speed=1f;
    public float Range=1f;

    private Vector3 oP;

    // Start is called before the first frame update
    void Start()
    {
        oP = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = oP + (Direction * Mathf.Sin(Time.timeSinceLevelLoad * Speed) * Range);
    }
}
