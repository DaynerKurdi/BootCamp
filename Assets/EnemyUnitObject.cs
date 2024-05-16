using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitObject : MonoBehaviour
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

    public bool GetStartMovingCheck()
    {
        return _startMoving;
    }

    public void Init()
    {
        _maxHealth = 3;
        _currentHealth = _maxHealth;
        _speed = 5.0f;

        _currentWaitTime = 0;
        _startMoving = false;
        _IsCountingDown = false;
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

        //transform.position = moveVector;
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log( "    just hit me");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(   "is hitting me");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("    stopped hitting me");
    }

}
