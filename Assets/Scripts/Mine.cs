﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    [SerializeField] private float _radius;
    [SerializeField] private float _timeExplosion;
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private AudioClip _mineSound;
    [SerializeField] private LayerMask _layerMask;

    private Animator _animator;

    private float _timer;
    private bool _isTimer;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _isTimer = false;
        _timer = _timeExplosion;
    }

    // Update is called once per frame
    void Update()
    {
       if (!_isTimer)
       {
            bool isDetectPlayer =  Physics2D.OverlapCircle(transform.position, _radius, _layerMask);
            if (isDetectPlayer)
            {
                Debug.Log("Player was detected! Timer was activeted");
                _animator.speed = 3;
                _isTimer = true;
                StartCoroutine(TimerActive());
            }
       }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * _speed * Time.fixedDeltaTime);
    }

    private IEnumerator TimerActive()
    {
        yield return new WaitForSeconds(_timer);
        OnExplosion();
    }

    private void OnExplosion()
    {
        Collider2D other = Physics2D.OverlapCircle(transform.position, _radius, _layerMask);
        if(other != null)
        {
            ApplyDamage(other);
        }
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Player"))
        {
            ApplyDamage(other);
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void ApplyDamage(Collider2D other)
    {
        PlayerHealthController playerHealth = other.GetComponent<PlayerHealthController>();
        if (playerHealth != null)
        {
            playerHealth.ApplyDamage(_damage);
        }

    }


    private void Beep()
    {
        AudioManager.Instance.PlaySFX(_mineSound);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
