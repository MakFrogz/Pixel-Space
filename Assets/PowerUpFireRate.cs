using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFireRate : PowerUp
{
    [SerializeField] private float _fireRateIncreaseValue;
    protected override void ActiveBoost(Collider2D other)
    {
        PlayerShootController playerShootController = other.GetComponent<PlayerShootController>();
        if(playerShootController != null)
        {
            playerShootController.IncreaseFireRate(_fireRateIncreaseValue);
        }
    }
}
