using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureMovement : MonoBehaviour
{
    public bool SinX;
    public bool SinY;

    public float XSpeed;
    public float YSpeed;

    public float SinTiming = 1f;
    private Renderer rend;
    private Vector2 dV;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        dV = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        dV += new Vector2(SinMath(XSpeed, SinX), SinMath(YSpeed, SinY)) * Time.deltaTime;
        rend.material.SetTextureOffset("_MainTex", dV);
    }

    private float SinMath(float speed, bool sin)
    {
        if (!sin)
            return speed;
        return Mathf.Sin(Time.timeSinceLevelLoad * SinTiming) * speed;
    }
}
