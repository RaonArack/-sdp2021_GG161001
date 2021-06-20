using System;
using UnityEngine;


public abstract class State : MonoBehaviour// 모든 상태의 최상위 클래스
{
    public StateMachine StateMachine { get; private set; }
    public virtual void Enter(StateMachine stateMachine) { StateMachine = stateMachine; } // 생성자 역할도 같이 함
    public abstract void LogicUpdate();
    public abstract void PhysicsUpdate();
    public abstract void Exit();
}


public class StateMachine// 상태 전환용 머신
{
    public GameObject targetObj { get; private set; }
    public State CurrentState { get; private set; }
    public StateMachine(GameObject target) { targetObj = target; }

    public void SetState(Type nextState)
    {
        Component c = targetObj.GetComponent<State>() as Component; // 인터페이스를 대표로 현재 상태를 가져옴
        if (c != null)
        {
            // 현재 상태가 있다면 그 상태의 Exit를 실행한 다음 컴포넌트를 제거함
            c.GetComponent<State>().Exit();
            UnityEngine.Object.Destroy(c);// MonoBehaviour가 아니기에, 일반적인 Destroy는 사용 불가능.
        }
        CurrentState = targetObj.AddComponent(nextState) as State;
        CurrentState.Enter(this);
    }
}

/*
 스테이트머신에, 이 머신을 사용하는 오브젝트를 받아옴.
 각각의 상태는 해당하는 스테이트머신에 접근할 수 있게 함.
 스테이트머신에 타겟 오브젝트가 있음.
 좋아 됐다.
*/