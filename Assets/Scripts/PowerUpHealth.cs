using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHealth : PowerUp
{
    [SerializeField] private float _healthUpValue;

    protected override void ActiveBoost(Collider2D other)
    {
        PlayerHealthController playerHealthController = other.GetComponent<PlayerHealthController>();
        if (playerHealthController != null)
        {
            playerHealthController.IncreaseMaxHealth(_healthUpValue);
        }
    }

}
