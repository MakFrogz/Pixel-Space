using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpProjectile : PowerUp
{
    protected override void ActiveBoost(Collider2D other)
    {
        PlayerShootController playerShootController = other.GetComponent<PlayerShootController>();
        if(playerShootController != null)
        {
            playerShootController.IncreaseProjectile();
        }
    }
}
