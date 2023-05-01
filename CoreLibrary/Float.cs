using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float FloatSpeed = 1f;
    public float FloatAmount = 1f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * Mathf.Sin(Time.timeSinceLevelLoad * FloatSpeed) * FloatAmount * Time.deltaTime;
    }
}
