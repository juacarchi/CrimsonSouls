using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue1 : MonoBehaviour
{
    public List<string> dialogue1;
    void Start()
    {
        dialogue1.Add("Esta es la primera parte del primer diálogo, mi nombre es: " + GameManager.instance.namePlayer);
        
        StartDialogue1();
    }

   
    public void StartDialogue1()
    {
        DialogueManager.instance.StartDialogue(dialogue1);
    }
}
