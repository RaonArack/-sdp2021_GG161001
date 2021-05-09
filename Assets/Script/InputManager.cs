using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


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



    public void SaveKey()
    {
        int[] keys = new int[(int)KeyAction.None] { -1, -1, -1, -1, -1, -1 };
        for (int i = 0; i < (int)KeyAction.None; i++)
        {
            keys[i] = (int)InputSetting.keys[(KeyAction)i];
        }
        string jsonData = JsonUtility.ToJson(keys);
        string path = Path.Combine(Application.dataPath, "Data/key.json");
        File.WriteAllText(path, jsonData);
    }

    public void LoadKey()
    {
        string path = Path.Combine(Application.dataPath, "Data/key.json");
        string jsonData = File.ReadAllText(path);
        int[] keys = JsonUtility.FromJson<int[]>(jsonData);

        for (int i = 0; i < (int)KeyAction.None; i++)
        {
            InputSetting.keys[(KeyAction)i] = (KeyCode)keys[i];
        }
    }
}
