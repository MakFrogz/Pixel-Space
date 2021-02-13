using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    protected override void OnCollision(Collider2D other)
    {
        if (other.CompareTag(_bulletScriptableObject.TagString))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.ApplyDamage(_bulletScriptableObject.Damage);
            }
            OnExplosion(other);
        }
    }
}
