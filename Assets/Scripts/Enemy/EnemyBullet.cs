using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    [SerializeField] private GameObject _explosionPrefab;
    private float yBound, xBound;

    private void Start()
    {
        yBound = Background.Instance.GetBackgroundHeigth();
        xBound = Background.Instance.GetBackgroundWidth();
    }

    private void Update()
    {
        /*if(transform.position.y < -yBound || transform.position.y > yBound || transform.position.x < -xBound || transform.position.x > xBound)
        {
            Destroy(gameObject);
        }*/
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * _speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealthController playerHealthController = other.GetComponent<PlayerHealthController>();
            if (playerHealthController != null)
            {
                playerHealthController.ApplyDamage(_damage);
            }
            Instantiate(_explosionPrefab, other.transform.position, Quaternion.identity).transform.localScale = new Vector3(0.2f,0.2f,0.2f);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
