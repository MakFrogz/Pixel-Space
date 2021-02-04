using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _length;

    private void Start()
    {
        _length = GetComponent<SpriteRenderer>().bounds.size.y;
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * _speed * Time.fixedDeltaTime);

        if (transform.position.y <= -_length)
        {
            transform.position = new Vector3(transform.position.x, _length, 0f);
        }
    }
}
