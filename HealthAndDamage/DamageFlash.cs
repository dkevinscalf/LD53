using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    public float OffTime = 1f;
    public float OnTime = 1f;
    public int FlashIterations = 3;
    public Material FlashMaterial;
    public Renderer SpriteRender;
    private Material _oMat;

    // Start is called before the first frame update
    void Start()
    {
        _oMat = SpriteRender.material;
    }

    public void Flash()
    {
        StopAllCoroutines();
        StartCoroutine(FlashCR());
    }

    private IEnumerator FlashCR()
    {
        for(var i = 0; i<FlashIterations; i++)
        {
            SpriteRender.material = FlashMaterial;
            yield return new WaitForSeconds(OnTime);
            SpriteRender.material = _oMat;
            yield return new WaitForSeconds(OffTime);
        }
        SpriteRender.material = _oMat;
    }
}
