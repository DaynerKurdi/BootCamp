using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMainManger : MonoBehaviour
{
    private BulletSpawner _bulletSpawner;

    private BulletBlueprint _bullet;

    public void Init()
    { 
       _bulletSpawner = transform.GetChild(0).GetComponent<BulletSpawner>();

        _bullet = _bulletSpawner.SpawnBullet(BulletSpawner.BulletType.NoramlBullet);
    }
}
