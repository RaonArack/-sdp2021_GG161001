using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Factory // ���� ���丮�� ������Ʈ Ǯ�� ���� ����
{
    public GameObject[] prefabs;// ����� ������
    List<ObjectPool> objectPools;// �����Ǵ� ������Ʈ Ǯ

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