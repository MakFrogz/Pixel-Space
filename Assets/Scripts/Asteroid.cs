using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private GameObject _explosion;

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        _speed = Random.Range(3f,10f);
        float x = Background.Instance.GetBackgroundWidth() - (spriteRenderer.bounds.size.x / 2);
        float y = Background.Instance.GetBackgroundHeigth() + (spriteRenderer.bounds.size.y / 2);
        transform.position = new Vector3(Random.Range(-x, x), y, 0f);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.down * _speed * Time.fixedDeltaTime);
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if(other.tag == "Player")
        {
            PlayerHealthController playerHealthController = other.GetComponent<PlayerHealthController>();
            if(playerHealthController != null)
            {
                playerHealthController.ApplyDamage(80f);
            }
        }

        if(other.tag == "PlayerBullet")
        {
            GameObject explosion = Instantiate(_explosion, other.transform.position, Quaternion.identity);
            explosion.transform.SetParent(transform);
            explosion.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            Destroy(other.gameObject);
        }

    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
