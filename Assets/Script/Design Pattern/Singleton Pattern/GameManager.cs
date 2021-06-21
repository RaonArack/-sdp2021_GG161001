using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const float Width = 32f;
    public const float Height = 25f;

    static GameManager _instance = null;
    public static GameManager Instance() { return _instance; }

    public DisplayUI displayUI;

    StateMachine gameState;


    public Player player;
    public GameObject debri;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (this != _instance)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        gameState = new StateMachine(gameObject);
        ChangeMenu(0);
    }

    public void ChangeMenu(int num)
    {
        switch (num)
        {
            default: gameState.SetState(typeof(GameMenuState)); break;
            case 1: gameState.SetState(typeof(GameOptionState)); break;
            case 2: gameState.SetState(typeof(GamePlayFieldState)); break;
            case 3: gameState.SetState(typeof(GamePlayBossState)); break;
            case 4: gameState.SetState(typeof(GameOverState)); break;
        }
    }
}