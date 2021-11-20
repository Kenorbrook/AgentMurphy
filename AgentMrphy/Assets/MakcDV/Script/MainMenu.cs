using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioMixerSetting _inteface;
    [SerializeField] private AudioMixerSetting _scene;

    private void Awake()
    {
        _inteface.OnChooseMode(true);
        _scene.OnChooseMode(false);
    }
}
