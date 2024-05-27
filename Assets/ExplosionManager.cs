using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    private Sprite[] _explosionSpriteArray;
    private Transform _offscreeanPosition;

    public void Init()
    {
        _explosionSpriteArray = ResourcesLoader.Instance.GetExposionSpritesArray();

        _offscreeanPosition = transform.GetChild(1);
    }
}
