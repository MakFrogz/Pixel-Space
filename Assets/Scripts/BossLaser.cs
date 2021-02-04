using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    [SerializeField] private float _damage;

    private bool _canAttack;
    private Player _player;
    void Start()
    {
        _canAttack = false;
    }

    
    void Update()
    {
        if (_canAttack)
        {
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
