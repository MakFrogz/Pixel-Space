using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] protected BulletScriptableObject _bulletScriptableObject;

    private Vector3 _direction;
    private void Start()
    {
        _direction = new Vector3(0, (float)_bulletScriptableObject.Direction, 0f);
    }
    private void FixedUpdate()
    {
        transform.Translate(_direction * _bulletScriptableObject.Speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(_bulletScriptableObject.TagString))
        {
            OnCollision(other);
        }
    }
    protected abstract void OnCollision(Collider2D other);

    protected void OnExplosion(Collider2D other)
    {
        GameObject explosion = Instantiate(_bulletScriptableObject.ExplosionPrefab, transform.position, Quaternion.identity);
        explosion.transform.SetParent(other.transform);
        explosion.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        Destroy(gameObject);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
