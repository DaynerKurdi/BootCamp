using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 bullVector = transform.position;

        bullVector.y = bullVector.y + 5 * Time.deltaTime;

        transform.position = bullVector;

        if (transform.position.y > 10)
        {
           Destroy(gameObject);
        }
    }
}
