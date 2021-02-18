using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss : EnemyBase
{
    [SerializeField] protected Vector3 _startPosition;
    [SerializeField] protected int _dropAmount;
    [SerializeField] private Transform _firePoint;

    protected Vector3 _direction;
    protected GameObject _player;
    protected float _boundX;
    protected float _speed;
    protected AudioClip _shotSound;

    public Vector3 StartPosition => _startPosition;
    public Transform FirePoint => _firePoint;
    public Vector3 Direction { get; set; }
    public GameObject Player => _player;
    public float BoundX => _boundX;
    public float Speed { get; private set; }

    public AudioClip ShotSound { get; private set; }

    protected new void Awake()
    {
        base.Awake();
        Direction = Vector3.left;
        Speed = _enemyScriptableObject.Speed;
        ShotSound = _enemyScriptableObject.ShotSound;
    }

    protected void Start()
    {
        _boundX = Background.Instance.GetBackgroundWidth();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    protected override void OnCollision(Collider2D other)
    {
        PlayerHealthController playerHealthController = other.GetComponent<PlayerHealthController>();
        if(playerHealthController != null)
        {
            playerHealthController.OnDeath();
        }
    }

    protected override void OnDeath()
    {
        GameManager.Instance.OnBossDeath();
        base.OnDeath();
    }

    protected override void OnDrop()
    {
        for(int i = 0; i < _dropAmount; i++)
        {
            Vector2 position = new Vector2(transform.position.x + Random.Range(-2f,2f), transform.position.y + Random.Range(-2f, 2f));
            Instantiate(GetRandomPowerUp(), position, Quaternion.identity);
        }
    }

    public void BossStartCoroutine(IEnumerator enumerator)
    {
        StartCoroutine(enumerator);
    }
}
