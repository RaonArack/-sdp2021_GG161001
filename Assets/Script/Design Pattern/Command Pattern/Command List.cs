using UnityEngine;

public class CommandLeft : Command
{
	Player player;
	public CommandLeft()
	{
		player = GameManager.Instance().player;
	}

	public override void Execute()
	{
		player.faceDir = -1;
		if (player.RB.velocity.x > -player.speed) 
			player.RB.AddForce(new Vector2(-player.accel, 0), ForceMode2D.Force);
		else
			player.RB.velocity = new Vector2(-player.speed, player.RB.velocity.y);
	}
}

public class CommandRight : Command
{
	Player player;
	public CommandRight()
	{
		player = GameManager.Instance().player;
	}

	public override void Execute()
	{
		player.faceDir = 1;
		if (player.RB.velocity.x < player.speed)
			player.RB.AddForce(new Vector2(player.accel, 0), ForceMode2D.Force);
		else
			player.RB.velocity = new Vector2(player.speed, player.RB.velocity.y);
	}
}

public class CommandJump : Command
{
	Player player;
	public CommandJump()
	{
		player = GameManager.Instance().player;
	}
	public override void Execute()
	{
		player.RB.velocity = new Vector2(player.RB.velocity.x, player.jumpForce);
	}
}

public class CommandJumpHold : Command
{
	Player player;
	public CommandJumpHold()
	{
		player = GameManager.Instance().player;
	}
	public override void Execute()
	{
		player.RB.gravityScale = 7;
	}

    public override void Interrupt()
    {
		player.RB.gravityScale = 10;
	}
}

public class CommandAttack : Command
{
	float time;
	Player player;
	public CommandAttack() 
	{
		player = GameManager.Instance().player.GetComponent<Player>();
	}

	public override void Execute()
    {
		if (Time.time > time) 
		{
			time += 0.15f;// 초당 약 여섯발
			if (Time.time > time) time = Time.time + 0.15f; // 시간을 증가시키고도 여전히 time보다 작으면 강제조정
			player.Shot();
		}
	}

    public override void Interrupt()
    {
		time = 0;
		base.Interrupt();
    }
}


#region 아래는 중간과제에만 사용하는 것
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

#endregion