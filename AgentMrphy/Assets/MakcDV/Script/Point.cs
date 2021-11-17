using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private GameObject _curretObject;
    private Transform _point;

    public bool PointBusy => _curretObject != null;
    public Vector3 Position => _point.position;

    private void Awake()
    {
        _point = transform;
    }

    public bool Spwan(GameObject spawnObject)
    {
        if (PointBusy)
            return false;
        _curretObject = Instantiate(spawnObject, transform.position, Quaternion.identity);
        return true;
    }
}
