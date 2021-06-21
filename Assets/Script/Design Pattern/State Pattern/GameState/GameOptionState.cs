using UnityEngine;

public class GameOptionState : State
{
    DisplayUI displayUI;
    Observer unit1;
    public override void Enter(StateMachine stateMachine)
    {
        Debug.Log("환경설정");
        base.Enter(stateMachine);

        displayUI = GameManager.Instance().displayUI;
        unit1 = new Obs_UICommandChange(displayUI);// 조작키 설정

        displayUI.AddObserver(unit1);
        displayUI.OnNotify();

        displayUI.optionMenu.SetActive(true);

        GameManager.Instance().debri.SetActive(false);
        GameManager.Instance().player.gameObject.SetActive(false);
    }

    public override void Exit()
    {
        displayUI.RemoveObserver(unit1);
        displayUI.optionMenu.SetActive(false);
    }

    public override void LogicUpdate()
    {
    }

    public override void PhysicsUpdate()
    {
    }
}
