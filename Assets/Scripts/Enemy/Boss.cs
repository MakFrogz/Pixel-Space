using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss : EnemyBase
{
    [SerializeField] protected Vector3 _startPosition;
    [SerializeField] protected int _dropAmount;
  
    protected bool _canMove;
    protected new void Awake()
    {
        base.Awake();
        _canMove = false;
    }

    protected void IntroMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, _startPosition, Time.deltaTime * _enemyScriptableObject.Speed);
        if (transform.position == _startPosition)
        {
            _canMove = true;
        }
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

}
