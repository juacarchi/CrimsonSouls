using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{

    public float speed;
    bool facingRight;
    private void Start()
    {
        if (Character2DController.instance.facingRight)
        {
            facingRight = true;
        }
        else
        {
            facingRight = false;
        }
    }
    void Update()
    {
        if (facingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        
    }
}
