using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public PlayerNormalBullet _normalBullet;

    public enum BulletType
    {
        NoramlBullet = 0,
        Missile = 1,
    }

    public BulletBlueprint SpawnBullet (BulletContiner continer)
    {
        BulletBlueprint bullet = null;

        switch (continer.bulletType)
        {
            case BulletType.NoramlBullet:
                {
                    PlayerNormalBullet normalBullet = Instantiate(_normalBullet, continer.position, transform.rotation);

                    normalBullet.Init(5, 1);

                    normalBullet.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().color = continer.BeamColor;

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
