using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBig : Enemy, IAttack
{
    [SerializeField] private Transform _firePoint;
    public Transform FirePoint { get { return _firePoint; } set { _firePoint = value; } }

    private GameObject _player;

    private float _nextFire;

    private new void Start()
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
        transform.Translate(Vector3.down * _speed * Time.fixedDeltaTime);
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
            AudioManager.Instance.PlaySFX(_enemyScriptableObject.ShotSound);
            _nextFire = Time.time + _fireRate;
            Vector3 target = _player == null ? Vector3.down : _player.transform.position;
            Instantiate(_enemyScriptableObject.BulletPrefab, FirePoint.position, Quaternion.LookRotation(Vector3.forward, transform.position - target));
        }
    }
}
