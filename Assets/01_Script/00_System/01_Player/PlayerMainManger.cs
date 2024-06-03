using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMainManger : MonoBehaviour
{ 
    private float _speed = 5;
    private float _normalShotSpeed = 13.0f;

    private SpaceShipObject _shipObject;

    private float _leftRightInputValue;
    private float _upDownInputValue;
   
    public void Initialize()
    {
        _shipObject = transform.GetChild(0).GetComponent<SpaceShipObject>();
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
        if (!context.started)
        {
            BulletContiner continer = new BulletContiner();

            continer.position = _shipObject.transform.position;
            continer.bulletType = BulletType.PlayerNoramlBullet;
            continer.damage = 1;
            continer.beamColor = Color.magenta;
            continer.speed = _normalShotSpeed;
            continer.direction = 1;

            //todo
            EventSystemReference.Instance.BulletRequestEventHandler.Invoke(continer);
        }
    }
}
