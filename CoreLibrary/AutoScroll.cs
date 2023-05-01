using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScroll : MonoBehaviour
{
    public Vector3 Direction;

    // Update is called once per frame
    void Update()
    {
        transform.position += Direction * Time.deltaTime;
    }
}
