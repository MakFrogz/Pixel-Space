using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShield : PowerUp
{
    protected override void ActiveBoost(Collider2D other)
    {
        PlayerHealthController playerHealthController = other.GetComponent<PlayerHealthController>();
        if(playerHealthController != null)
        {
            playerHealthController.ActivateShield();
        }
    }
}
