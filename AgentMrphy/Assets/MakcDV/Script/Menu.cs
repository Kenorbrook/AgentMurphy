using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Menu
{
    [SerializeField] private Canvas _useMenu;

    public Canvas UseMenu => _useMenu;
}
