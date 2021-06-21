using UnityEngine;

public class GamePlayFieldState : State
{
    DisplayUI displayUI;
    public override void Enter(StateMachine stateMachine)
    {
        Debug.Log("필드전");
        base.Enter(stateMachine);
        displayUI = GameManager.Instance().displayUI;

        displayUI.fieldMenu.SetActive(true);

        GameManager.Instance().debri.SetActive(true);
        GameManager.Instance().player.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        GameManager.Instance().debri.SetActive(false);
        displayUI.fieldMenu.SetActive(false);
    }

    public override void LogicUpdate()
    {
    }

    public override void PhysicsUpdate()
    {
    }
}
