using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiryaGameManager : MonoBehaviour
{
    public ObjectToTransformate[] transformableObjects;
    public static ObjectToTransformate[] transformablObjects;
    public static GameObject EndPanel;
    public GameObject endPanel;
    private void Start()
    {
        EndPanel = endPanel;
        transformablObjects = transformableObjects;
    }
}
