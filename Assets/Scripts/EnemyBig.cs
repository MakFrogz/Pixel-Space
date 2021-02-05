using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBig : Enemy, IAttack
{
    private float _nextFire;
    private GameObject _player;

    new void Start()
    {
        base.Start();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        Move();
        Attack();
    }

    protected override void Move()
    {
        transform.Translate(Vector3.down * _enemyScriptableObject.EnemySpeed * Time.fixedDeltaTime);
    }

    public void Attack()
    {

        if (!_spriteRenderer.isVisible)
        {
            return;
        }

        if (GameManager.Instance.IsGameOver)
        {
            return;
        }

        if(Time.time > _nextFire)
        {
            _nextFire = Time.time + _enemyScriptableObject.EnemyFireRate;
            Vector3 target = _player == null ? Vector3.down : _player.transform.position;
            Instantiate(_enemyScriptableObject.BulletPrefab, transform.position, Quaternion.LookRotation(Vector3.forward, transform.position - target));
        }
    }
}
