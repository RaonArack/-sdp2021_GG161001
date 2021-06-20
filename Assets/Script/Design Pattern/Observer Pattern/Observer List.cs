using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteObserver1 : Observer
{
    GameObject obj;

    // 생성자를 통해 객체 전달
    public ConcreteObserver1(GameObject obj)
    {
        this.obj = obj;
    }

    // 대상타입의 클래스에서 이 메소드를 실행시킴
    public override void OnNotify()
    {
    }
}