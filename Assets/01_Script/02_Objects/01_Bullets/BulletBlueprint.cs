using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBlueprint
{
    protected float _speed = 5.0f;
    protected int _damage = 0;
    

    public abstract void Initialization(float speed, int damage);

    public abstract Vector3 UpdateScript(Vector3 currentPosition);
        
}


