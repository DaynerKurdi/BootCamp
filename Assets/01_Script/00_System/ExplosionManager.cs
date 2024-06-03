using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    private Transform _offscreeanPosition;
    private Queue<ExposionObject> _expolsionBodyQueue;
    private List<ExposionObject> _activeExoplsionBodyList;

    public void Initialize()
    {
        _expolsionBodyQueue = new Queue<ExposionObject>();
        _activeExoplsionBodyList = new List<ExposionObject>();

        Sprite[] explosionSpriteArray = ResourcesLoader.Instance.GetExposionSpritesArray();
        AudioClip clip = ResourcesLoader.Instance.GetAudioClip("EXPLOSION");

        _offscreeanPosition = transform.GetChild(0);

        int count = transform.GetChild(1).childCount;

        for (int i = 0; i < count; i++)
        {
            ExposionObject temp = transform.GetChild(1).GetChild(i).GetComponent<ExposionObject>();

            temp.Initialize(explosionSpriteArray, clip);

            temp.transform.position = _offscreeanPosition.position;

            _expolsionBodyQueue.Enqueue(temp);
        }
        EventSystemReference.Instance.ExplostionRequestEventHandler.AddListener(SpwanExposionBodyEvent);
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
        ExposionObject temp = _expolsionBodyQueue.Dequeue();

        temp.BeginEffect(position);

        _activeExoplsionBodyList.Add(temp);
    }

    private void PutExposionBackToSleep(ExposionObject body)
    {
        body.gameObject.SetActive(false);
        body.transform.position = _offscreeanPosition.position;

        _expolsionBodyQueue.Enqueue(body);
    }

}
