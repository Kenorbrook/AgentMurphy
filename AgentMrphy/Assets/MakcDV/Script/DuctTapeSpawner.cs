using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuctTapeSpawner : Spawner
{
    protected override IEnumerator SpawnObject()
    {
        while (true)
        {
            float countObjectScene = spawn.CountInstateObject;
            if (countObjectScene / maxObject < 0.3f)
            {
                for (int i = spawn.CountInstateObject; i < maxObject; i++)
                {
                    while (!spawn.InstateObject())
                    {
                    }
                }
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
                spawn.CheakBusyPoint();
            }
        }
    }
}
