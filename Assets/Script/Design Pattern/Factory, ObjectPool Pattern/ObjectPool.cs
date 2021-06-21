using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPool
{
    [SerializeField] List<GameObject> objectPool; 
    public ObjectPool() 
    {
        objectPool = new List<GameObject>();
    }

    public GameObject AddObject(GameObject obj)
    {
        GameObject unit = GameObject.Instantiate(obj);
        objectPool.Add(unit);
        return unit;
    }

    public GameObject SpawnObject() 
    {
        for (int i = 0; i < objectPool.Count; i++) 
        {
            if (objectPool[i].activeSelf == true) continue;
            objectPool[i].SetActive(true);
            return objectPool[i];
        }
        return null;
    }
}