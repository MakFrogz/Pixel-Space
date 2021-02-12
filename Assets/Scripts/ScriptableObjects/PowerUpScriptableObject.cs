using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Boost Data", menuName = "Boost/Create new boost data")]
public class PowerUpScriptableObject : ScriptableObject
{
    public float Speed;
    public AudioClip AudioClip;
    public GameObject PopupTextPrefab;
}
