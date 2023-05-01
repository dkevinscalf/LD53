using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashAI : BasicAI
{
    public float OnTime = 1;
    public float OffTime = 0;
    public float Speed;

    private Transform _player;
    private bool _moving;
    private float _timer;

    protected override void ActiveUpdate() {
        if (_player == null)
            _player = GameObject.FindGameObjectWithTag("Player").transform;
        if (_moving)
            transform.position = Vector3.MoveTowards(transform.position, _player.position, Speed * Time.deltaTime);
        if (_timer <= 0)
        {
            _timer = _moving ? OffTime : OnTime;
            _moving = !_moving;
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }
}