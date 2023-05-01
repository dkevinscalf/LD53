using System;
using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;

public class SafePosition : MonoBehaviour
{
    public float resetY = -100;
    public float FallDamage = 1f;
    public Vector3 offset = Vector3.zero;
    public Transform DebugItem;
    public Vector3 GetSafePosition
    {
        get
        {
            return _safePosition;
        }
    }
    private PlayerController _player;
    private Vector3 _safePosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<PlayerController>();
        _safePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.Grounded)
            SetSafePosition();
        if (transform.position.y < _safePosition.y + resetY)
        {
            ResetPosition();
            GetComponent<IDamageable>().Damage(FallDamage);
        }
    }

    public void ResetPosition()
    {
        transform.position = _safePosition;
    }

    private void SetSafePosition()
    {
        var p = transform.position;
        var v = _player.Velocity;
        var d = v.x / Mathf.Abs(v.x);
        var s = new Vector3(Mathf.Round(p.x), Mathf.Round(p.y), Mathf.Round(p.z)) + (offset * d);
        if(!float.IsNaN(s.y))
            _safePosition = s;
        if(DebugItem!=null)
            DebugItem.position = _safePosition;
    }
}
