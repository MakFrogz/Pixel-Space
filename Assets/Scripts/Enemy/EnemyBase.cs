using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] protected EnemyScriptableObject _enemyScriptableObject;

    protected float _currentHealth;
    protected bool _isDeath;

    protected void Awake()
    {
        Debug.Log("Enemy Base Awake");
        _currentHealth = _enemyScriptableObject.Health;
        _isDeath = false;
    }

    protected abstract void Move();

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (_isDeath)
        {
            Destroy(other.gameObject);
            return;
        }

        if (other.tag == "Player")
        {
            OnEnemyCollision(other);
        }

        if (other.tag == "PlayerBullet")
        {
            PlayerBullet playerBullet = other.GetComponent<PlayerBullet>();
            if(playerBullet != null)
            {
                _currentHealth -= playerBullet.Damage;
            }
            Destroy(other.gameObject);

            if(_currentHealth <= 0)
            {
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.AddScore(_enemyScriptableObject.PointReward);
                    OnDrop();
                    OnDeath();
                }
            }
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    protected virtual void OnEnemyCollision (Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.GetComponent<PlayerHealthController>().ApplyDamage(_enemyScriptableObject.CollisionDamage);
            OnDeath();
        }
    }

    protected virtual void OnDeath()
    {
        _isDeath = true;
        Instantiate(_enemyScriptableObject.ExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    protected abstract void OnDrop();

    protected GameObject GetRandomPowerUp()
    {
        int powerUpIndex = Random.Range(0, _enemyScriptableObject.PowerUpPrefabs.Length);
        return _enemyScriptableObject.PowerUpPrefabs[powerUpIndex];
    }
}
