using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveName : MonoBehaviour
{
    int numberOfCharacters;
    public Button play;
   public void SaveNewName (string s)
    {
        numberOfCharacters=s.Length;
        if(numberOfCharacters>3 && numberOfCharacters < 9)
        {
            GameManager.instance.SetNamePlayer(s);
            Debug.Log(s);
            play.interactable = true;
        }
        else
        {
            play.interactable = false;
        }
        
    }
}
