using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScalphaHelpers
{
    public static void SetActiveSafe(this GameObject obj, bool v)
    {
        if (obj.activeSelf != v)
            obj.SetActive(v);
    }
    public static float Distance(this Vector3 a, Vector3 b)
    {
        return (a - b).magnitude;
    }

    public static float Distance(this Transform a, Transform b)
    {
        return a.position.Distance(b.position);
    }
    public static Color Add(Color a, Color b)
    {
        var c = a + b;
        return new Color(NormalizeValue(c.r), NormalizeValue(c.g), NormalizeValue(c.b), 1f);
    }

    public static float NormalizeValue(float v)
    {
        return v > 0 ? 1f : 0;
    }

    public static Color FullAlpha(this Color c)
    {
        c.a = 1f;
        return c;
    }

    public static void LookAtOnlyY(this Transform a, Vector3 target)
    {
        Vector3 relativePos = target - a.position;
        Quaternion LookAtRotation = Quaternion.LookRotation(relativePos);

        Quaternion LookAtRotationOnly_Y = Quaternion.Euler(a.rotation.eulerAngles.x, LookAtRotation.eulerAngles.y, a.rotation.eulerAngles.z);

        a.rotation = LookAtRotationOnly_Y;
    }

    public static T Random<T>(this T[] arr)
    {
        return arr[UnityEngine.Random.Range(0, arr.Length)];
    }

    public static Vector2 ToVector2(this Vector3 a)
    {
        return new Vector2(a.x, a.y);
    }

    public static float RoundToDigits(this float v, int d)
    {
        var m = Mathf.Pow(10, d);
        v *= m;
        v = Mathf.Round(v);
        return v / 100f;
    }

    public static bool IsOnCamera(this Transform a)
    {
        Camera cam = Camera.main;

        // Convert the object's position to viewport coordinates
        Vector3 viewportPos = cam.WorldToViewportPoint(a.position);

        // Check if the object is on screen
        if (viewportPos.x > 0 && viewportPos.x < 1 && viewportPos.y > 0 && viewportPos.y < 1 && viewportPos.z > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public static class InputHelper
{
    public static bool Any()
    {
        return Input.GetMouseButtonDown(0) || Input.GetAxis("Jump") > 0 || Input.GetAxis("Fire1") > 0;
    }
}
