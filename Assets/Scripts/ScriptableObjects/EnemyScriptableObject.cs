using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy/Create enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    public float EnemySpeed;
    public float EnemyFireRate;
    public float EnemyHealth;
    public float EnemyCollisionDamage;
    public int EnemyPointReward;
    public GameObject BulletPrefab;
    public GameObject ExplosionPrefab;
    [Range(0,100)]
    public float BoostDropChance;
}
