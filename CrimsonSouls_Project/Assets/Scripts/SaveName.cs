using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveName : MonoBehaviour
{
    
   public void SaveNewName (string s)
    {
        GameManager.instance.SetNamePlayer(s);
        Debug.Log(s);
    }
}
