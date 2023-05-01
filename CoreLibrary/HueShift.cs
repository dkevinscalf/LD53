using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HueShift : MonoBehaviour
{
    public float ShiftSpeed;
    private float H;
    public SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Color.RGBToHSV(rend.color, out var h, out var s, out var v);
        H = (H + (ShiftSpeed * Time.deltaTime))%1f;
        rend.color = Color.HSVToRGB(H, s, v);
    }
}
