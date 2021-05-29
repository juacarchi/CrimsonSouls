using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeBaston : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.instance.ShowBaston(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Character2DController.instance.SetHasBaston(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.instance.ShowBaston(false);
        }
    }
}
