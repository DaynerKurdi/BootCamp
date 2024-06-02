using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[Serializable]
public class BulletRequestUnityEvent : UnityEvent<BulletContiner>
{

}
[Serializable]
public class BulletPutBulletBackToSleepEvent : UnityEvent<BulletBody>
{

}

[Serializable]
public class UiTextScoreUpdateRequestUnityEvent : UnityEvent<string>
{

}

[Serializable]
public class ExplostionRequestEventEvent : UnityEvent<Vector3>
{

}


public class EventSystemReference : MonoBehaviour
{
    public static EventSystemReference Instance;

    public BulletRequestUnityEvent BulletRequestEventHandler;
    public BulletPutBulletBackToSleepEvent BulletPutBulletBackToSleepEventHandler;
    public UiTextScoreUpdateRequestUnityEvent UpdateScoreEventTextHandler;
    public ExplostionRequestEventEvent ExplostionRequestEventHandler;

    public void Initialization()
    {
        Instance = this;
    }
}
