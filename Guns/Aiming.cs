using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public ControlState Controls;
    public Transform DebugSphere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        switch(Controls)
        { 
            case ControlState.GamePad:            
                GamePadUpdate();
                return;
            case ControlState.Mouse:
                MouseUpdate();
                return;
        }
    }

    private void MouseUpdate()
    {
        
        Vector3 myLocation = transform.position;
        Vector3 targetLocation = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        targetLocation.z = myLocation.z;

        if (DebugSphere != null)
            DebugSphere.transform.position = targetLocation;

        transform.LookAt(targetLocation);

        if (GetAimVector().magnitude > 0)
            Controls = ControlState.GamePad;
    }

    private void GamePadUpdate()
    {
        var D = GetAimVector();
        var targetLocation = transform.position + D;

        transform.LookAt(targetLocation);

        if (GetMouseVector().magnitude > 0)
            Controls = ControlState.Mouse;
    }

    private static Vector3 GetAimVector()
    {
        return (Input.GetAxis("Right Horizontal") * Vector3.right) + (Input.GetAxis("Right Vertical") * Vector3.down);
    }

    private static Vector3 GetMouseVector()
    {
        return (Input.GetAxis("Mouse X") * Vector3.right) + (Input.GetAxis("Mouse Y") * Vector3.up);
    }
}

public enum ControlState
{
    GamePad,
    Mouse
}
