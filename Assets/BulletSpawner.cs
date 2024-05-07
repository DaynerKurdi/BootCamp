using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public NormalBullet _normalBullet;

    public enum BulletType
    {
        NoramlBullet = 0,
        Missile = 1,
    }

    public BulletBlueprint SpawnBullet (BulletType type)
    {
        BulletBlueprint bullet = null;

        switch (type)
        {
            case BulletType.NoramlBullet:
                {
                    NormalBullet normalBullet = Instantiate(_normalBullet, transform.position, transform.rotation);

                    bullet = normalBullet;
                }
                break;
            default:
                {

                }
                break;
        }


        return bullet;
    }
}
