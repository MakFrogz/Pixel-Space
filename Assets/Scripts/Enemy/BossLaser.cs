using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _delayBetweenAttack;

    private Player _player;
    
    private bool _canAttack;
    private float _nextAttackTime;
    void Start()
    {
        _canAttack = false;
    }

    
    void Update()
    {
        if (_canAttack && Time.time >= _nextAttackTime)
        {
            _nextAttackTime = Time.time + _delayBetweenAttack;
            if (_player != null)
            {
                _player.GetComponent<PlayerHealthController>().ApplyDamage(_damage);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _canAttack = true;
            _player = other.GetComponent<Player>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _canAttack = false;
        }
    }
}
