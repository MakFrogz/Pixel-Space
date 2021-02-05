using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy/Create enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    public float Speed;
    public float FireRate;
    public float Health;
    public float CollisionDamage;
    public int PointReward;
    public GameObject BulletPrefab;
    public GameObject ExplosionPrefab;
    [Range(0,100)]
    public float BoostDropChance;
}
