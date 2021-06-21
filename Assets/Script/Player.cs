using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CommandManager command;
    Command cmd_Left, cmd_Right, cmd_Jump, cmd_JumpHold, cmd_Attack;

    [SerializeField] Factory bulletFactory;

    public Rigidbody2D RB;

    public float speed;
    public float accel;
    public float jumpForce;
    [HideInInspector] public int faceDir;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        Debug.Log("플레이어 깨어남");
    }

    void Start()
    {
        command = new CommandManager();
        command.SetCommand("Left", KeyCode.LeftArrow);
        command.SetCommand("Right", KeyCode.RightArrow);
        command.SetCommand("Jump", KeyCode.Z);
        command.SetCommand("Attack", KeyCode.X);

        Debug.Log("조작키 Left :" + command.GetCommand("Left"));

        cmd_Left = new CommandLeft();
        cmd_Right = new CommandRight();
        cmd_Jump = new CommandJump();
        cmd_JumpHold = new CommandJumpHold();
        cmd_Attack = new CommandAttack();

        bulletFactory.Init();

        faceDir = 1;
    }

    private void OnEnable()
    {
        faceDir = 1;
        transform.position = Vector3.zero;
        RB.velocity = new Vector2(0, jumpForce);
    }

    void Update()
    {
        if (Input.GetKey(command.commandDic["Left"])) { cmd_Left.Execute(); }
        if (Input.GetKey(command.commandDic["Right"])) { cmd_Right.Execute(); }
        if (Input.GetKeyDown(command.commandDic["Jump"])) { cmd_Jump.Execute(); }
        if (Input.GetKey(command.commandDic["Jump"])) { cmd_JumpHold.Execute(); } else { cmd_JumpHold.Interrupt(); }
        if (Input.GetKey(command.commandDic["Attack"])) { cmd_Attack.Execute(); }
        if (Input.GetKeyUp(command.commandDic["Attack"])) { cmd_Attack.Interrupt(); }

        if (transform.position.x > GameManager.Width / 2) { transform.Translate(-GameManager.Width, 0, 0); }
        if (transform.position.x < -GameManager.Width / 2) { transform.Translate(GameManager.Width, 0, 0); }
        if (transform.position.y > GameManager.Height / 2) { transform.Translate(0, -GameManager.Height, 0); }
        if (transform.position.y < -GameManager.Height / 2) { transform.Translate(0, GameManager.Height, 0); }
    }

    public void Shot()
    {
        bulletFactory.CreateObject(0);
    }
}