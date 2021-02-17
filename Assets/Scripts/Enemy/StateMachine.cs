using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class StateMachine : MonoBehaviour
{
    private Dictionary<Type, BaseState> _states;
    public BaseState CurrentState { get; private set; }
    public void SetStates(Dictionary<Type, BaseState> states)
    {
        this._states = states;
    }

    void Update()
    {
        Debug.Log("State Machine");
        if(CurrentState == null)
        {
            CurrentState = _states.Values.FirstOrDefault();
        }

        Type nextState = CurrentState?.Tick();

        if(nextState != null && nextState != CurrentState?.GetType())
        {
            CurrentState = _states[nextState];
            CurrentState.Enter();
        }
    }
}
