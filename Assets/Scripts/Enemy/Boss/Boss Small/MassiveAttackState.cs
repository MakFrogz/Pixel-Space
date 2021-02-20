using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BossSmallNameSpace
{
    public class MassiveAttackState : BaseState
    {
        private readonly Boss _boss;
        private BossState _nextState;

        private float _nextStateTime;
        private float _nextFire;

        public MassiveAttackState(Boss boss) : base(boss.gameObject)
        {
            this._boss = boss;
        }

        public override void Enter()
        {
            _nextStateTime = 5f;
            _nextState = BossState.MassiveAttack;
            _boss.Speed *= 3f;
        }

        public override BossState Tick()
        {
            _nextStateTime -= Time.deltaTime;
            if (_nextStateTime <= 0)
            {
                return BossState.SingleAttack;
            }

            _boss.MovementDirection();
            _boss.Move();
            if (Time.time > _nextFire)
            {
                AudioManager.Instance.PlaySFX(_boss.BossScriptableObject.ShotSound);
                _nextFire = Time.time + _boss.BossScriptableObject.FireRate / 3f;
                Object.Instantiate(_boss.BossScriptableObject.BulletPrefab, _boss.FirePoint.position, Quaternion.identity);
            }
            return _nextState;
        }

        public override void Exit()
        {
            _boss.Speed /= 3f;
        }
    }
}
