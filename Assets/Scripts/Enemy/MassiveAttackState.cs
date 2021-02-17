using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassiveAttackState : BaseState
{
    Boss _boss;
    private bool _isCoroutineRunning;
    private int _projectilesNum;
    private Type _nextState;
    public MassiveAttackState(Boss boss) : base(boss.gameObject)
    {
        this._boss = boss;
    }

    public override void Enter()
    {
        _isCoroutineRunning = false;
        _projectilesNum = 20;
        _nextState = null;
    }


    public override Type Tick()
    {
        if (!_isCoroutineRunning)
        {
            _boss.BossStartCoroutine(MassiveAttackRoutine());
        }
        return _nextState;
    }

    private IEnumerator MassiveAttackRoutine()
    {
        _isCoroutineRunning = true;
        yield return new WaitForSeconds(1f);
        float step = 360f / _projectilesNum;
        for (int j = 0; j < 3; j++)
        {
            yield return new WaitForSeconds(0.5f);
            for (int i = 0; i < _projectilesNum; i++)
            {
                UnityEngine.Object.Instantiate(_boss.EnemyScriptableObject.BulletPrefab, transform.position, Quaternion.Euler(new Vector3(0f, 0f, step * i + j * 10f)));
            }
        }
        yield return new WaitForSeconds(1f);
        _nextState = typeof(SingleAttackState);
        //_isCoroutineRunning = false;
    }
}
