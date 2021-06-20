using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager _instance = null;
    public static GameManager Instance() { return _instance; }

    StateMachine gameState;


    public Player player;

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
        gameState.SetState(typeof(GameMenuState));
    }
}