using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeBaston : MonoBehaviour
{
    public GameObject baston;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.instance.ShowBaston(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButtonDown("Take"))
        {
            GameManager.instance.SetHasBaston(true);
            Character2DController.instance.SetHasBaston(true);

            Destroy(baston);
            BoxCollider2D bxCetro = GetComponent<BoxCollider2D>();
            Destroy(bxCetro);
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
