using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBig : Enemy, IAttack
{
    private float _nextFire;
    private GameObject[] _players;

    new void Start()
    {
        base.Start();
        _players = GameObject.FindGameObjectsWithTag("Player");
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

        if (_gameManager.IsGameOver)
        {
            return;
        }

        if(Time.time > _nextFire)
        {
            _nextFire = Time.time + _enemyScriptableObject.EnemyFireRate;
            int playerIndex = 0;
            if(_players.Length > 1)
            {
                playerIndex = Random.Range(0, _players.Length);
            }
            Vector3 target = _players[playerIndex] == null ? Vector3.down : _players[playerIndex].transform.position;
            Instantiate(_enemyScriptableObject.BulletPrefab, transform.position, Quaternion.LookRotation(Vector3.forward, transform.position - target));
        }
    }
}
