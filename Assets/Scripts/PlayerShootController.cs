using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController : MonoBehaviour
{
    [SerializeField] private PlayerScriptableObject _playerScriptableObject;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private AudioClip _fireSound;
    [SerializeField] private int _numProjectile;
    [SerializeField] private float _angleStep;

    private float _fireRate;
    private float _nextFire;

    void Start()
    {
        _fireRate = _playerScriptableObject.FireRate;
        _numProjectile = 1;
    }


    public void OnAttack()
    {
        if (Time.time > _nextFire)
        {
            FireLaser();
        }
    }

    private void FireLaser()
    {
        _nextFire = Time.time + _fireRate;
        bool s = _numProjectile % 2 == 0;
        int d = _numProjectile % 2;
        for (int i = -(_numProjectile - d) / 2; i <= (_numProjectile - d) / 2; i++)
        {
            if (s && i == 0)
            {
                continue;
            }
            Quaternion target = Quaternion.AngleAxis(i * _angleStep, transform.forward);
            Instantiate(_bulletPrefab, _firePoint.position , target);
        }
        AudioManager.Instance.PlaySFX(_fireSound);
    }

    public void AddProjectile()
    {
        if(_numProjectile <= _playerScriptableObject.MaxProjectiles)
        {
            _numProjectile++;
        }
    }

    public void AddFireRate(float fireRateUp)
    {
        if (_fireRate > _playerScriptableObject.MaxFireRate)
        {
            _fireRate -= fireRateUp;
        }
    }
}
