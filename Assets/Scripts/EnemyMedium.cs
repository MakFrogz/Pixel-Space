using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMedium : Enemy, IAttack
{
    [SerializeField] private Transform _firePoint;

    private float _nextFire;
    private Vector3 _direction;
    new void Start()
    {

        base.Start();
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        int playerIndex = 0;
        if(players.Length > 1)
        {
            playerIndex = Random.Range(0, players.Length);
        }
        _direction = players[playerIndex].transform.position - transform.position;
    }

    private void FixedUpdate()
    {
        Move();
        Attack();
    }

    protected override void Move()
    {
        transform.Translate(_direction.normalized * _enemyScriptableObject.EnemySpeed * Time.fixedDeltaTime);
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

        if (Time.time > _nextFire)
        {
            _nextFire = Time.time + _enemyScriptableObject.EnemyFireRate;
            Instantiate(_enemyScriptableObject.BulletPrefab, _firePoint.position, Quaternion.identity);
        }
    }
}
