using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockToX : MonoBehaviour
{
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
            return;
        var p = transform.position;
        p.x = Player.position.x;
        transform.position = p;
    }
}
