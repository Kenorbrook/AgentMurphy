using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private Canvas _baseMenu;
    [SerializeField] private SwitchInteface _switch;
    [SerializeField] private ChangeElementMenu[] _changeElement;
    [SerializeField] private KiryaGameManager _gameManger;
    private ChangeElementMenu _curretMenu;

    private void Awake()
    {
        _curretMenu = GetComponentInChildren<ChangeElementMenu>();
    }
    private void OnEnable()
    {
        _gameManger.GameEventAction += InstateChangeElement;
    }
    private void OnDisable()
    {
        _gameManger.GameEventAction -= InstateChangeElement;
    }
    private void InstateChangeElement(GameState state)
    {
        if (_curretMenu.State == state)
            return;
        foreach (var element in _changeElement)
        {
            if (element.State == state)
            {
                var buf = Instantiate(element, _curretMenu.transform.position, Quaternion.identity);
                buf.transform.parent = _curretMenu.transform.parent;
                buf.transform.localPosition = _curretMenu.transform.localPosition;
                buf.transform.localScale = _curretMenu.transform.localScale;
                DestroyLostElement();
                _curretMenu = buf;
                SubscribleEvent(state);
            }
        }
        _baseMenu.enabled = true;
    }
    private void DestroyLostElement()
    {
        DescribleEvent(_curretMenu.State);
        Destroy(_curretMenu.gameObject);
    }
    private void SubscribleEvent(GameState state)
    {
        switch (state)
        {
            case GameState.Pause:
                _curretMenu.ButtonPress += ReturnGame;
                _curretMenu.ButtonPress += _switch.OnHide;
                break;
            case GameState.Lose:
                    break;
            case GameState.Win:
                break;
            default:
                break;
        }
    }
    private void DescribleEvent(GameState state)
    {
        switch (state)
        {
            case GameState.Pause:
                _curretMenu.ButtonPress -= ReturnGame;
                _curretMenu.ButtonPress -= _switch.OnHide;
                break;
            case GameState.Lose:
                break;
            case GameState.Win:
                break;
            default:
                break;
        }
    }
    private void ReturnGame()
    {
         Time.timeScale = 1;
    }

}
