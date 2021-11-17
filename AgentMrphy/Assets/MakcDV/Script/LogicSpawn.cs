using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class  LogicSpawn 
{
    public abstract int CountInstateObject { get; }

    public abstract bool InstateObject();
    public abstract void CheakBusyPoint();
}
