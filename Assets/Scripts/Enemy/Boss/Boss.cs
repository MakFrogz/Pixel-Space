using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss : EnemyBase
{
    [SerializeField] private BossScriptableObject _bossScriptableObject;
    [SerializeField] private Transform _firePoint;

    private float _currentHealth;
    protected float _speed;

    private Vector3 _startPosition;
    protected Vector3 _direction;
    protected float _boundX;

    public BossScriptableObject BossScriptableObject => _bossScriptableObject;
    public Vector3 StartPosition => _startPosition;
    public Transform FirePoint => _firePoint;
    public Vector3 Direction { get; private set; }
    public float BoundX => _boundX;
    public float Speed { get; set; }

    protected new void Awake()
    {
        base.Awake();
        _currentHealth = _bossScriptableObject.Health * GameManager.Instance.MultiplierHealth;
        Direction = Vector3.left;
        Speed = _bossScriptableObject.Speed;
    }

    protected void Start()
    {
        _boundX = Background.Instance.GetBackgroundWidth();
        float y = Background.Instance.GetBackgroundHeigth() - (GetComponent<SpriteRenderer>().bounds.size.y / 2);
        _startPosition = new Vector3(0f, y, 0f);
    }

    protected override void OnCollision(Collider2D other)
    {
        PlayerHealthController playerHealthController = other.GetComponent<PlayerHealthController>();
        if(playerHealthController != null)
        {
            playerHealthController.OnDeath();
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
                GameManager.Instance.AddScore(_bossScriptableObject.PointReward);
                OnDrop();
                OnDeath();
            }
        }
    }

    protected override void OnDeath()
    {
        GameManager.Instance.OnBossDeath();
        _isDeath = true;
        Instantiate(_bossScriptableObject.ExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    protected override void OnDrop()
    {
        for(int i = 0; i < _bossScriptableObject.DropAmount; i++)
        {
            Vector2 position = new Vector2(transform.position.x + Random.Range(-2f,2f), transform.position.y + Random.Range(-2f, 2f));
            Instantiate(GetRandomPowerUp(_bossScriptableObject.PowerUpPrefabs), position, Quaternion.identity);
        }
    }

    public void BossStartCoroutine(IEnumerator enumerator)
    {
        StartCoroutine(enumerator);
    }

    public void MovementDirection()
    {
        if (transform.position.x > BoundX)
        {
            Direction = Vector3.left;
        }
        else if (transform.position.x < -BoundX)
        {
            Direction = Vector3.right;
        }
    }

    public void Move()
    {
        transform.Translate(Speed * Time.deltaTime * Direction);
    }
}
