using UnityEngine;

public class GamePlayBossState : State
{
    public override void Enter(StateMachine stateMachine)
    {
        base.Enter(stateMachine);
        Debug.Log("보스전");
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
