using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureOffset : MonoBehaviour
{
    public Transform Player;
    public float OffsetSpeed = 0.1f;
    private Material _material;


    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        var x = new Vector2(-Player.position.x, -Player.position.y);
        _material.SetTextureOffset("_MainTex", x* OffsetSpeed);
    }
}
