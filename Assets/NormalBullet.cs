using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : BulletBlueprint
{
    public override void Init(float speed, int damage)
    {
        _speed = speed;
        _damage = damage;
    }
}
