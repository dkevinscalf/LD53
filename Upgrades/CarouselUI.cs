using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarouselUI : MonoBehaviour
{
    public GameObject[] Screens;

    private int _screenIndex;
    // Start is called before the first frame update
    void Start()
    {
        SelectScreen(0);
    }

    private void SelectScreen(int v)
    {
        foreach(var screen in Screens)
        {
            screen.SetActive(false);
        }
        Screens[v].SetActive(true);
    }

    public void SelectionChange(int v)
    {
        _screenIndex += v;
        if (_screenIndex < 0)
            _screenIndex = Screens.Length - 1;
        if (_screenIndex >= Screens.Length)
            _screenIndex = 0;
        SelectScreen(_screenIndex);
    }
}
