using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class StateMachine : MonoBehaviour
{
    private Dictionary<BossState, BaseState> _states;
    public BossState CurrentState { get; private set; }
    public void SetStates(Dictionary<BossState, BaseState> states)
    {
        this._states = states;
    }

    void Update()
    {
        if (GameManager.Instance.IsGameOver)
        {
            return;
        }
        Debug.Log(CurrentState);
        BossState nextState = _states[CurrentState].Tick();

        if(nextState != CurrentState)
        {
            _states[CurrentState].Exit();
            CurrentState = nextState;
            _states[CurrentState].Enter();
        }
    }
}
