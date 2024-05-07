using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMainManger : MonoBehaviour
{

    public float _speed = 5;

    private SpaceShipObject _shipObject;
    public BulletMovement _bulletObject;

    public void Init()
    {
        _shipObject = transform.GetChild(0).GetComponent<SpaceShipObject>();    
    }

    public void UpdateScript()
    {
        Vector3 moveVector = _shipObject.transform.position;


        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveVector.x = moveVector.x + (_speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveVector.x = moveVector.x + (-_speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveVector.y = moveVector.y + (_speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            moveVector.y = moveVector.y + (-_speed * Time.deltaTime);

        }

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
}
