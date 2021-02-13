using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBig : Boss, IAttack
{
    [SerializeField] private int _projectilesNum;
    [SerializeField] private GameObject _laser;
    [SerializeField] private Transform _firePoint;
    public Transform FirePoint { get { return _firePoint; } set { _firePoint = value; } }

    private GameObject _player;
    
    private float _nextFire;
    private float _xBounds;
    private int _direction;
    private float _speed;

    private bool _canMassiveAttack;
    private bool _canLaserAttack;
    private bool _canSingleAttack;


    private new void Awake()
    {
        base.Awake();
        _direction = 1;
        _speed = _enemyScriptableObject.Speed;
    }

    private void Start()
    {
        _laser.SetActive(false);
        _player = GameObject.FindGameObjectWithTag("Player");
        _xBounds = Background.Instance.GetBackgroundWidth();
        StartCoroutine("AttacksRoutine");
    }

    void Update()
    {
        MovementDirection();
    }

    void FixedUpdate()
    {
        if (!_canMove)
        {
            IntroMove();
            return;
        }
        Move();
        Attack();
        MassiveAttack();
        LaserAttack();
    }

    private void MovementDirection()
    {
        if(transform.position.x > _xBounds)
        {
            _direction = -1;
        }else if (transform.position.x < -_xBounds)
        {
            _direction = 1;
        }
    }

    protected override void Move()
    {

        transform.Translate(Vector3.right * _speed * Time.fixedDeltaTime * _direction);
    }

    public void Attack()
    {
        if (GameManager.Instance.IsGameOver)
        {
            return;
        }

        if (!_canSingleAttack)
        {
            return;
        }

        if (Time.time > _nextFire)
        {
            _nextFire = Time.time + _enemyScriptableObject.FireRate;
            Vector3 target = _player == null ? Vector3.down : _player.transform.position;
            Instantiate(_enemyScriptableObject.BulletPrefab, FirePoint.position, Quaternion.LookRotation(Vector3.forward, transform.position - target));
        }
    }

    public void MassiveAttack()
    {
        if (!_canMassiveAttack)
        {
            return;
        }
        StartCoroutine("MassiveAttackRoutine");
    }

    private IEnumerator MassiveAttackRoutine()
    {
        _speed = 0;
        _canMassiveAttack = false;
        yield return new WaitForSeconds(1f);
        float step = 360f / _projectilesNum;
        for(int j = 0; j < 3; j++)
        {
            yield return new WaitForSeconds(0.5f);
            for (int i = 0; i < _projectilesNum; i++)
            {
                Instantiate(_enemyScriptableObject.BulletPrefab, transform.position, Quaternion.Euler(new Vector3(0f, 0f, step * i)));
            }
        }
        yield return new WaitForSeconds(1f);
        _speed = 5f;
        _canSingleAttack = true;
    }

    private void LaserAttack()
    {
        if (!_canLaserAttack)
        {
            return;
        }
        _canLaserAttack = false;
        _laser.SetActive(true);
        StartCoroutine("LaserAttackRoutine");
    }

    private IEnumerator LaserAttackRoutine()
    {
        yield return new WaitForSeconds(1f);
        _laser.GetComponent<Animator>().SetBool("Attack", true);
        _speed *= 2f;
        yield return new WaitForSeconds(2f);
        _laser.GetComponent<Animator>().SetBool("Attack", false);
        _laser.SetActive(false);
        _canSingleAttack = true;
        _speed /= 2f;
    }

    private IEnumerator AttacksRoutine()
    {
        while (!_isDeath)
        {
            _canSingleAttack = true;
            yield return new WaitForSeconds(10f);
            _canSingleAttack = false;
            _canMassiveAttack = true;
            yield return new WaitForSeconds(10f);
            _canSingleAttack = false;
            _canLaserAttack = true;
        }
    }
}
