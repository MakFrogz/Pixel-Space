using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BossBigNameSpace
{
    public class SingleAttackState : BaseState
    {
        private readonly Boss _boss;

        private float _nextFire;
        private float _nextStateTime;
        private GameObject _player;
        public SingleAttackState(Boss boss) : base(boss.gameObject)
        {
            this._boss = boss;
        }

        public override void Enter()
        {
            _nextStateTime = UnityEngine.Random.Range(10f, 15f);
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        public override BossState Tick()
        {
            _nextStateTime -= Time.deltaTime;
            if (_nextStateTime <= 0)
            {
                return BossState.MassiveAttack;
            }

            _boss.MovementDirection();
            _boss.Move();

            if (Time.time > _nextFire)
            {
                AudioManager.Instance.PlaySFX(_boss.BossScriptableObject.ShotSound);
                _nextFire = Time.time + _boss.BossScriptableObject.FireRate;
                Vector3 target = _player == null ? Vector3.down : _player.transform.position;
                UnityEngine.Object.Instantiate(_boss.BossScriptableObject.BulletPrefab, _boss.FirePoint.position, Quaternion.LookRotation(Vector3.forward, transform.position - target));
            }
            return BossState.SingleAttack;
        }
    }
}
