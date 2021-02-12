using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEnergyRecovery : PowerUp
{
    [SerializeField] private float _energyRecoveryTimeDecreaseValue;

    protected override void ActiveBoost(Collider2D other)
    {
        PlayerEnergyController playerEnergyController = other.GetComponent<PlayerEnergyController>();
        if(playerEnergyController != null)
        {
            playerEnergyController.DecreaseEnergyRecoveryTime(_energyRecoveryTimeDecreaseValue);
        }
    }
}
