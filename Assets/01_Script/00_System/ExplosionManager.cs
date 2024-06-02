using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ExplostionRequestEventEvent : UnityEvent<Vector3>
{

}





public class ExplosionManager : MonoBehaviour
{

    public static ExplosionManager instance;
    private Transform _offscreeanPosition;

    private Queue<ExposionBody> _expolsionBodyQueue;
    private List<ExposionBody> _activeExoplsionBodyList;

    public ExplostionRequestEventEvent _exlosionEventHandler;

    public void Init()
    {
        instance = this;
        _expolsionBodyQueue = new Queue<ExposionBody>();
        _activeExoplsionBodyList = new List<ExposionBody>();

        Sprite[] explosionSpriteArray = ResourcesLoader.Instance.GetExposionSpritesArray();
        AudioClip clip = ResourcesLoader.Instance.GetAudioClip("EXPLOSION");


        _offscreeanPosition = transform.GetChild(1);

        int count = transform.GetChild(0).childCount;

        for (int i = 0; i < count; i++)
        {
            ExposionBody temp = transform.GetChild(0).GetChild(i).GetComponent<ExposionBody>();

            temp.Init(explosionSpriteArray, clip);

            temp.transform.position = _offscreeanPosition.position;

            _expolsionBodyQueue.Enqueue(temp);
        }

        instance._exlosionEventHandler.AddListener(SpwanExposionBodyEvent);
    }

    public void UpdateScript()
    {
        int count = _activeExoplsionBodyList.Count;

        for (int i = 0; i < count; i++)
        {
            bool result = _activeExoplsionBodyList[i].UpdateScript();

            if (result)
            {
                PutExposionBackToSleep(_activeExoplsionBodyList[i]);
            }
        }
    }

    private void SpwanExposionBodyEvent(Vector3 position)
    {
        ExposionBody temp = _expolsionBodyQueue.Dequeue();

        temp.BeginEffect(position);

        _activeExoplsionBodyList.Add(temp);
    }

    private void PutExposionBackToSleep(ExposionBody body)
    {
        body.gameObject.SetActive(false);
        body.transform.position = _offscreeanPosition.position;

        _expolsionBodyQueue.Enqueue(body);
    }

}
