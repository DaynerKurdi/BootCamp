using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalBulletObject : BulletBlueprint
{
    public override void Initialization( float speed, int damage)
    {
        _speed = speed;
        _damage = damage;
    }

    public override Vector3 UpdateScript(Vector3 currentPosition)
    {
        currentPosition.y += _speed * Time.deltaTime;

        return currentPosition;
    }
}
