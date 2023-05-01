using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMessageWindow : MonoBehaviour
{
    public Image Character;
    public TMPro.TextMeshProUGUI Text;
    public float TextSpeed = 0.05f;
    public float ReadTime = 3f;

    private void Start()
    {
    }

    public void Setup(string text, Sprite characterArt = null, float textSpeed = 0)
    {
        if (characterArt != null)
            Character.sprite = characterArt;
        if (textSpeed > 0)
            TextSpeed = textSpeed;
        StartCoroutine(TextTyperCR(text));
    }

    private IEnumerator TextTyperCR(string text)
    {
        Text.text = text;
        for (var i = 0; i <= text.Length; i++)
        {
            Text.maxVisibleCharacters = i;
            yield return new WaitForSeconds(TextSpeed);
        }
        yield return new WaitForSeconds(ReadTime);
        Destroy(this.gameObject);
    }
}
