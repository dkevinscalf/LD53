using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float ShakeAmount;
    private float AdjustedShakeAmount;
    public float ShakeTime;
    private float ShakeTimer;
    private Vector3 oPos;

    internal static void QuickShake(float v)
    {
        Instance.Shake(v);
    }

    public static CameraShake Instance;

    // Start is called before the first frame update
    //no precise values here only big medium and little 1, 2, 3
    public void Shake(float v)
    {
        ShakeTimer = ShakeTime;
        AdjustedShakeAmount = ShakeAmount * v;
    }

    public void Start()
    {
        Instance = this;
        oPos = transform.position;
    }

    public void Update()
    {
        if(ShakeTimer>0)
        { 
            ShakeTimer -= Time.deltaTime;
            transform.position = oPos + (UnityEngine.Random.insideUnitSphere * AdjustedShakeAmount);
        }
        else
        {
            transform.position = oPos;
        }
    }
}
