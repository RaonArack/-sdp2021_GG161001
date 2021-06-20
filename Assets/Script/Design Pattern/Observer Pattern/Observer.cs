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
    List<Observer> list = new List<Observer>();  // �������� �����ϴ� List

    // ������ �������� ���
    public void AddObserver(Observer observer) { list.Add(observer); }

    // �������� �������� ����
    public void RemoveObserver(Observer observer) { if (list.IndexOf(observer) > 0) list.Remove(observer); }

    // �������� ���������� ����
    public void Notify()
    {
        foreach (Observer obs in list)
        {
            obs.OnNotify();
        }
    }
}