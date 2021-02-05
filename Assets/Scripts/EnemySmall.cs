using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmall : Enemy
{
    private void FixedUpdate()
    {
        Move();
    }

    protected override void Move()
    {
        transform.Translate(Vector3.down * _enemyScriptableObject.Speed * Time.fixedDeltaTime);
    }

}
