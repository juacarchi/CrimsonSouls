using System.Collections.Generic;
using UnityEngine;

public class Dialogue1 : MonoBehaviour
{
    public static Dialogue1 instance;
    public List<string> dialogue1;
    public List<string> dialogue2;
    public List<string> dialogue3;
    public List<string> dialogue4;
    public List<string> dialogue5;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        //PRIMER DIALOGO
        dialogue1.Add("¿DÓNDE ESTOY?...");
        dialogue1.Add(" ¡AGH!… MI CABEZA…");
        dialogue1.Add("*SONIDO DE UN MONSTRUO*");
        dialogue1.Add("¡LO MEJOR SERA QUE CORRA!");
        //SEGUNDO DIALOGO
        dialogue2.Add("VOZ EN LO PROFUNDO DEL MAUSOLEO: VEN... AYUDAME... VEN!");
        dialogue2.Add("PROTAGONISTA: ¿QUE?... ALGUIEN DEBE ESTAR ATRAPADO");
        //TERCER DIÁLOGO
        dialogue3.Add("VOZ DE AUXILIO: AQUI... AYUDAME!");
        dialogue3.Add("LA VOZ VIENE DE... ¿ESE BASTON?");
        //CUARTO DIALOGO
        dialogue4.Add("BASTON: AAGH! POR FIN SOY LIBRE OTRA VEZ!, TU DEBES DE SER EL DESCENDIENTE DEL HEROE");
        dialogue4.Add("PROTAGONISTA: ¿QUIEN?");
        dialogue4.Add("BASTON: AHH... CLARO! ACABAS DE DESPERTAR DEBES ESTAR MUY ATURDIDO Y NO RECORDARAS NADA... TU NOMBRE ES: " + GameManager.instance.namePlayer);
        dialogue4.Add("SI TE HAS DESPERTADO QUIERE DECIR... QUE EL MAL TAMBIEN LO HA HECHO");
        dialogue4.Add("¡VAMOS,SALGAMOS FUERA A VER COMO ESTAN LAS COSAS! TE EXPLICARE TODA LA HISTORIA MAS ADELANTE");
        //QUINTO DIALOGO
        dialogue5.Add("BASTON: YA VEO ALGUNOS MONSTRUOS, USA LA <K> PARA ATACAR DE CERCA Y LA <J> DE LEJOS.");
        dialogue5.Add("ESTE BASTON RECOGE LAS ALMAS PERDIDADS PARA SALVARLAS. TIENES QUE SALVAR EL MUNDO OTRA VEZ " + GameManager.instance.namePlayer + " ¡VAMOS!");

        StartDialogue(dialogue1);
    }


    public void StartDialogue(List<string> dialogue)
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }
}
