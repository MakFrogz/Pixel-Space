using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleAttackState : BaseState
{
    Boss _boss;

    private float _nextFire;
    private float _nextStateTime;
    public SingleAttackState(Boss boss) : base(boss.gameObject)
    {
        this._boss = boss;
    }

    public override void Enter()
    {
        _nextStateTime = UnityEngine.Random.Range(10f,15f);
    }

    public override Type Tick()
    {
        _nextStateTime -= Time.deltaTime;
        if (_nextStateTime <= 0)
        {
            return typeof(MassiveAttackState);
        }
        MovementDirection();
        Move();
        if (GameManager.Instance.IsGameOver)
        {
            return null;
        }

        if (Time.time > _nextFire)
        {
            AudioManager.Instance.PlaySFX(_boss.ShotSound);
            _nextFire = Time.time + _boss.EnemyScriptableObject.FireRate;
            Vector3 target = _boss.Player == null ? Vector3.down : _boss.Player.transform.position;
            UnityEngine.Object.Instantiate(_boss.EnemyScriptableObject.BulletPrefab, _boss.FirePoint.position, Quaternion.LookRotation(Vector3.forward, transform.position - target));
        }
        return null;
    }

    private void MovementDirection()
    {
        if (transform.position.x > _boss.BoundX)
        {
            _boss.Direction = Vector3.left;
        }
        else if (transform.position.x < -_boss.BoundX)
        {
            _boss.Direction = Vector3.right;
        }
        Debug.Log(_boss.Direction);
    }

    private void Move()
    {
        transform.Translate(_boss.Speed * Time.deltaTime * _boss.Direction);
    }

}
