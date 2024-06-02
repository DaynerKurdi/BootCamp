using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    private Queue<BulletBody> _bulletBodyQueue;
    private Transform _offScreenPosition;

    public void Initialization()
    {
        _bulletBodyQueue = new Queue<BulletBody>();

        int count = transform.GetChild(0).childCount;

        _offScreenPosition = transform.GetChild(1);

        for (int i = 0;i < count; i++)
        {
            BulletBody temp = transform.GetChild(0).GetChild(i).GetComponent<BulletBody>();

            temp.Initialization();

            temp.transform.position = _offScreenPosition.position;

            temp.gameObject.SetActive(false);

            _bulletBodyQueue.Enqueue(temp);
        }
    }

    public BulletBody SpawnBullet (BulletContiner continer)
    {
        if (_bulletBodyQueue.Count > 0 )
        {
            BulletBody bullet = _bulletBodyQueue.Dequeue();

            bullet.gameObject.SetActive(true);

            switch (continer.bulletType)
            {
                case BulletType.PlayerNoramlBullet:
                    {
                        PlayerNormalBulletObject bulletLogic = new PlayerNormalBulletObject();

                        bulletLogic.Initialization(continer.speed * continer.direction, continer.damage);

                        bullet.SetupData(bulletLogic, continer);
                    }
                    break;
                default:
                    {

                    }
                    break;
            }
            return bullet;
        }
        return null;
    }

    public void SetBulletBackToSleep(BulletBody bullet)
    {
        bullet.RemoveObject();

        bullet.transform.position = _offScreenPosition.position;
        bullet.gameObject.SetActive(false);

        _bulletBodyQueue.Enqueue(bullet);
    }
}
