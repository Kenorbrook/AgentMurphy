using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{

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
