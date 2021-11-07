using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToTransformate : MonoBehaviour, ITransformable
{
    [SerializeField]int objectType;
    System.Random random = new System.Random(System.DateTime.Now.Millisecond);
    public void HandleTransforming()
    {
        int x = random.Next(0, 2);
        while(x == objectType)
        {
            x = random.Next(0, 2);
        }
        Instantiate(KiryaGameManager.transformablObjects[x]);
        Destroy(gameObject);
    }
}
