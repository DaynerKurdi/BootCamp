using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMainManger : MonoBehaviour
{

    public float _speed = 5;

    private SpaceShipObject _shipObject;
    private int _points;
   
    public void Init()
    {
        _shipObject = transform.GetChild(0).GetComponent<SpaceShipObject>(); 
        
        _points = 0;
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

        if (Input.GetKeyDown(KeyCode.Space))
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

       

        _shipObject.transform.position = moveVector;

        
    }
}
