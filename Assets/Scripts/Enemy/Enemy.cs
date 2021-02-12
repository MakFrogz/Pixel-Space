using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected EnemyScriptableObject _enemyScriptableObject;

    protected float _currentHealth;
    protected SpriteRenderer _spriteRenderer;

    private bool _isDeath;
    protected void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _currentHealth = _enemyScriptableObject.Health;
        float x = Background.Instance.GetBackgroundWidth() - (_spriteRenderer.bounds.size.x / 2);
        float y = Background.Instance.GetBackgroundHeigth() + (_spriteRenderer.bounds.size.y * 2);
        transform.position = new Vector2(Random.Range(-x, x), y);
        _isDeath = false;
    }

    protected abstract void Move();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isDeath)
        {
            Destroy(other.gameObject);
            return;
        }

        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.GetComponent<PlayerHealthController>().ApplyDamage(_enemyScriptableObject.CollisionDamage);
                OnDeath();
            }
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

    private void OnDeath()
    {
        _isDeath = true;
        GameManager.Instance.DestroyedEnemiesCount++;
        Instantiate(_enemyScriptableObject.ExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnDrop()
    {
        float chance = Random.Range(0f, 100f);
        if(chance < _enemyScriptableObject.PowerUpDropChance)
        {
            Instantiate(GetRandomPowerUp(), transform.position, Quaternion.identity);
        }
    }

    private GameObject GetRandomPowerUp()
    {
        int powerUpIndex = Random.Range(0, _enemyScriptableObject.PowerUpPrefabs.Length);
        return _enemyScriptableObject.PowerUpPrefabs[powerUpIndex];
    }
}
