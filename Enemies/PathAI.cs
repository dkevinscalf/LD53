using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathAI : MonoBehaviour
{
    public Transform[] Path;
    public float Speed = 5f;
    private Transform _t;
    private int _i;
    // Start is called before the first frame update
    void Start()
    {
        SelectPath();
    }

    private void SelectPath()
    {
        _t = Path[_i];
        _i++;
        if (_i >= Path.Length)
            _i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _t.position, Speed * Time.deltaTime);
        if (transform.Distance(_t) < 0.1f)
            SelectPath();
    }
}
