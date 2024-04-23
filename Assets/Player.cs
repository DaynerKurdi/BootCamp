using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _speed = 5;
    private int lifes = 4;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 x = new Vector2();
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

        transform.position = moveVector;
    }
}
