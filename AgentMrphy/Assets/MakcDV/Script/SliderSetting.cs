using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SliderSetting 
{
    [SerializeField] private SaveKey _key;
    [SerializeField] private Slider _slider;

    private float Value => PlayerPrefs.HasKey(_key.Key) ? PlayerPrefs.GetFloat(_key.Key) : 1f;

    public void SetValue()
    {
        _slider.value = Value;
    }

    public void SaveValueSlider(Slider slider)
    {
        PlayerPrefs.SetFloat(_key.Key, slider.value);
        PlayerPrefs.Save();
    }

}
