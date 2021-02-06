using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Boost Data", menuName = "Boost/Create new boost data")]
public class BoostScriptableObject : ScriptableObject
{
    public float HealthUp;
    public float Heal;
    public float EnergyUp;
    public float EnergyRestoreTimeUp;
    public float SpeedUp;
    public float FireRateUp;
}
