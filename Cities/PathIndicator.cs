using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathIndicator : MonoBehaviour
{
    public float ColorSpeed = 1f;
    public Transform[] Segments;
    private LineRenderer _line;

    // Start is called before the first frame update
    void Start()
    {
        _line = GetComponent<LineRenderer>();
        var positions = Segments.Select(o => o.position).ToArray();
        _line.positionCount = positions.Length;
        _line.SetPositions(positions);
    }

    // Update is called once per frame
    void Update()
    {
        var c = _line.startColor;
        Color.RGBToHSV(c, out var h, out var s, out var v);
        h += (ColorSpeed * Time.deltaTime) % 1f;
        c = Color.HSVToRGB(h, s, v);
        _line.startColor = c;
        _line.endColor = c;
    }
}
