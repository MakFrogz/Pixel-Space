using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Create Player/Player")]
public class PlayerScriptableObject : ScriptableObject
{
    public float Health;
    public float Energy;
    public float EnergyRestoreTime;
    public float Speed;
    public float FireRate;
    public float DodgeMultiplySpeed;
    public float DodgeCost;
}
