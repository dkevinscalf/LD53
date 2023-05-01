using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public Vector3 Axis = Vector3.up;
    public float Speed = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Axis, Speed * Time.deltaTime);
    }
}
