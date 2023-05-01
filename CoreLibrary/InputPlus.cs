using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlus : MonoBehaviour
{
    public string AxisName;
    public float DeadZone;
    public bool down;
    private bool inUse;
    public bool Held
    {
        get { return down; }
    }

    public bool Pressed
    {
        get { return down && !inUse; }
    }

    // Update is called once per frame
    void Update()
    {
        if (!inUse && down)
            inUse = true;
        down = Input.GetAxis(AxisName) > DeadZone;
        if (!down)
            inUse = false;
    }
}
