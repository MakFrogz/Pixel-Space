using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    protected override void OnCollision(Collider2D other)
    {
        PlayerHealthController playerHealthController = other.GetComponent<PlayerHealthController>();
        if (playerHealthController != null)
        {
            playerHealthController.ApplyDamage(_bulletScriptableObject.Damage);
        }
        OnExplosion(other);
    }
}
