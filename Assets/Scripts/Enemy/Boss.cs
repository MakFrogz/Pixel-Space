using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss : EnemyBase
{
    [SerializeField] protected Vector3 _startPosition;
  
    protected bool _canMove;
    protected new void Awake()
    {
        base.Awake();
        _canMove = false;
    }

    protected void IntroMove()
    {
        /*if (_canMove)
        {
            return;
        }*/
        transform.position = Vector2.MoveTowards(transform.position, _startPosition, Time.deltaTime * _enemyScriptableObject.Speed);
        if (transform.position == _startPosition)
        {
            _canMove = true;
        }
    }


    protected override void OnCollision(Collider2D other)
    {
        Destroy(other.gameObject);
    }

    protected override void OnDeath()
    {
        GameManager.Instance.OnBossDeath();
        base.OnDeath();
    }

    protected override void OnDrop()
    {
        Instantiate(GetRandomPowerUp(), transform.position, Quaternion.identity);
    }

}
