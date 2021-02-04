using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Vector3 _offsetFirePoint;
    [SerializeField] private AudioClip _fireSound;
    [SerializeField] private int _numProjectile;
    [SerializeField] private float _angleStep;

    private float _fireRate;
    private float _nextFire;

    public float FireRate { get { return _fireRate; } set { _fireRate = value; } }
    void Start()
    {
        
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
            Instantiate(_bulletPrefab, transform.position + _offsetFirePoint, target);
        }
        AudioManager.Instance.PlaySFX(_fireSound);
    }

    public void AddProjectile()
    {
        _numProjectile++;
    }

    public void AddFireRate()
    {
        if (_fireRate > 0.2f)
        {
            _fireRate -= 0.05f;
        }
    }
}
