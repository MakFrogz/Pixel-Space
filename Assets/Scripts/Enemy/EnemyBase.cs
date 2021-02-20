using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    protected bool _isDeath;
    protected void Awake()
    {
        _isDeath = false;
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (_isDeath)
        {
            Destroy(other.gameObject);
            return;
        }

        if (other.tag == "Player")
        {
            OnCollision(other);
        }
    }

    protected abstract void OnCollision(Collider2D other);

    public abstract void ApplyDamage(float damage);


    protected abstract void OnDeath();

    protected abstract void OnDrop();

    protected GameObject GetRandomPowerUp(GameObject[] powerUpPrefabs)
    {
        int powerUpIndex = Random.Range(0, powerUpPrefabs.Length);
        return powerUpPrefabs[powerUpIndex];
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
