using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[Serializable]
public class MyCustomUnityEvent : UnityEvent<Vector3>
{

}


public class EventSystemRef : MonoBehaviour
{
    public static EventSystemRef instance;

    public MyCustomUnityEvent BulletRequest;

    public void Init()
    {
        instance = this;

        //BulletRequest.AddListener(BulletMainManger.Instance.SpawnBulletRequest);
    }
}
