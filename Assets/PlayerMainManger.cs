using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMainManger : MonoBehaviour
{

    public float _speed = 5;

    private SpaceShipObject _shipObject;
    private int _points;

    private float _leftRightInputValue;
    private float _upDownInputValue;
   
    public void Init()
    {
        _shipObject = transform.GetChild(0).GetComponent<SpaceShipObject>(); 
        
        _points = 0;
    }

    public void UpdateScript()
    {
        Vector3 moveVector = _shipObject.transform.position;

        moveVector.x += _leftRightInputValue * _speed * Time.deltaTime;
        moveVector.y += _upDownInputValue * _speed * Time.deltaTime;

        if (moveVector.x > 8)
        {
            moveVector.x = 8;
        }
        if (moveVector.x < -8)
        {
            moveVector.x = -8;
        }

        if (moveVector.y > 4)
        {
            moveVector.y = 4;
        }
        if (moveVector.y < -4)
        {
            moveVector.y = -4;
        }

     
        _shipObject.transform.position = moveVector;

        
    }

    public void ReadUserLeftRightMovementInput(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();

        Debug.Log(value);

        if (context.performed)
        {
            if (value > 0)
            {
                _leftRightInputValue = 1;
            }
            else if (value < 0)
            {
                _leftRightInputValue = -1;
            }
        }
        else if (context.canceled)
        {
            _leftRightInputValue = 0;
        }
       
    }

    public void ReadUserUpDownMovement(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();

        if (context.performed)
        {
            if (value > 0)
            {
                _upDownInputValue = 1;
            }
            else if (value < 0)
            {
                _upDownInputValue = -1;
            }
        }
        else if (context.canceled)
        {
            _upDownInputValue = 0;
        }
    }

    public void ReadUserShootInput(InputAction.CallbackContext context)
    {
        BulletContiner continer = new BulletContiner();

        continer.position = _shipObject.transform.position;
        continer.bulletType = BulletSpawner.BulletType.NoramlBullet;
        continer.BeamColor = Color.magenta;

        //todo
        EventSystemRef.instance.BulletRequest.Invoke(continer);

        _points++;

        EventSystemRef.instance.UpdateTextHandler.Invoke(_points.ToString());
    }
}
