using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameSetting : MonoBehaviour
{
    [SerializeField] private SliderSetting _sound;
    [SerializeField] private SliderSetting _effetct;
    [SerializeField] private AudioMixerSetting _soundSetting;
    [SerializeField] private AudioMixerSetting _intefaceSetting;

    private void Awake()
    {
        _sound.SetValue();
        _effetct.SetValue();

    }
    private void Start()
    {
        _soundSetting.LoadSetting();
        _intefaceSetting.LoadSetting();
    }
    private void OnDisable()
    {
        PlayerPrefs.Save();
    }
    public void OnSound(Slider slider)
    {
        _sound.SaveValueSlider(slider);
    }
    public void OnEffetct(Slider slider)
    {
        _effetct.SaveValueSlider(slider);
    }

}
