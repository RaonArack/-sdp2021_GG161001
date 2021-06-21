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

	public void SetCommand(string name, KeyCode keycode) // Ŀ�ǵ带 ����
	{
		KeyCode inputCode = keycode;// Value�� �޾ƿ�
		Debug.Log(commandDic.ContainsValue(keycode));
		if (commandDic.ContainsValue(keycode))// �Է°��� �̹� �ִٸ�
		{
			string keyName = commandDic.FirstOrDefault(x => x.Value == keycode).Key;// �� ���� ���� Ű�� ã�Ƽ�
			commandDic[keyName] = KeyCode.None;// �� ���� ���ֹ���
			/*
			Debug.Log("keyName" + keyName);
			inputCode = commandDic[keyName];// �Է°��� �� Ű�� ������ �ٲٰ�
			Debug.Log("inputCode" + inputCode);
			commandDic[keyName] = keycode;// �ش� Ű�� ���� ���� �Է°��� ����
			Debug.Log("commandDic[keyName] " + commandDic[keyName]);
			*/
		}

		if (commandDic.ContainsKey(name))// Ű�� �̹� �ִٸ�
		{
			commandDic[name] = inputCode;// �� Ű�� ���� �ٲ�
		}
		else// Ű�� ���ٸ� 
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