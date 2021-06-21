using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obs_UICommandChange : Observer
{

    DisplayUI displayUI;
    CommandManager command;

    public Obs_UICommandChange(DisplayUI displayUI)
    {
        this.displayUI = displayUI;
        command = GameManager.Instance().player.command;
    }

    public override void OnNotify()
    {
        Debug.Log("키변경 옵저버 작동됨");
        displayUI.leftKey.text = GetCommandText(command.GetCommand("Left"));
        displayUI.rightKey.text = GetCommandText(command.GetCommand("Right"));
        displayUI.jumpKey.text = GetCommandText(command.GetCommand("Jump"));
        displayUI.attackKey.text = GetCommandText(command.GetCommand("Attack"));
    }

    string GetCommandText(KeyCode keyCode)
    {
        switch (keyCode)
        {
            case KeyCode.LeftArrow: 
                return "Left";
            case KeyCode.RightArrow:
                return "Right";
            case KeyCode.UpArrow:
                return "Up";
            case KeyCode.DownArrow:
                return "Down";
            case KeyCode.None: 
                return "---";
            default: 
                return keyCode.ToString();
        }
    }
}