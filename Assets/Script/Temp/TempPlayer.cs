using UnityEngine;

public enum KeyAction
{
	OK,
	Cancel,
	Key1,
	Key2,
	Key3,
	Key4,
	None
}

public class TempPlayer : MonoBehaviour
{

	[SerializeField] KeyAction pressedBtn = KeyAction.None;
	Command ok, cancel, key1, key2, key3, key4;

	void Start()
	{
		ok = new CommandOK();
		cancel = new CommandCancel();
		key1 = new CommandKey1();
		key2 = new CommandKey2();
		key3 = new CommandKey3();
		key4 = new CommandKey4();
	}

	void Update()
	{
		if (IsPressed(KeyAction.OK)) ok.Execute();
		else if (IsPressed(KeyAction.Cancel)) cancel.Execute();
		else if (IsPressed(KeyAction.Key1)) key1.Execute();
		else if (IsPressed(KeyAction.Key2)) key2.Execute();
		else if (IsPressed(KeyAction.Key3)) key3.Execute();
		else if (IsPressed(KeyAction.Key4)) key4.Execute();
	}
	
	bool IsPressed(KeyAction btn)
	{
		pressedBtn = KeyAction.None;
		if (Input.GetKeyDown(InputSetting.keys[btn])) { pressedBtn = btn; }
		return (btn == pressedBtn);
	}
}
