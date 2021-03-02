using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    [SerializeField] private Camera _camera;
    public static Background Instance { get; set; }

    private Vector2 _fieldSize; // 1/2 height and 1/2 width in units
    int _pixelPerUnit;
    private float _heigth;
    private float _width;

    private void Awake()
    {
        Instance = this;
        _pixelPerUnit = 100;
        _fieldSize = new Vector2((float)Screen.width/_pixelPerUnit, (float)Screen.height/_pixelPerUnit);
        _heigth = _fieldSize.y;
        _width = _fieldSize.x;
    }

    private void Start()
    {
        _camera.orthographicSize = (float)Screen.height / _pixelPerUnit;
    }

    public float GetBackgroundHeigth()
    {
        return _heigth;
    }

    public float GetBackgroundWidth()
    {
        return _width;
    }
}
