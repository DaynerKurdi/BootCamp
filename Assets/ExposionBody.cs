using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExposionBody : MonoBehaviour
{
    private Sprite[] _spritesArray;
    private int _spriteIndex;
    private float _currentAnimationTime;
    private float _maxAnimationTime = 0.05f;
    private SpriteRenderer _spriteRenderer;
    private AudioSource _audioSource;

    public void Init(Sprite[] SpriteArray, AudioClip clip)
    {
        _spritesArray = SpriteArray;
        _spriteIndex = 0;
        _currentAnimationTime = 0;

        transform.localScale = Vector3.one * 1.5f;

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();

        _spriteRenderer.sprite = _spritesArray[0];
        _audioSource.clip = clip;

        gameObject.SetActive(false); 
    }

    public bool UpdateScript()
    {
        return SpriteAnimationProcess();
    }

    public void BeginEffect(Vector3 position)
    {
        _spriteIndex = 0;
        _currentAnimationTime = 0;
        _spriteRenderer.sprite = _spritesArray[0];
        transform.position = position;
        gameObject.SetActive(true);
        //_audioSource.pitch = Random.Range(-2.0f, 2.0f);
        _audioSource.Play();

    }

    private bool SpriteAnimationProcess()
    {
        bool result = false;

        if (_currentAnimationTime == _maxAnimationTime)
        {
            _currentAnimationTime = 0;
            _spriteIndex++;

            if (_spriteIndex >= _spritesArray.Length)
            {
                _spriteIndex = 0; 

                result = true;
            }

            _spriteRenderer.sprite = _spritesArray[_spriteIndex];

        }
        else
        {
            _currentAnimationTime += Time.deltaTime;
            if (_currentAnimationTime > _maxAnimationTime)
            {
                _currentAnimationTime = _maxAnimationTime;
            }
        }

        return result;
    }

}
