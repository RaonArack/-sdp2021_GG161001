using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command
{
	public virtual void Execute() { }
}

public class CommandOK : Command
{
	public override void Execute()
	{
		OK();
	}

	void OK()
	{
		Debug.Log("OK");
	}
}

public class CommandCancel : Command
{
	public override void Execute()
	{
		Cancel();
	}

	void Cancel()
	{
		Debug.Log("Cancel");
	}
}

public class CommandKey1 : Command
{
	public override void Execute()
	{
		Key1();
	}

	void Key1()
	{
		Debug.Log("Key1");
	}
}

public class CommandKey2 : Command
{
	public override void Execute()
	{
		Key2();
	}

	void Key2()
	{
		Debug.Log("Key2");
	}
}

public class CommandKey3 : Command
{
	public override void Execute()
	{
		Key3();
	}

	void Key3()
	{
		Debug.Log("Key3");
	}
}

public class CommandKey4 : Command
{
	public override void Execute()
	{
		Key4();
	}

	void Key4()
	{
		Debug.Log("Key4");
	}
}