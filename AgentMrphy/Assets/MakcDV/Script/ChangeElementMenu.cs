using UnityEngine;
using UnityEngine.UI;

public class ChangeElementMenu : MonoBehaviour
{
    [SerializeField] protected GameState state;

    public delegate void ButtonAction();
    public event ButtonAction ButtonPress;

    public GameState State => state;

    public void OnButtonPress()
    {
        if (ButtonPress != null)
            ButtonPress();
    }
}