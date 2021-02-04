using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected EnemyScriptableObject _enemyScriptableObject;
    [SerializeField] protected GameObject _boostPrefab;

    protected SpriteRenderer _spriteRenderer;
    protected GameManager _gameManager;

    protected void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        float x = Background.Instance.GetBackgroundWidth() - (_spriteRenderer.bounds.size.x / 2);
        float y = Background.Instance.GetBackgroundHeigth() + (_spriteRenderer.bounds.size.y * 2);
        transform.position = new Vector2(Random.Range(-x, x), y);
    }

    protected abstract void Move();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.GetComponent<PlayerHealthController>().ApplyDamage(_enemyScriptableObject.EnemyCollisionDamage);
                OnDeath();
            }
        }

        if (other.tag == "PlayerBullet")
        {
            Destroy(other.gameObject);
            if (_gameManager != null)
            {
                _gameManager.AddScore(_enemyScriptableObject.EnemyPointReward);
                OnDrop();
                OnDeath();
            }
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnDeath()
    {
        Instantiate(_enemyScriptableObject.ExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnDrop()
    {
        float chance = Random.Range(0f, 100f);
        if(chance < _enemyScriptableObject.BoostDropChance)
        {
            Instantiate(_boostPrefab, transform.position, Quaternion.identity);
        }
    }
}
