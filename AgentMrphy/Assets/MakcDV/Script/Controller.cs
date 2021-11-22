using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class Controller : MonoBehaviour
{
    [SerializeField] protected float delayNextShoot;

    public abstract float Direction { get; }

    public delegate void ControllerEvent();
    public abstract event ControllerEvent JumpEvent;
    public abstract event ControllerEvent ShootEvent;

}
