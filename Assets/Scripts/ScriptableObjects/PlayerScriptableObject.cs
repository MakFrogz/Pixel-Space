using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Create Player/Player")]
public class PlayerScriptableObject : ScriptableObject
{
    public float PlayerHealth;
    public float PlayerEnergy;
    public float PlayerSpeed;
    public float PlayerFireRate;
    public float DodgeMultiplySpeed;
    public float DodgeCost;
}
