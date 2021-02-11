using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHeal : PowerUp
{
    [SerializeField] private float _healValue;


    protected override void ActiveBoost(Collider2D other)
    {
        PlayerHealthController playerHealthController = other.GetComponent<PlayerHealthController>();
        if(playerHealthController != null)
        {
            playerHealthController.ActivateHeal(_healValue);
        }
    }
}
