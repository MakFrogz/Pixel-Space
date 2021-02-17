using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] protected EnemyScriptableObject _enemyScriptableObject;

    public EnemyScriptableObject EnemyScriptableObject => _enemyScriptableObject;

    protected float _currentHealth;
    protected bool _isDeath;

    protected void Awake()
    {
        _currentHealth = _enemyScriptableObject.Health;
        _isDeath = false;
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (_isDeath)
        {
            Destroy(other.gameObject);
            return;
        }

        if (other.tag == "Player")
        {
            OnCollision(other);
        }
    }

    protected virtual void OnCollision (Collider2D other)
    {
        PlayerHealthController playerHealthController = other.GetComponent<PlayerHealthController>();
        if (playerHealthController != null)
        {
            playerHealthController.ApplyDamage(_enemyScriptableObject.CollisionDamage);
            OnDeath();
        }
    }

    public void ApplyDamage(float damage)
    {
        if (_isDeath)
        {
            return;
        }
        _currentHealth -= damage;
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
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
