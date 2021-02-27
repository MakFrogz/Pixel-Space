using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : EnemyBase
{
    [SerializeField] protected EnemyScriptableObject _enemyScriptableObject;

    protected SpriteRenderer _spriteRenderer;

    protected float _currentHealth;
    protected float _speed;
    protected float _fireRate;

    protected float _boundY;
    private new void Awake()
    {
        base.Awake();
        _currentHealth = _enemyScriptableObject.Health * GameManager.Instance.Multiplier;
        _speed = _enemyScriptableObject.Speed * GameManager.Instance.Multiplier;
        _fireRate = _enemyScriptableObject.FireRate / GameManager.Instance.Multiplier;
    }

    protected void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        float x = Background.Instance.GetBackgroundWidth() - (_spriteRenderer.bounds.size.x / 2);
        float y = Background.Instance.GetBackgroundHeigth() + (_spriteRenderer.bounds.size.y / 2) - 0.1f;
        _boundY = y;
        transform.position = new Vector2(Random.Range(-x, x), y);
    }

    protected abstract void Move();


    protected override void OnCollision(Collider2D other)
    {
        PlayerHealthController playerHealthController = other.GetComponent<PlayerHealthController>();
        if (playerHealthController != null)
        {
            playerHealthController.ApplyDamage(_enemyScriptableObject.CollisionDamage);
            OnDeath();
        }
    }

    public override void ApplyDamage(float damage)
    {
        if (_isDeath)
        {
            return;
        }
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(Mathf.RoundToInt(_enemyScriptableObject.PointReward * GameManager.Instance.Multiplier));
                OnDrop();
                OnDeath();
            }
        }
    }
    protected override void OnDeath()
    {
        GameManager.Instance.DestroyedEnemiesCount++;
        _isDeath = true;
        Instantiate(_enemyScriptableObject.ExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    protected override void OnDrop()
    {
        float chance = Random.Range(0f, 100f);
        if (chance < _enemyScriptableObject.PowerUpDropChance)
        {
            Instantiate(GetRandomPowerUp(_enemyScriptableObject.PowerUpPrefabs), transform.position, Quaternion.identity);
        }
    }
}
