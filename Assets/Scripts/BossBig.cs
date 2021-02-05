using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBig : Boss, IAttack
{
    [SerializeField] private int _projectilesNum;
    [SerializeField] private float _massiveAttackCoolDown;
    [SerializeField] private float _laserAttackCoolDown;
    [SerializeField] private GameObject _laser;

    private float _nextFire;
    private GameObject[] _players;

    private float xBounds;
    private int direction;

    private bool _canMassiveAttack;
    private bool _canLaserAttack;
    private bool _canSingleAttack;

    new void Start()
    {
        base.Start();
        _laser.SetActive(false);
        _players = GameObject.FindGameObjectsWithTag("Player");
        //xBounds = Background.Instance.GetBackgroundWidth() - (GetComponent<SpriteRenderer>().bounds.size.x / 2);
        xBounds = Background.Instance.GetBackgroundWidth();
        direction = 1;
        /*_canSingleAttack = true;
        _canMassiveAttack = false;
        _canLaserAttack = false;
        StartCoroutine("MassiveAttackCoolDown");
        StartCoroutine("LaserAttackCoolDown");*/
        StartCoroutine("AttacksRoutine");
    }

    void Update()
    {
        MovementDirection();
    }

    void FixedUpdate()
    {
        MoveToStartPosition();
        if (!_canMove)
        {
            return;
        }
        Move();
        Attack();
        MassiveAttack();
        LaserAttack();
    }

    private void MovementDirection()
    {
        if(transform.position.x > xBounds)
        {
            direction = -1;
        }else if (transform.position.x < -xBounds)
        {
            direction = 1;
        }
    }

    protected override void Move()
    {

        transform.Translate(Vector3.right * _speed * Time.fixedDeltaTime * direction);
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
            _nextFire = Time.time + _fireRate;
            int playerIndex = 0;
            if (_players.Length > 1)
            {
                playerIndex = Random.Range(0, _players.Length);
            }
            Vector3 target = _players[playerIndex] == null ? Vector3.down : _players[playerIndex].transform.position;
            Instantiate(_bulletPrefab, transform.position, Quaternion.LookRotation(Vector3.forward, transform.position - target));
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
                Instantiate(_bulletPrefab, transform.position, Quaternion.Euler(new Vector3(0f, 0f, step * i)));
            }
        }
        yield return new WaitForSeconds(1f);
        _speed = 5f;
        _canSingleAttack = true;
        //StartCoroutine("MassiveAttackCoolDown");
    }

    /*private IEnumerator MassiveAttackCoolDown()
    {
        yield return new WaitForSeconds(_massiveAttackCoolDown);
        _canMassiveAttack = true;
    }*/

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
        yield return new WaitForSeconds(3f);
        _laser.GetComponent<Animator>().SetBool("Attack", false);
        _laser.SetActive(false);
        _canSingleAttack = true;
        _speed /= 2f;
        //StartCoroutine("LaserAttackCoolDown");
    }

   /* private IEnumerator LaserAttackCoolDown()
    {
        yield return new WaitForSeconds(_laserAttackCoolDown);
        _canLaserAttack = true;
    }*/


    private IEnumerator AttacksRoutine()
    {
        while (_isAlive)
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
