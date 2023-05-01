using System;
using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;

public class ZoomPlayer : MonoBehaviour
{
    public PlayerController controller;
    public PlayerHealth health;
    private float _speed;
    private Vector3 _target;
    private bool _zooming;

    public void Zoom(Vector3 target, float speed)
    {
        _speed = speed;
        _target = target;
        _zooming = true;
        controller.enabled = false;
        health.enabled = false;
    }

    public void Update()
    {
        if (!_zooming)
            return;
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        if (transform.position.Distance(_target) < 0.1f)
            Detach();
    }

    private void Detach()
    {
        _zooming = false;
        controller.enabled = true;
        health.enabled = true;
    }
}
