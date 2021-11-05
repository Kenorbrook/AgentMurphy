using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{

    [SerializeField] PlayerController playerController;
    private void Awake()
    {
        
    }
}
