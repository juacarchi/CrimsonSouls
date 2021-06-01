using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject canvasName;
    public GameObject canvasOpciones;
    public GameObject canvasCreditos;
  public void PlayGame()
    {
        canvasName.SetActive(true);
    }
    public void Return()
    {
        if (canvasName != null)
        {
            canvasName.SetActive(false);
        }
        canvasOpciones.SetActive(false);
        canvasCreditos.SetActive(false);
    }
    public void Opciones()
    {
        canvasOpciones.SetActive(true);
    }
    public void Creditos()
    {
        canvasCreditos.SetActive(true);
    }
}
