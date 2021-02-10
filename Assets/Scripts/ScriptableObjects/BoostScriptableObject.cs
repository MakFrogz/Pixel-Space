using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Boost Data", menuName = "Boost/Create new boost data")]
public class BoostScriptableObject : ScriptableObject
{
    public float HealthUp;
    public string HealthUpText;
    public float Heal;
    public string HealText;
    public float EnergyUp;
    public string EnergyUpText;
    public float EnergyRestoreTimeUp;
    public string EnergyRestoreTimeUpText;
    public float SpeedUp;
    public string SpeedUpText;
    public float FireRateUp;
    public string FireRateUpText;

    public string ShieldText;
    public string ProjectileUpText;
}
