using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public static Background Instance { get; set; }

    private float _heigth;
    private float _width;

    private void Awake()
    {
        Instance = this;
        _heigth = GetComponent<SpriteRenderer>().bounds.size.y; 
        _width = GetComponent<SpriteRenderer>().bounds.size.x; 
    }

    public float GetBackgroundHeigth()
    {
        return _heigth / 2;
    }

    public float GetBackgroundWidth()
    {
        return _width / 2;
    }
}
