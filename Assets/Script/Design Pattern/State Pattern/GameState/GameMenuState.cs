using UnityEngine;

public class GameMenuState : State
{
    public override void Enter(StateMachine stateMachine)
    {
        base.Enter(stateMachine);
        Debug.Log("메인메뉴");
    }

    public override void Exit()
    {
    }

    public override void LogicUpdate()
    {
    }

    public override void PhysicsUpdate()
    {
    }
}
