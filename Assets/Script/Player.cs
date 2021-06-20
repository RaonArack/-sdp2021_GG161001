using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    ObserverSubject observer;
    CommandManager command;
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
    }

    void Start()
    {
        observer = new ObserverSubject();
        observer.AddObserver(new ConcreteObserver1(gameObject));

        command = new CommandManager();
        command.SetCommand("Left", KeyCode.LeftArrow);
        command.SetCommand("Right", KeyCode.RightArrow);
        command.SetCommand("Jump", KeyCode.Z);
        command.SetCommand("Attack", KeyCode.X);

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
        transform.position = Vector3.zero;
    }

    void Update()
    {
        if (Input.GetKey(command.commandDic["Left"])) { cmd_Left.Execute(); }
        if (Input.GetKey(command.commandDic["Right"])) { cmd_Right.Execute(); }
        if (Input.GetKeyDown(command.commandDic["Jump"])) { cmd_Jump.Execute(); }
        if (Input.GetKey(command.commandDic["Jump"])) { cmd_JumpHold.Execute(); } else { cmd_JumpHold.Interrupt(); }
        if (Input.GetKey(command.commandDic["Attack"])) { cmd_Attack.Execute(); }
        if (Input.GetKeyUp(command.commandDic["Attack"])) { cmd_Attack.Interrupt(); }

        if (transform.position.x > 16f) { transform.Translate(-32f, 0, 0); }
        if (transform.position.x < -16f) { transform.Translate(32f, 0, 0); }
        if (transform.position.y > 12.5f) { transform.Translate(0, -25f, 0); }
        if (transform.position.y < -12.5f) { transform.Translate(0, 25f, 0); }
    }

    public void Shot()
    {
        bulletFactory.CreateObject(0);
    }
}