using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="Inteface/Switch")]
public class SwitchInteface : ScriptableObject
{
    private Canvas _curretCanvas;
    private Canvas _lostCanvas;

    public void OnShow()
    {
        if (_lostCanvas != null)
            _lostCanvas.enabled = true;
    }
    public void OnShow(Canvas canvas)
    {
        _curretCanvas = canvas;
        _curretCanvas.enabled = true;
    }
    public void OnHide()
    {
        if (_curretCanvas != null)
            _curretCanvas.enabled = false;
        _curretCanvas = null;
    }
    public void OnHide(Canvas canvas)
    {
        canvas.enabled = false;
        _lostCanvas = canvas;
    }

}
