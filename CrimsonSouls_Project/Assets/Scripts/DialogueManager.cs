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
            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }
        dialoguePanel.SetActive(false);
    }
    //Este método se llama desde fuera ya sea con una colisión, tiempo u otra circunstancia.
    //Se pasa una lista de string que será completada en el inspector.
    public void StartDialogue(List<string> d)
    {
        Character2DController.instance.SetCanMove(false);
        dialoguePanel.SetActive(true);
        myDialogue = d;
        textDialogue.text = d[0];
    }
    //Este método será llamado normalmente por un botón que llame a este método cuando se pulse
    //O lo llama al tocar alguna tecla, entonces lo llamaríamos desde el GameManager.
    public void NextSentence()
    {

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
