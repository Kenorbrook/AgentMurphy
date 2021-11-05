using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIController : Singleton<UIController>
{
    public UnityEvent JumpClickAction;
    public UnityEvent ShootClickAction;

    [SerializeField] Button jumpButton;
    [SerializeField] Button shootButton;

    protected override void Awake()
    {
        base.Awake();

        jumpButton.onClick.AddListener(()=>
        {
            JumpClickAction?.Invoke();
        });

        shootButton.onClick.AddListener(() =>
        {
            ShootClickAction?.Invoke();
        });
    }
}
