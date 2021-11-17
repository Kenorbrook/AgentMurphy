using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : LogicSpawn
{
    private List<Point> _listInstateObject = new List<Point>();

    private readonly Point[] _point;
    private readonly GameObject _spawnObject;

    public RandomSpawn(Point[] point, GameObject spawnObject)
    {
        _point = point;
        _spawnObject = spawnObject;
    }

    public override int CountInstateObject => _listInstateObject.Count;

    public override bool InstateObject()
    {
        int index = Random.Range(0, _point.Length);
        if (!_point[index].PointBusy)
        {
            _listInstateObject.Add(_point[index]);
            return _point[index].Spwan(_spawnObject);
        }
        return false;
    }

    public override void CheakBusyPoint()
    {
        var newList = new List<Point>();
        foreach (var instateObject in _listInstateObject)
        {
            if (instateObject.PointBusy)
                newList.Add(instateObject);
        }
        _listInstateObject = newList;
    }
}
