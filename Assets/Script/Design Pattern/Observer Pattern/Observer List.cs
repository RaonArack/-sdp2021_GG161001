using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteObserver1 : Observer
{
    GameObject obj;

    // �����ڸ� ���� ��ü ����
    public ConcreteObserver1(GameObject obj)
    {
        this.obj = obj;
    }

    // ���Ÿ���� Ŭ�������� �� �޼ҵ带 �����Ŵ
    public override void OnNotify()
    {
    }
}