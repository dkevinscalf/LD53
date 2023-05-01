using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalTextureScroll : MonoBehaviour
{
    public float LocalSpeed = 1f;
    public Transform Player;
    private Renderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
            return;
        var x = Player.position.x;
        spriteRenderer.material.SetTextureOffset("_MainTex", new Vector2(x*LocalSpeed, 0));
    }
}
