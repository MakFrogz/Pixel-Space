using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Bullet Data", menuName ="Bullet/Create bullet")]
public class BulletScriptableObject : ScriptableObject
{
    public string TagString;
    public float Speed;
    public float Damage;
    public Direction Direction;
    public GameObject ExplosionPrefab;
    
}

public enum Direction
{
    Down = -1,
    Up = 1
}


