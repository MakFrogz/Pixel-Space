using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMedium : Enemy, IAttack
{
    [SerializeField] private Transform _firePoint;
    public Transform FirePoint { get { return _firePoint; } set { _firePoint = value; } }

    private float _nextFire;
    private Vector3 _direction;


    new void Start()
    {

        base.Start();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _direction = player.transform.position - transform.position;
    }

    private void FixedUpdate()
    {
        Move();
        Attack();
    }

    protected override void Move()
    {
        transform.Translate(_direction.normalized * _enemyScriptableObject.Speed * Time.fixedDeltaTime);
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
            _nextFire = Time.time + _enemyScriptableObject.FireRate;
            Instantiate(_enemyScriptableObject.BulletPrefab, FirePoint.position, Quaternion.identity);
        }
    }
}
