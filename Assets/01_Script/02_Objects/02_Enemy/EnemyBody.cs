using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBody : MonoBehaviour
{
    public int _currentHealth = 0;
    public int _maxHealth = 3;
    public float _speed = 5.0f;

    [SerializeField]
    private float _currentWaitTime = 0;
    private float _maxWaitTime = 0.5f;

    [SerializeField]
    private bool _startMoving = false;
    [SerializeField]
    private bool _IsCountingDown = false;

    public bool StartMovingCheck { get { return _startMoving; }set { _startMoving = value; } }

    public bool IsCountingDown { get {  return _IsCountingDown; } set { _IsCountingDown = value; } }

    public void Initialize()
    {
        _maxHealth = 3;
        _currentHealth = _maxHealth;
        _speed = 5.0f;

        _currentWaitTime = 0;
        _startMoving = false;
        _IsCountingDown = false;

        gameObject.SetActive(false);
        transform.GetChild(1).GetChild(0).GetComponent<Collider2D>().enabled = false;
    }

    public void BeginObject()
    {
        _maxHealth = 3;
        _currentHealth = _maxHealth;
        _speed = 5.0f;

        _currentWaitTime = 0;
        _startMoving = true;
        _IsCountingDown = false;

        transform.GetChild(1).GetChild(0).GetComponent<Collider2D>().enabled = true;

        gameObject.SetActive(true);
    }

    public void UpdateScript()
    {
        if (_IsCountingDown)
        {
            if (_currentWaitTime == _maxWaitTime)
            {
                _currentWaitTime = 0;
                _IsCountingDown = false;
                _startMoving = true;
            }
            else
            {
                _currentWaitTime += Time.deltaTime;

                if (_currentWaitTime > _maxWaitTime) 
                {
                    _currentWaitTime = _maxWaitTime;
                }
            }
        }

        if (_startMoving) 
        {
            Move();
        }
    }

    private void Move()
    {
        Vector3 moveVector = transform.position;

        moveVector.y = moveVector.y + -_speed * Time.deltaTime;

        transform.position = moveVector;
    }

    public void RemoveObject()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Bullet Body") && _currentHealth > 0)
        {
            BulletBody bullet = collision.GetComponent<BulletBody>();

            TakeDamage(bullet.DealDamage());

            bullet.RemoveBullet();
        }
    }

    private void TakeDamage(int Amount)
    {
        _currentHealth -= Mathf.Abs(Amount);

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        if ( _currentHealth == 0)
        {
            EventSystemReference.Instance.ExplostionRequestEventHandler.Invoke(transform.position);

            EventSystemReference.Instance.EnemyPutObjectBackToSleepEventHandler.Invoke(this);

            transform.GetChild(1).GetChild(0).GetComponent<Collider2D>().enabled = false;

            EventSystemReference.Instance.SendScoreToPlayerEventHandler.Invoke(1);

            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }

}
