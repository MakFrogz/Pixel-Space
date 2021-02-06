using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttack
{
    Transform FirePoint { get; set; }
    void Attack();
}
