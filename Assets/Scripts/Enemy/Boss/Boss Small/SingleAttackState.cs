using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BossSmallNameSpace
{
    public class SingleAttackState : BaseState
    {
        private Boss _boss;
        private float _nextFire;
        private float _nextStateTime;
        public SingleAttackState(Boss boss) : base(boss.gameObject)
        {
            this._boss = boss;
        }

        public override void Enter()
        {
            _nextStateTime = Random.Range(10f, 15f);
            _nextFire = Time.time + _boss.BossScriptableObject.FireRate;
        }

        public override BossState Tick()
        {
            _nextStateTime -= Time.deltaTime;
            if(_nextStateTime <= 0)
            {
                return BossState.MassiveAttack;
            }

            _boss.MovementDirection();
            _boss.Move();

            if(Time.time > _nextFire)
            {
                AudioManager.Instance.PlaySFX(_boss.BossScriptableObject.ShotSound);
                _nextFire = Time.time + _boss.BossScriptableObject.FireRate;
                Object.Instantiate(_boss.BossScriptableObject.BulletPrefab, _boss.FirePoint.position, Quaternion.identity);
            }
            return BossState.SingleAttack;
        }
    }
}
