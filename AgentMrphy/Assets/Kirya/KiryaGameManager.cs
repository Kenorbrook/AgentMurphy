using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KiryaGameManager : MonoBehaviour
{
    public ObjectToTransformate[] transformableObjects;
    public static ObjectToTransformate[] transformablObjects;
    public static GameObject EndPanel;
    public GameObject endPanel;
    public GameObject pausePanel;
    public GameObject WinPanel;
    public static PlayerController Player;
    public PlayerController player;
    public int EnemiesCount;
    public static KiryaGameManager Instance;
    
    private void Start()
    {
        Instance = this;
        EndPanel = endPanel;
        transformablObjects = transformableObjects;
        Player = player;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (EnemiesCount <= 0)
        {
            WinPanel.SetActive(true);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseGame(bool state)
    {
        pausePanel.SetActive(state);
        if (state)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
