using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpaceShipObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.transform.parent.parent.name + "    just hit me");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.transform.parent.parent.name + "    is hitting me");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.transform.parent.parent.name + "    stopped hitting me");
    }



}


