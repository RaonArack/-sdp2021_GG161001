using UnityEngine;

public class GameOverState : State
{
    public override void Enter(StateMachine stateMachine)
    {
        base.Enter(stateMachine);
        Debug.Log("게임오버");
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