using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName ="Level/Switch")]
public class SwitchLevel : ScriptableObject
{
    [SerializeField] private int _mainMenu;
    [SerializeField] private int _startLVL;

    public void OnToMainMenu()
    {
        LoadLevel(_mainMenu);
    }

    public void OnLoadStartLVL()
    {
        LoadLevel(_startLVL);
    }

    private void LoadLevel(int id)
    {
        SceneManager.LoadScene(id);
    }
}
