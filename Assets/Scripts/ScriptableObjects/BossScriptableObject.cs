using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New boss data", menuName = "Boss/Create new boss data")]
public class BossScriptableObject : ScriptableObject
{
    public float Speed;
    public float FireRate;
    public float Health;
    public int PointReward;
    public GameObject ExplosionPrefab;
    public GameObject BulletPrefab;
    public AudioClip ShotSound;
    public GameObject[] PowerUpPrefabs;
    public int DropAmount;
}
