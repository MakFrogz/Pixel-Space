using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEnergy : PowerUp
{
    [SerializeField] private float _energyUpValue;

    protected override void ActiveBoost(Collider2D other)
    {
        PlayerEnergyController playerEnergyController = other.GetComponent<PlayerEnergyController>();
        if(playerEnergyController != null)
        {
            playerEnergyController.IncreaseMaxEnergy(_energyUpValue);
        }
    }
}
