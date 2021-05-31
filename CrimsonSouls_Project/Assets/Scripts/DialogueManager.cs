using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public GameObject dialoguePanel; //Panel donde aparecen los dialogos.
    public Text textDialogue;
    List<string> myDialogue;
    int i = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        dialoguePanel.SetActive(false);
    }
    
    public void StartDialogue(List<string> d)
    {
        i = 1;
        Character2DController.instance.SetCanMove(false);
        Character2DController.instance.anim.SetFloat("Speed", 0);
        dialoguePanel.SetActive(true);
        myDialogue = d;
        textDialogue.text = d[0];
    }
    
    public void NextSentence()
    {
        Debug.Log("SiguienteOracion");
        if (i < myDialogue.Count)
        {
            textDialogue.text = myDialogue[i];
            i++;
        }
        else
        {
            HideDialogue();
        }
    }
    //Oculta el panel
    public void HideDialogue()
    {
        Character2DController.instance.SetCanMove(true);
        dialoguePanel.SetActive(false);
    }

}
