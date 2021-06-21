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
    void OnNotify();
}