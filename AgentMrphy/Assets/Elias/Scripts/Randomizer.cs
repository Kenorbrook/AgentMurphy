using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : Singleton<Randomizer>
{
    [System.Serializable]
    class RandomItem
    {
        [SerializeField] GameObject prefab;
        [SerializeField] int chanceWeight;
        public GameObject Prefab { get { return prefab; } }
        public int ChanceWeight { get { return chanceWeight; } }
    }
    [SerializeField] List<RandomItem> ItemList;
    List<GameObject> spawnObjects;
    private void OnEnable()
    {
        SetUpItemList();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Vector3 pos = new Vector3(Random.Range(0f, 25f), Random.Range(0f, 25f), Random.Range(0f, 25f));
            CreateRandomObject(pos);
        }
    }
    void SetUpItemList()
    {
        spawnObjects = new List<GameObject>();
        foreach (RandomItem item in ItemList)
        {
            if(item.ChanceWeight!=0)
                for (int i = 0; i < item.ChanceWeight; i++)
                spawnObjects.Add(item.Prefab);
        }
    }
    public void CreateRandomObject(Vector3 position)
    {
        Instantiate(spawnObjects[Random.Range(0, spawnObjects.Count)], position, Quaternion.identity);
    }
}
