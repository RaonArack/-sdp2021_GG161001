using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Factory // 심플 팩토리에 오브젝트 풀을 섞은 형태
{
    public GameObject[] prefabs;// 등록할 프리팹
    List<ObjectPool> objectPools;// 대응되는 오브젝트 풀

    public void Init()
    {
        objectPools = new List<ObjectPool>();
        for (int i = 0; i < prefabs.Length; i++)
        {
            objectPools.Add(new ObjectPool());
        }
    }

    public GameObject CreateObject(int num)
    {
        GameObject gameObject = objectPools[num].SpawnObject();
        if (gameObject == null) 
        {
            gameObject = objectPools[num].AddObject(prefabs[num]);
        }
        return gameObject;
    }
}