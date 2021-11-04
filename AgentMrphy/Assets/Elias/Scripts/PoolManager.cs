using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Elias
{
    public class PoolManager : Singleton<PoolManager>
    {
        [SerializeField] ObjectPooler projectilePool;
        public ObjectPooler PojectilePool
        {
            get { return projectilePool; }
        }
    }
}
