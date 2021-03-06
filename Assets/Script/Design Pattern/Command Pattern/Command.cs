using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Command
{
	public abstract void Execute();
	public virtual void Interrupt() { } 
}

public class CommandManager
{
	public Dictionary<string, KeyCode> commandDic;// = new Dictionary<string, KeyCode>();

	public CommandManager()
	{
		commandDic = new Dictionary<string, KeyCode>();
	}

	public void SetCommand(string name, KeyCode keycode) // 커맨드를 세팅
	{
		KeyCode inputCode = keycode;// Value를 받아옴
		Debug.Log(commandDic.ContainsValue(keycode));
		if (commandDic.ContainsValue(keycode))// 입력값이 이미 있다면
		{
			string keyName = commandDic.FirstOrDefault(x => x.Value == keycode).Key;// 그 값을 가진 키를 찾아서
			commandDic[keyName] = KeyCode.None;// 그 값을 없애버림
			/*
			Debug.Log("keyName" + keyName);
			inputCode = commandDic[keyName];// 입력값을 그 키의 값으로 바꾸고
			Debug.Log("inputCode" + inputCode);
			commandDic[keyName] = keycode;// 해당 키의 값엔 원래 입력값을 넣음
			Debug.Log("commandDic[keyName] " + commandDic[keyName]);
			*/
		}

		if (commandDic.ContainsKey(name))// 키가 이미 있다면
		{
			commandDic[name] = inputCode;// 그 키의 값을 바꿈
		}
		else// 키가 없다면 
		{
			commandDic.Add(name, inputCode);
		}
	}

	public void RemoveCommand(string name)
	{
		commandDic.Remove(name);
	}

	public KeyCode GetCommand(string name)
	{
		return commandDic[name];
	}

	public int GetCommandCount() { return commandDic.Count; }
}