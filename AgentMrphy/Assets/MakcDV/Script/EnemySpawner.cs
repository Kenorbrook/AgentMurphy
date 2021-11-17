using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    protected override IEnumerator SpawnObject()
    {
        for (int i = 0; i < maxObject; i++)
        {
            while (!spawn.InstateObject())
            {              
            }
        }
        yield return null;
    }
}
