using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeed : PowerUp
{
    [SerializeField] private float _speedIncreaseValue;

    protected override void ActiveBoost(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if(player != null)
        {
            player.IncreaseSpeed(_speedIncreaseValue);
        }
    }

}
