using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveRata : MonoBehaviour
{
    public GameObject rata1;
    public GameObject rata2;
    public GameObject rata3;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.CompareTag("Rata1"))
        {
            rata1.SetActive(true);
        }
        else if (this.CompareTag("Rata2"))
        {
            rata2.SetActive(true);
        }
        else if (this.CompareTag("Rata3"))
        {
            rata3.SetActive(true);
        }
    }
}