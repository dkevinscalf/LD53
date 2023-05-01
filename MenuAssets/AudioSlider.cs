using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    public string ParameterName = "SFXVolume";
    public AudioMixer Mixer;

    public void Start()
    {
        Mixer.GetFloat(ParameterName, out var startVal);
        var slider = GetComponent<Slider>();
        slider.value = startVal;
        slider.maxValue = 20;
        slider.minValue = -80;
    }

    public void SetVolume(float value)
    {
        Mixer.SetFloat(ParameterName, value);
    }
}
