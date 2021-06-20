using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Observer
{
    public abstract void OnNotify();
}

public interface ISubject
{
    void AddObserver(Observer observer);
    void RemoveObserver(Observer observer);
    void Notify();
}

public class ObserverSubject : ISubject
{
    List<Observer> list = new List<Observer>();  // 옵저버를 관리하는 List

    // 관리할 옵저버를 등록
    public void AddObserver(Observer observer) { list.Add(observer); }

    // 관리중인 옵저버를 삭제
    public void RemoveObserver(Observer observer) { if (list.IndexOf(observer) > 0) list.Remove(observer); }

    // 관리중인 옵저버에게 연락
    public void Notify()
    {
        foreach (Observer obs in list)
        {
            obs.OnNotify();
        }
    }
}