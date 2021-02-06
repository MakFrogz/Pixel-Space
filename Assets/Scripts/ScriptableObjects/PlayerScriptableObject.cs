using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Create Player/Player")]
public class PlayerScriptableObject : ScriptableObject
{
    [Header("Player stats")]
    [Space]
    public float Health;
    public float Energy;
    public float EnergyRestoreTime;
    public float Speed;
    public float FireRate;
    public float DodgeMultiplySpeed;
    public float DodgeCost;

    [Header("Player limits")]
    public float MaxEnergyRestoreTime;
    public float MaxSpeed;
    public float MaxFireRate;
    public int MaxProjectiles;
}
