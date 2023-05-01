using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUI : MonoBehaviour
{
    public GameObject Window;

    public void Toggle()
    {
        Window.SetActive(!Window.activeSelf);
    }
}
