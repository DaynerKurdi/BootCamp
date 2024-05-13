using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[Serializable]
public class MyCustomUnityEvent : UnityEvent<BulletContiner>
{

}
[Serializable]
public class MyCustomUnityEventTwo : UnityEvent<string>
{

}

public struct BulletContiner
{
    public Vector3 position;
    public BulletSpawner.BulletType bulletType;
    public float Speed;
    public int Damage;
    public Color BeamColor;


}


public class EventSystemRef : MonoBehaviour
{
    public static EventSystemRef instance;

    public MyCustomUnityEvent BulletRequest;
    public MyCustomUnityEventTwo UpdateTextHandler;

    public void Init()
    {
        instance = this;

        //BulletRequest.AddListener(BulletMainManger.Instance.SpawnBulletRequest);
    }
}
