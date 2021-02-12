using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New boss data", menuName = "Boss/Create new boss data")]
public class BossScriptableObject : ScriptableObject
{
    public float Damage;
    public float Speed;
    public float FireRate;
    public float Health;
    public GameObject ExplosionPrefab;
    public GameObject BulletPrefab;
    public GameObject[] PowerUpPrefabs;
}
