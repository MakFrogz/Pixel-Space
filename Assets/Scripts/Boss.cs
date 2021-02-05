using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss : MonoBehaviour
{
    [SerializeField] protected float _damage;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _fireRate;
    [SerializeField] protected float _health;
    [SerializeField] protected GameObject _explosionPrefab;
    [SerializeField] protected GameObject _bulletPrefab;
    [SerializeField] protected Vector3 _startPosition;

    protected bool _isAlive;
    protected bool _canMove;

    protected void Start()
    {
        _isAlive = true;
        _canMove = false;
    }

    protected void MoveToStartPosition()
    {
        if (_canMove)
        {
            return;
        }
        transform.position = Vector2.MoveTowards(transform.position, _startPosition, Time.deltaTime * _speed);
        if(transform.position == _startPosition)
        {
            _canMove = true;
        }
    }

    protected abstract void Move();

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.GetComponent<PlayerHealthController>().ApplyDamage(20);
                OnDeath();
            }
        }

        if (other.tag == "PlayerBullet")
        {
            PlayerBullet playerBullet = other.GetComponent<PlayerBullet>();
            if(playerBullet != null)
            {
                _health -= playerBullet.Damage;
                Destroy(other.gameObject);
                if(_health <= 0)
                {
                    if (GameManager.Instance != null)
                    {
                        GameManager.Instance.AddScore(1000);
                        OnDeath();
                    }
                }
            }
        }
    }
    private void OnDeath()
    {
        _isAlive = false;
        GameManager.Instance.OnBossDeath();
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity).transform.localScale = new Vector3(1.5f,1.5f,1.5f) ;
        Destroy(gameObject);
    }
}
