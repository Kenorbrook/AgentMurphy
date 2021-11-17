using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private AudioMixer _sceneMixer;
    [SerializeField] Animator SettingsAnimator;
    [SerializeField] Animator AuthorsAnimator;

    bool settingsEnabled = false;
    bool authorsEnabled = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnChangeVolume(Slider slider)
    {
        float volume = 1 - slider.value;
        _sceneMixer.SetFloat("volume", -80 * volume);
    }
    public void OnExitGame()
    {
        Application.Quit();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenWindow(string window_to_open)
    {
        switch (window_to_open){
            case "settings":
                SettingsAnimator.SetBool("Opened", !settingsEnabled);
                settingsEnabled = !settingsEnabled;
                break;
            case "authors":
                AuthorsAnimator.SetBool("Opened", !authorsEnabled);
                authorsEnabled = !authorsEnabled;
                break;
        }
    }
}
