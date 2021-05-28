using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue1 : MonoBehaviour
{
    public List<string> dialogue1;
    void Start()
    {

        dialogue1.Add("Su nombre es: " + GameManager.instance.namePlayer);
        StartDialogue1();
    }

   
    public void StartDialogue1()
    {
        DialogueManager.instance.StartDialogue(dialogue1);
    }
}
