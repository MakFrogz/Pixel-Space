using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BossBig : Boss
{
    [SerializeField] private GameObject _laser;

    private StateMachine _stateMachine;
    private new void Start()
    {
        base.Start();
        _laser.SetActive(false);
    }

    private new void Awake()
    {
        base.Awake();
        _stateMachine = GetComponent<StateMachine>();
        InitializeStateMachine();
    }

    private void InitializeStateMachine()
    {
        Dictionary<Type, BaseState> states = new Dictionary<Type, BaseState>()
        {
            { typeof(IntroState), new IntroState(this)},
            { typeof(SingleAttackState), new SingleAttackState(this)},
            { typeof(MassiveAttackState), new MassiveAttackState(this)}
        };
        _stateMachine.SetStates(states);
    }

    /*private void LaserAttack()
    {
        _laser.SetActive(true);
        StartCoroutine("LaserAttackRoutine");
    }

    private IEnumerator LaserAttackRoutine()
    {
        _isCoroutineRunning = true;
        yield return new WaitForSeconds(1f);
        _laser.GetComponent<Animator>().SetBool("Attack", true);
        _speed *= 2f;
        yield return new WaitForSeconds(2f);
        _laser.GetComponent<Animator>().SetBool("Attack", false);
        _laser.SetActive(false);
        _speed /= 2f;
        _isCoroutineRunning = false;
        _currentState = BossState.SingleAttack;
    }*/

}
