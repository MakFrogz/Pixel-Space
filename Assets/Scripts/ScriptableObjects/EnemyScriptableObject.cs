﻿using System.Collections;
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
    public AudioClip ShotSound;
    public GameObject BulletPrefab;
    public GameObject ExplosionPrefab;
    public GameObject[] PowerUpPrefabs;
    [Range(0,100)]
    public float PowerUpDropChance;
}
