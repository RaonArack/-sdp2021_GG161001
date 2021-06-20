using System;
using UnityEngine;


public abstract class State : MonoBehaviour// ��� ������ �ֻ��� Ŭ����
{
    public StateMachine StateMachine { get; private set; }
    public virtual void Enter(StateMachine stateMachine) { StateMachine = stateMachine; } // ������ ���ҵ� ���� ��
    public abstract void LogicUpdate();
    public abstract void PhysicsUpdate();
    public abstract void Exit();
}


public class StateMachine// ���� ��ȯ�� �ӽ�
{
    public GameObject targetObj { get; private set; }
    public State CurrentState { get; private set; }
    public StateMachine(GameObject target) { targetObj = target; }

    public void SetState(Type nextState)
    {
        Component c = targetObj.GetComponent<State>() as Component; // �������̽��� ��ǥ�� ���� ���¸� ������
        if (c != null)
        {
            // ���� ���°� �ִٸ� �� ������ Exit�� ������ ���� ������Ʈ�� ������
            c.GetComponent<State>().Exit();
            UnityEngine.Object.Destroy(c);// MonoBehaviour�� �ƴϱ⿡, �Ϲ����� Destroy�� ��� �Ұ���.
        }
        CurrentState = targetObj.AddComponent(nextState) as State;
        CurrentState.Enter(this);
    }
}

/*
 ������Ʈ�ӽſ�, �� �ӽ��� ����ϴ� ������Ʈ�� �޾ƿ�.
 ������ ���´� �ش��ϴ� ������Ʈ�ӽſ� ������ �� �ְ� ��.
 ������Ʈ�ӽſ� Ÿ�� ������Ʈ�� ����.
 ���� �ƴ�.
*/