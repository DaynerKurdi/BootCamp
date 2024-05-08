using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletMainManger : MonoBehaviour
{
    public static BulletMainManger Instance;

    public BulletSpawner _bulletSpawner;

    private BulletBlueprint _bullet;



    public void Init()
    { 
       _bulletSpawner = transform.GetChild(0).GetComponent<BulletSpawner>();

       // _bullet = _bulletSpawner.SpawnBullet(BulletSpawner.BulletType.NoramlBullet)

        Instance = this;
    }

    public void SpawnBulletRequest(BulletContiner continer)
    {
        _bulletSpawner.SpawnBullet(continer);
    }
}
