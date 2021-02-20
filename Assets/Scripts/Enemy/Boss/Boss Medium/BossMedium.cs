using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BossMediumNameSpace;

public class BossMedium : Boss
{
    private StateMachine _stateMachine;

    protected new void Awake()
    {
        base.Awake();
        _stateMachine = GetComponent<StateMachine>();
        InitializeStateMachine();
    }

    private void InitializeStateMachine()
    {
        Dictionary<BossState, BaseState> states = new Dictionary<BossState, BaseState>()
        {
            {BossState.Intro, new IntroState(this) },
            {BossState.SingleAttack, new SingleAttackState(this) },
            {BossState.MassiveAttack, new MassiveAttackState(this) }

        };
        _stateMachine.SetStates(states);
    }
}
