using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHUD : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyGOHUD();
        }
    }
    public void DestroyGOHUD()
    {
       Destroy(HUDManager.instance.gameObject);
    }
}
