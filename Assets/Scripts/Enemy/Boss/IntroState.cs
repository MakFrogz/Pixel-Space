using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class IntroState : BaseState
{
    private Boss _boss;

    public IntroState(Boss boss) : base(boss.gameObject)
    {
        this._boss = boss;
    }

    public override BossState Tick()
    {
        Debug.Log("Tick");
        transform.position = Vector2.MoveTowards(transform.position, _boss.StartPosition, Time.deltaTime * _boss.Speed);
        if (transform.position == _boss.StartPosition)
        {
            return BossState.SingleAttack;
        }
        return BossState.Intro;
    }
}
