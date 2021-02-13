using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmall : Enemy
{
    [SerializeField] private GameObject _minePrefab;
    [Range(0, 100)]
    [SerializeField] private float _chanceToDropMine;
    private void FixedUpdate()
    {
        Move();
    }

    protected override void Move()
    {
        transform.Translate(Vector3.down * _enemyScriptableObject.Speed * Time.fixedDeltaTime);
    }

    protected override void OnDrop()
    {
        float chance = Random.Range(0f, 100f);
        if (chance < _enemyScriptableObject.PowerUpDropChance)
        {
            Instantiate(GetRandomPowerUp(), transform.position, Quaternion.identity);
        }
        else if (chance < _chanceToDropMine)
        {
            Instantiate(_minePrefab, transform.position, Quaternion.identity);
        }
    }

}
