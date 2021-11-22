using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KiryaGameManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private AudioMixerSetting _inteface;
    [SerializeField] private AudioMixerSetting _scene;

    public delegate void GameEvent(GameState state);
    public event GameEvent GameEventAction;

    public ObjectToTransformate[] transformableObjects;
    public static ObjectToTransformate[] transformablObjects;
    public int EnemiesCount;
    public static KiryaGameManager Instance;

    private void OnEnable()
    {
        _player.PlayerEventAction += LoseGame;
    }
    private void OnDisable()
    {
        _player.PlayerEventAction -= LoseGame;
    }
    private void Start()
    {
        Instance = this;
        transformablObjects = transformableObjects;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (EnemiesCount <= 0)
        {
            SwithAudioMixer(_inteface, _scene);
            InvokeEvent(GameState.Win);
        }
    }
    private void LoseGame()
    {
        Time.timeScale = 0;
        SwithAudioMixer(_inteface, _scene);
        InvokeEvent(GameState.Lose);
    }
    private void SwithAudioMixer(AudioMixerSetting on, AudioMixerSetting off = null)
    {
        on.OnChooseMode(true);
        if(off !=null)
            off.OnChooseMode(false);
    }
    public void PauseGame()
    {
        InvokeEvent(GameState.Pause);
        Time.timeScale = 0;
    }
    private void InvokeEvent(GameState state)
    {
        if (GameEventAction != null)
            GameEventAction(state);
    }
}
