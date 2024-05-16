using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletMainManger : MonoBehaviour
{
    public static BulletMainManger Instance;

    public BulletSpawner _bulletSpawner;

    private List<BulletBlueprint> _activeBulletList = new List<BulletBlueprint>();

    private BulletBlueprint _bullet;



    public void Init()
    { 
       _bulletSpawner = transform.GetChild(0).GetComponent<BulletSpawner>();

        // _bullet = _bulletSpawner.SpawnBullet(BulletSpawner.BulletType.NoramlBullet)

        _activeBulletList = new List<BulletBlueprint> ();

        Instance = this;
    }

    public void SpawnBulletRequest(BulletContiner continer)
    {
        BulletBlueprint temp = _bulletSpawner.SpawnBullet(continer);

        _activeBulletList.Add(temp);
    }

    public void UpdateScript()
    {
        int count = _activeBulletList.Count;

        for (int i = count -1; i >= 0; i--) 
        {
            _activeBulletList[i].UpdateScript();
        }
    }
}
