using UnityEngine;

public class GameMenuState : State
{
    DisplayUI displayUI;
    public override void Enter(StateMachine stateMachine)
    {
        Debug.Log("메인메뉴");
        base.Enter(stateMachine);
        
        displayUI = GameManager.Instance().displayUI;

        displayUI.mainMenu.SetActive(true);

        GameManager.Instance().debri.SetActive(false);
        GameManager.Instance().player.gameObject.SetActive(false);
    }

    public override void Exit()
    {
        displayUI.mainMenu.SetActive(false);
    }

    public override void LogicUpdate()
    {
    }

    public override void PhysicsUpdate()
    {
    }
}
