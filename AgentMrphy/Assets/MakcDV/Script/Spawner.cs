using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] protected int maxObject;
    [SerializeField] protected GameObject spawnObject;

    protected LogicSpawn spawn;

    private void Awake()
    {
        var point = GetComponentsInChildren<Point>();
        maxObject = Mathf.Clamp(maxObject, 0, point.Length);
        spawn = new RandomSpawn(point, spawnObject);
    }
    private void Start()
    {
        StartCoroutine(SpawnObject());
    }
    protected abstract IEnumerator SpawnObject();
}
