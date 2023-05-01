using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeldCargoItem : MonoBehaviour
{
    public Image Label;

    public void Setup(CargoItem cargo)
    {
        Label.sprite = cargo.CargoSprite;
    }
}
