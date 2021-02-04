using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float _speed = 8f;
    [SerializeField] private float _damage;

    public float Damage { get { return _damage; } private set { _damage = value; } }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.up * _speed * Time.fixedDeltaTime);
    }

    private void OnBecameInvisible()
    {
        if(transform.parent != null)
        {
            Destroy(transform.parent.gameObject);
        }
        Destroy(gameObject);
    }
}
