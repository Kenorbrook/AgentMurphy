using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    //[SerializeField] private AudioMixer _sceneMixer;
    [SerializeField] Animator SettingsAnimator;
    [SerializeField] Animator AuthorsAnimator;
    [SerializeField] AudioSource audioSource;
    [SerializeField] float musicVolume = 1F;
    bool settingsEnabled = false;
    bool authorsEnabled = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = musicVolume;
    }
    public void OnChangeVolume(float vol)
    {
        musicVolume = vol;
    }
    /*public void OnChangeVolume(Slider slider)
    {
        float volume = 1 - slider.value;
        _sceneMixer.SetFloat("volume", -10 * volume);
    }*/
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
