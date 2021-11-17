using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToTransformate : MonoBehaviour, ITransformable
{
    [SerializeField]int objectType;
    System.Random random = new System.Random(System.DateTime.Now.Millisecond);
    public void HandleTransforming()
    {
        int x = random.Next(0, KiryaGameManager.transformablObjects.Length);
        if (objectType == 1)
        {
            KiryaGameManager.Instance.EnemiesCount--;
        }
        while(x == objectType)
        {
            x = random.Next(0, 3);
        }
        if (x == 1)
        {
            KiryaGameManager.Instance.EnemiesCount++;
        }
        GameObject newObject = Instantiate(KiryaGameManager.transformablObjects[x]).gameObject;
        newObject.transform.position = transform.position;
        Destroy(gameObject);
    }
}
