using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : EnemyBase
{
    protected SpriteRenderer _spriteRenderer;

    protected void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        float x = Background.Instance.GetBackgroundWidth() - (_spriteRenderer.bounds.size.x / 2);
        float y = Background.Instance.GetBackgroundHeigth() + (_spriteRenderer.bounds.size.y * 2);
        transform.position = new Vector2(Random.Range(-x, x), y);
    }

    protected override void OnDeath()
    {
        GameManager.Instance.DestroyedEnemiesCount++;
        base.OnDeath();
    }

    protected override void OnDrop()
    {
        float chance = Random.Range(0f, 100f);
        if (chance < _enemyScriptableObject.PowerUpDropChance)
        {
            Instantiate(GetRandomPowerUp(), transform.position, Quaternion.identity);
        }
    }
}
