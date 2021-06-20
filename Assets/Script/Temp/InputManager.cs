using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public static class InputSetting
{
    public static Dictionary<KeyAction, KeyCode> keys = new Dictionary<KeyAction, KeyCode>();
}

public class InputManager : MonoBehaviour
{

    KeyCode[] defaultKeys = new KeyCode[] { KeyCode.Return, KeyCode.Escape, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F };

    private void Awake()
    {
        for (int i = 0; i < (int)KeyAction.None; i++)
        {
            InputSetting.keys.Add((KeyAction)i, defaultKeys[i]);
        }
    }

    public void InitKey()
    {
        for (int i = 0; i < (int)KeyAction.None; i++)
        {
            InputSetting.keys[(KeyAction)i] = defaultKeys[i];
        }
    }

    int key = -1;
    public void ChangeKey(int num) { key = num; }
    private void OnGUI()
    {
        Event keyEvent = Event.current;

        if (key != -1 && keyEvent.isKey)
        {
            for (int i = 0; i < (int)KeyAction.None; i++)
            {
                if (i == key) InputSetting.keys[(KeyAction)i] = keyEvent.keyCode;
                else if (InputSetting.keys[(KeyAction)i] == keyEvent.keyCode) InputSetting.keys[(KeyAction)i] = KeyCode.None;
            }
            key = -1;
        }
    }


}
