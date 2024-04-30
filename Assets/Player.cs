using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform cameraTran;
    public float _speed = 5;
    private int lifes = 4;

    public GameObject _bullset;

    public bool _bulletFiredFlag = false;
    public List<GameObject> _bulletList;

    // Start is called before the first frame update
    void Start()
    {
        _bulletList = new List<GameObject>();

        Vector2 x = new Vector2();

        GameManager.instance._stageName = "Stage One";
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVector = transform.position;
       

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

        if(moveVector.x > 8)
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

       

        if (Input.GetKey(KeyCode.Space))
        {
          //  _bulletFiredFlag = true;
            Instantiate(_bullset, transform.position, transform.rotation); 
        }

       

        transform.position = moveVector;

        moveVector.z = cameraTran.position.z;

      //  cameraTran.position = moveVector;
    }
}
